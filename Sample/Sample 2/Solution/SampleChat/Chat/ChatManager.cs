using System;
using System.Collections.Generic;
using System.Text;
using SampleChat.Chat.Data;
using System.Web;


namespace SampleChat.Chat
{
	public class ChatManager
	{
		private ApplicationWrapper _application;
		public ApplicationWrapper CurrentApplication
		{
			get
			{
				if (_application == null)
				{
					_application = new ApplicationWrapper(HttpContext.Current.Application);
				}
				return _application;
			}
			set
			{
				_application = value;
			}
		}

		private SessionWrapper _session;
		public SessionWrapper CurrentSession
		{
			get
			{
				if (_session == null)
				{
					_session = new SessionWrapper(HttpContext.Current.Session);
				}
				return _session;
			}
			set
			{
				_session = value;
			}
		}

		//recommended: store in application configuration
		private TimeSpan _chatUsersMaxInterval = new TimeSpan(0, 0, 5);
		/// <summary>
		/// If the user has no activity (no reading/writing messages), the users is "disconnected"
		/// </summary>
		public TimeSpan ChatUsersMaxInterval
		{
			get
			{
				return _chatUsersMaxInterval;
			}
		}

		/// <summary>
		/// All chat rooms
		/// </summary>
		private ChatRoomCollection ChatRooms
		{
			get
			{
				return CurrentApplication.ChatRooms;
			}
		}

		/// <summary>
		/// Current user's room
		/// </summary>
		private ChatRoom CurrentRoom
		{
			get
			{
				if (RoomId == 0)
				{
					throw new ArgumentException("No room id given. Session lost.");
				}
				return ChatRooms[RoomId];
			}
		}

		/// <summary>
		/// The last time the user 
		/// </summary>
		public DateTime RoomUsersDate
		{
			get
			{
				return CurrentSession.RoomUsersDate;
			}
			set
			{
				CurrentSession.RoomUsersDate = value;
			}
		}

		/// <summary>
		/// Current user in the room
		/// </summary>
		private ChatUser CurrentUser
		{
			get
			{
				return CurrentRoom.Users[CurrentSession.User.UserId];
			}
			set
			{
				CurrentRoom.Users[CurrentSession.User.UserId] = value;
			}
		}

		/// <summary>
		/// Set the current date as the time of last activity of the user.
		/// </summary>
		private void SetLastActivity()
		{
			CurrentUser.LastActivity = DateTime.Now;
		}

		/// <summary>
		/// The current room id. 
		/// </summary>
		public int RoomId
		{
			get
			{
				return CurrentSession.RoomId;
			}
			set
			{
				CurrentSession.RoomId = value;
			}
		}

		/// <summary>
		/// The last message id of the room, the time the user logged in.
		/// </summary>
		public int? LastMessageId
		{
			get
			{
				return CurrentSession.LastMessageId;
			}
			set
			{
				CurrentSession.LastMessageId = value;
			}
		}
	

		/// <summary>
		/// Checks (light) if the list of users has changed
		/// </summary>
		/// <returns></returns>
		public ChatResponse CheckUsers()
		{
			ChatResponse response = new ChatResponse();

			ChatRoom room = CurrentRoom;
			if (room.LastUserChange > this.RoomUsersDate)
			{
				foreach (KeyValuePair<int, ChatUser> keyValue in room.Users)
				{
					response.Users.Add(keyValue.Value);
				}

				this.RoomUsersDate = room.LastUserChange;

			}
			return response;
		}


		/// <summary>
		/// Checks (light) if the list of users the user
		/// </summary>
		private void CheckUsers(ChatResponse response)
		{
			response.Users = CheckUsers().Users;
		}


		/// <summary>
		/// Set the user as active in the chat room
		/// </summary>
		/// <param name="roomId"></param>
		/// <returns>The last message id</returns>
		public int EnterRoom(int roomId)
		{
			
			RoomId = roomId;
			CurrentRoom.ValidateUsers(ChatUsersMaxInterval);
			CurrentRoom.EnterRoom(CurrentSession.User.UserId, CurrentSession.User.UserName);
			
			//TODO (?): Send a message 
			
			if (LastMessageId == null)
			{
				ChatDataAccess da = new ChatDataAccess();
				LastMessageId = da.GetLastMessage();
			}
			return (int) LastMessageId;
		}

		public ChatResponse CheckMessages(int lastMessage)
		{
			ChatResponse response = new ChatResponse();
			SetLastActivity();

			//Get messages from the db
			ChatDataAccess da = new ChatDataAccess();
			List<ChatMessage> messages = da.GetRoomMessages(lastMessage, RoomId);

			if (messages.Count > 0)
			{
				response.Messages.AddRange(messages);
				response.LastMessageId = messages[messages.Count - 1].Id;

				CheckUsers(response);
			}

			return response;
		}

		public ChatResponse SendMessage(string message, int lastMessageId)
		{
			SetLastActivity();

			//Save message in the db
			ChatDataAccess da = new ChatDataAccess();
			da.MessageInsert(RoomId, message, DateTime.Now, CurrentSession.User.UserId, false);

			//Validate users
			CurrentRoom.ValidateUsers(ChatUsersMaxInterval);

			return CheckMessages(lastMessageId);
		}


	}
}
