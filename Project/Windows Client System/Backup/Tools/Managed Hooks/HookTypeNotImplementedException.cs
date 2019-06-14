using System;

namespace BinarySoftCo.Tools.ManagedHook
{
	/// <include file='ManagedHooks.xml' path='Docs/HookTypeNotImplementedException/Class/*'/>
	public class HookTypeNotImplementedException : ManagedHooksException
	{
		/// <include file='ManagedHooks.xml' path='Docs/ManagedHooksException/ctor/*'/>
		public HookTypeNotImplementedException()
		{
		}

		/// <include file='ManagedHooks.xml' path='Docs/ManagedHooksException/ctor_string/*'/>
		public HookTypeNotImplementedException(string message) : base(message) 
		{
		}

		/// <include file='ManagedHooks.xml' path='Docs/ManagedHooksException/ctor_string_exception/*'/>
		public HookTypeNotImplementedException(string message, Exception innerException) 
			: base(message, innerException) 
		{
		}
	}
}
