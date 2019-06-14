using System;
using System.Drawing;

namespace BinarySoftCo.Tools.ManagedHook
{
	/// <include file='ManagedHooks.xml' path='Docs/MouseEvents/enum/*'/>
	public enum MouseEvents
	{
		/// <include file='ManagedHooks.xml' path='Docs/General/Empty/*'/>
		LeftButtonDown	= 0x0201,
		/// <include file='ManagedHooks.xml' path='Docs/General/Empty/*'/>
		LeftButtonUp	= 0x0202,
		/// <include file='ManagedHooks.xml' path='Docs/General/Empty/*'/>
		Move			= 0x0200,
		/// <include file='ManagedHooks.xml' path='Docs/General/Empty/*'/>
		MouseWheel		= 0x020A,
		/// <include file='ManagedHooks.xml' path='Docs/General/Empty/*'/>
		RightButtonDown = 0x0204,
		/// <include file='ManagedHooks.xml' path='Docs/General/Empty/*'/>
		RightButtonUp	= 0x0205
	}

	/// <include file='ManagedHooks.xml' path='Docs/MouseHook/Class/*'/>
	public class MouseHook : SystemHook
	{
		/// <include file='ManagedHooks.xml' path='Docs/MouseHook/MouseEventHandler/*'/>
		public delegate void MouseEventHandler(MouseEvents mEvent, Point point);

		/// <include file='ManagedHooks.xml' path='Docs/MouseHook/MouseEvent/*'/>
		public event MouseEventHandler MouseEvent;

		/// <include file='ManagedHooks.xml' path='Docs/MouseHook/ctor/*'/>
		public MouseHook() : base(HookTypes.MouseLL)
		{
		}

		/// <include file='ManagedHooks.xml' path='Docs/MouseHook/HookCallback/*'/>
		protected override void HookCallback(int code, UIntPtr wparam, IntPtr lparam)
		{
			if (MouseEvent == null)
			{
				return;
			}

			int x = 0, y = 0;
			MouseEvents mEvent = (MouseEvents)wparam.ToUInt32();

			switch(mEvent)
			{
				case MouseEvents.LeftButtonDown:
					GetMousePosition(wparam, lparam, ref x, ref y);
					break;
				case MouseEvents.LeftButtonUp:
					GetMousePosition(wparam, lparam, ref x, ref y);
					break;
				case MouseEvents.MouseWheel:
					break;
				case MouseEvents.Move:
					GetMousePosition(wparam, lparam, ref x, ref y);
					break;
				case MouseEvents.RightButtonDown:
					GetMousePosition(wparam, lparam, ref x, ref y);
					break;
				case MouseEvents.RightButtonUp:
					GetMousePosition(wparam, lparam, ref x, ref y);
					break;
				default:
					//System.Diagnostics.Trace.WriteLine("Unrecognized mouse event");
					break;
			}

			MouseEvent(mEvent, new Point(x, y));
		}

		/// <include file='ManagedHooks.xml' path='Docs/MouseHook/FilterMessage/*'/>
		public void FilterMessage(MouseEvents eventType)
		{
			base.FilterMessage(this.HookType, (int)eventType);
		}

	}
}
