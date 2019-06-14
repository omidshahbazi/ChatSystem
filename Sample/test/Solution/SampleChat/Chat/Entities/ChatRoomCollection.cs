using System;
using System.Collections.Generic;
using System.Text;

namespace SampleChat.Chat
{
	public class ChatRoomCollection : Dictionary<int,ChatRoom> 
	{
		public ChatRoom Get(int key)
		{
			if (this[key] == null)
			{
				this[key] = new ChatRoom();
			}
			return this[key];
			
		}

		/// <summary>
		/// Gets the chatroom by key, if is not created it creates a new one.
		/// </summary>
		public new ChatRoom this[int key]
		{
			get
			{
				if (!base.ContainsKey(key))
				{
					base[key] = new ChatRoom();
				}
				return base[key];
			}
			set
			{
				base[key] = value;
			}
		}

	}
}
