using System;
using System.Collections.Generic;
using System.Text;

namespace SampleChat.Chat
{
	[Serializable]
	public class ChatResponse
	{
		private List<ChatUser> _users;

		public List<ChatUser> Users
		{
			get
			{
				return _users;
			}
			set
			{
				_users = value;
			}
		}

		private List<ChatMessage> _messages;

		public List<ChatMessage> Messages
		{
			get
			{
				return _messages;
			}
			set
			{
				_messages = value;
			}
		}

		private int _lastMessageId;
		public int LastMessageId
		{
			get
			{
				return _lastMessageId;
			}
			set
			{
				_lastMessageId = value;
			}
		}
	

		public ChatResponse()
		{
			this.Users = new List<ChatUser>();
			this.Messages = new List<ChatMessage>();
		}

		public ChatResponse(List<ChatUser> users, List<ChatMessage> messages)
		{
			this.Users = users;
			this.Messages = messages;
		}

		public ChatResponse(List<ChatUser> users)
		{
			this.Users = users;
			this.Messages = new List<ChatMessage>();
		}

		public ChatResponse(List<ChatMessage> messages)
		{
			this.Users = new List<ChatUser>();
			this.Messages = messages;
		}

	}
}
