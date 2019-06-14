using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SampleChat.Chat.Data
{
	public class ChatDataAccess
	{
		public void MessageInsert(int roomId, string message, DateTime date, int userId, bool isSystem)
		{
			SqlCommand command = new SqlCommand();
			command.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "SPChatMessagesInsert";

			command.Parameters.Add(new SqlParameter("@RoomId", roomId));
			command.Parameters.Add(new SqlParameter("@MessageBody", message));
			command.Parameters.Add(new SqlParameter("@MessageDate", date));
			command.Parameters.Add(new SqlParameter("@UserId", userId));
			command.Parameters.Add(new SqlParameter("@IsSystem", isSystem));

			try
			{
				command.Connection.Open();
				command.ExecuteNonQuery();
			}
			finally
			{
				command.Connection.Close();
			}
		}

		public List<ChatMessage> GetRoomMessages(int lastMessageId, int roomId)
		{
			List<ChatMessage> messages = new List<ChatMessage>();
			DataTable dt = new DataTable();

			SqlCommand command = new SqlCommand();
			command.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "SPChatMessagesGet";

			command.Parameters.Add(new SqlParameter("@LastMessageId", lastMessageId));
			command.Parameters.Add(new SqlParameter("@RoomId", roomId));

			SqlDataAdapter da = new SqlDataAdapter(command);
			da.Fill(dt);

			foreach (DataRow dr in dt.Rows)
			{
				messages.Add(new ChatMessage(Convert.ToInt32(dr["MessageId"]), dr["MessageBody"].ToString(), dr["UserName"].ToString(), Convert.ToDateTime(dr["MessageDate"])));
			}

			return messages;
		}

		public int GetLastMessage()
		{
			DataTable dt = new DataTable();

			SqlCommand command = new SqlCommand();
			command.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "SPChatMessagesGetLastMessage";

			SqlDataAdapter da = new SqlDataAdapter(command);
			da.Fill(dt);
			return Convert.ToInt32(dt.Rows[0][0]);
		}
	}
}
