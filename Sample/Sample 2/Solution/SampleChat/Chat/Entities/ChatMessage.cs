using System;
using System.Collections.Generic;
using System.Text;

namespace SampleChat.Chat
{
	[Serializable]
	public class ChatMessage
	{
		public string MessageBody
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public DateTime Date
		{
			get;
			set;
		}

		public ChatMessage()
		{

		}

		public ChatMessage(int id, string messageBody, string userName, DateTime date)
		{
			this.Id = id;
			this.MessageBody = messageBody;
			this.UserName = userName;
			this.Date = date;
		}

		public int Id
		{
			get;
			set;
		}
	

	}
}
