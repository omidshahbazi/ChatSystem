using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.Script.Services;

namespace SampleChat.Chat.Services
{
	/// <summary>
	/// Summary description for ChatService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	[ScriptService]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class ChatService : System.Web.Services.WebService
	{

		private void CheckSiteSecurity()
		{
			if (new SessionWrapper(HttpContext.Current.Session).User == null)
			{
				throw new System.Security.SecurityException("Session lost. Need to be logged in to use the chat.");
			}
		}

		[WebMethod(EnableSession = true)]
		public int EnterRoom(int roomId)
		{
			CheckSiteSecurity();
			ChatManager manager = new ChatManager();
			return manager.EnterRoom(roomId);
		}

		[WebMethod(EnableSession = true)]
		public ChatResponse CheckUsers()
		{
			CheckSiteSecurity();
			ChatManager manager = new ChatManager();
			return manager.CheckUsers();
		}

		[WebMethod(EnableSession = true)]
		public ChatResponse CheckMessages(int lastMessage)
		{
			CheckSiteSecurity();
			ChatManager manager = new ChatManager();

			return manager.CheckMessages(lastMessage);
		}

		[WebMethod(EnableSession = true)]
		public ChatResponse SendMessage(string message, int lastMessageId)
		{
			CheckSiteSecurity();
			ChatManager manager = new ChatManager();

			return manager.SendMessage(message, lastMessageId);
		}
	}
}
