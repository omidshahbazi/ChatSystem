using System;
using System.Collections.Generic;
using System.Text;

namespace SampleChat.Chat
{
	public class SiteUser
	{
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

		private string _email;

		public string Email
		{
			get
			{
				return _email;
			}
			set
			{
				_email = value;
			}
		}

		public SiteUser(int userId, string userName)
		{
			this.UserId = userId;
			this.UserName = userName;
		}
	
	}
}
