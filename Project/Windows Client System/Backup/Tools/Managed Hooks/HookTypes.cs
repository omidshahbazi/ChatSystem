using System;

namespace BinarySoftCo.Tools.ManagedHook
{
	/// <include file='ManagedHooks.xml' path='Docs/HookTypes/enum/*'/>
	public enum HookTypes
	{
		/// <include file='ManagedHooks.xml' path='Docs/General/Empty/*'/>
		None		= -100,
		/// <include file='ManagedHooks.xml' path='Docs/General/Empty/*'/>
		Keyboard	= 2,
		/// <include file='ManagedHooks.xml' path='Docs/General/Empty/*'/>
		Mouse		= 7,
		/// <include file='ManagedHooks.xml' path='Docs/General/Empty/*'/>
		Hardware	= 8,
		/// <include file='ManagedHooks.xml' path='Docs/General/Empty/*'/>
		Shell		= 10,
		/// <include file='ManagedHooks.xml' path='Docs/General/Empty/*'/>
		KeyboardLL	= 13,
		/// <include file='ManagedHooks.xml' path='Docs/General/Empty/*'/>
		MouseLL		= 14
	};
}

//
// The following hooks seem to result in serious errors
// when installing them in the current implementation of this
// library. Please, only add them back *at your own risk*. 
// Remember the Dr. Suess quote from the article...
//

//JournalRecord			= 0,
//JournalPlayback		= 1,
//GetMessage			= 3,
//CallWindowProcedure	= 4,
//ComputerBasedTraining	= 5,
//SystemMessageFilter	= 6,
//Debug					= 9,
//ForegroundIdle		= 11,
//CallWindowProret		= 12,

