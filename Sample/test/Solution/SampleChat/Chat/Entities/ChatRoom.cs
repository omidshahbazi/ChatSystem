using System;
using System.Collections.Generic;
using System.Text;

namespace SampleChat.Chat
{
	public class ChatRoom
	{
		private Dictionary<int,ChatUser> _users;

		/// <summary>
		/// Active users in the chat room
		/// </summary>
		public Dictionary<int,ChatUser> Users
		{
			get
			{
				return _users;
			}
		}

		/// <summary>
		/// The last time that the system validated active user.
		/// To avoid going all through the collection and validating if the users a valid more than once.
		/// </summary>
		public DateTime LastUserChange
		{
			get;
			set;
		}

		/// <summary>
		/// Checks if any of user is inactive, if true, then is removed from the chat list
		/// </summary>
		/// <param name="maxInterval"></param>
		public void ValidateUsers(TimeSpan maxInterval)
		{
			List<int> toDelete = new List<int>();
			foreach (System.Collections.Generic.KeyValuePair<int, ChatUser> keyValue in this.Users)
			{
				if (DateTime.Now.Subtract(keyValue.Value.LastActivity) > maxInterval)
				{
					toDelete.Add(keyValue.Key);
				}
			}

			foreach (int userId in toDelete)
			{
				this.Users.Remove(userId);
			}
			this.LastUserChange = DateTime.Now;
		}

		/// <summary>
		/// Add a new user to the room if needed.
		/// </summary>
		public void EnterRoom(int userId, string userName)
		{
			if (!this.Users.ContainsKey(userId))
			{
				this.Users.Add(userId, new ChatUser(userId, userName));
			}
			else
			{
				this.Users[userId].LastActivity = DateTime.Now;
			}

			this.LastUserChange = DateTime.Now;
		}

		/// <summary>
		/// Removes the user from the room
		/// </summary>
		/// <param name="userId"></param>
		public void LeaveRoom(int userId)
		{
			this.Users.Remove(userId);

			this.LastUserChange = DateTime.Now;
		}

		public ChatRoom()
		{
			this._users = new Dictionary<int, ChatUser>();

			this.LastUserChange = DateTime.Now;
		}
	}
}
