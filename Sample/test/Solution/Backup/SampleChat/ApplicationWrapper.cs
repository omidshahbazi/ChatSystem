using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using SampleChat.Chat;

namespace SampleChat
{
	public class ApplicationWrapper
	{
		public virtual HttpApplicationState Application
		{
			get;
			set;
		}

		public ApplicationWrapper()
		{
		}

		public ApplicationWrapper(HttpApplicationState application)
		{
			this.Application = application;
		}


		private const string keyChatRooms = "ChatRooms";
		public virtual ChatRoomCollection ChatRooms
		{
			get
			{
				if (Application[keyChatRooms] == null)
				{
					Application[keyChatRooms] = new ChatRoomCollection();
				}
				return (ChatRoomCollection)Application[keyChatRooms];
			}
		}
	}
}
