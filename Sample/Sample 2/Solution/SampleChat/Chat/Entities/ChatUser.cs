using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SampleChat.Chat
{
	[Serializable]
	public class ChatUser
	{
		private DateTime _lastActivity;
		/// <summary>
		/// Last time activity of the user
		/// </summary>
		[XmlIgnore]
		public DateTime LastActivity
		{
			get
			{
				return _lastActivity;
			}
			set
			{
				_lastActivity = value;
			}
		}

		private int _userId;
		public int UserId
		{
			get
			{
				return _userId;
			}
			set
			{
				_userId = value;
			}
		}

		private string _userName;
		public string UserName
		{
			get
			{
				return _userName;
			}
			set
			{
				_userName = value;
			}
		}

		public ChatUser(int userId, string userName)
		{
			this.UserId = userId;
			this.UserName = userName;
			this.LastActivity = DateTime.Now;
		}

		public ChatUser()
		{
		}
	
	}
}
