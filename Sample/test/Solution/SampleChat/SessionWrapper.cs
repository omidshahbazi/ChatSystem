using System;
using System.Collections.Generic;
using System.Text;
using System.Web.SessionState;
using System.Web;
using SampleChat.Chat;


namespace SampleChat
{
	/// <summary>
	/// Just a wrapper in order to hardcode all the session keys inside this class 
	/// and not all over the application
	/// </summary>
	public class SessionWrapper
	{
		protected virtual HttpSessionState Session
		{
			get;
			set;
		}

		public SessionWrapper()
		{

		}

		public SessionWrapper(HttpSessionState session)
		{
			this.Session = session;
		}

		#region User
		private const string keyUser = "User";
		public virtual SiteUser User
		{
			get
			{
				return (SiteUser)Session[keyUser];
			}
			set
			{
				Session[keyUser] = value;
			}
		}
		#endregion

		#region Chat
		#region RoomUsersDate
		private const string keyRoomUsersDate = "GotRoomUsers";
		/// <summary>
		/// The last time the user 
		/// </summary>
		public virtual DateTime RoomUsersDate
		{
			get
			{
				if (Session[keyRoomUsersDate] == null)
				{
					Session[keyRoomUsersDate] = DateTime.MinValue;
				}
				return (DateTime)Session[keyRoomUsersDate];
			}
			set
			{
				Session[keyRoomUsersDate] = value;
			}
		}
		#endregion

		#region RoomId
		private const string keyRoomId = "RoomId";
		/// <summary>
		/// The current room id
		/// </summary>
		public virtual int RoomId
		{
			get
			{
				return (int)Session[keyRoomId];
			}
			set
			{
				Session[keyRoomId] = value;
			}
		}
		#endregion

		#region LastMessageId
		private const string keyLastMessageId = "LastMessageId:";
		/// <summary>
		/// The last message id of the room, dependant of Room Id.
		/// </summary>
		public virtual int? LastMessageId
		{
			get
			{
				return (int?)Session[keyLastMessageId + RoomId.ToString()];
			}
			set
			{
				Session[keyLastMessageId + RoomId.ToString()] = value;
			}
		}
		#endregion
		#endregion
	}
}
