using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Ajax;
using System.Text;
using System.Web.Caching;

namespace SampleChat
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class Chat : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlTableCell TRROOMS;
		protected System.Web.UI.HtmlControls.HtmlTableCell TRCHAT;
		protected System.Web.UI.HtmlControls.HtmlInputHidden totDivs;
		protected System.Data.DataSet dSChat;
		protected System.Data.DataTable Rooms;
		protected System.Data.DataTable User;
		protected System.Data.DataTable Messages;
		protected System.Data.DataColumn RoomID;
		protected System.Data.DataColumn RoomName;
		protected System.Data.DataColumn UserID;
		protected System.Data.DataColumn UserName;
		protected System.Data.DataColumn MessageRoomID;
		protected System.Data.DataColumn MessageUserID;
		protected System.Data.DataColumn Message;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Public_Rooms;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Private_Rooms;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Users;
		protected System.Data.DataColumn dataColumn1;
		protected System.Data.DataTable PrivateRoomUsers;
		protected System.Data.DataColumn PrivateRoomID;
		protected System.Data.DataColumn PrivateUserID;
		protected System.Web.UI.HtmlControls.HtmlTableCell TRUSERS;
		private void Page_Load(object sender, System.EventArgs e)
		{
			Ajax.Utility.RegisterTypeForAjax(typeof(Chat));
			if(!Page.IsPostBack)
			{
				AddUsers();
				AddRooms();
				if(this.Cache["dSChat"]==null)
				{
					this.Cache.Add("dSChat",dSChat,null,Cache.NoAbsoluteExpiration,Cache.NoSlidingExpiration,CacheItemPriority.High,null);
				}
			}
			FillPublicRooms();
			this.Users.InnerHtml=FillUsers();
		}
		[Ajax.AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
		public Hashtable getMessageHash(string RoomIDs)
		{
			SetDataSet();
			Hashtable ht=new Hashtable();
			ht["-TotUsers-"]=FillUsers();
			ht["-PrivateRooms-"]=FillPrivateRooms();
			string []split=RoomIDs.Split(',');
			for(int j=0;j<split.Length-1;j++)
			{
				ht[split[j]]=dSChat.Tables[2].Select("MessageRoomID='"+split[j]+"'");
			}
			StringBuilder sb=new StringBuilder();
			Ajax.JSON.DefaultConverter.ToJSON(ref sb,ht);
			sb.ToString();
			return ht;
		
		}

		[Ajax.AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
		public string PostMessage(string RoomID,string Message)
		{
			SetDataSet();
			dSChat.Tables[2].Rows.Add(new object[]{RoomID,Session["s_userid"],Session["s_Name"].ToString()+" : "+Message});
			return Session["s_Name"] as string + " : "+Message;
		}
		[Ajax.AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
		public string CreatePrivateRooms(string RoomID)
		{
			SetDataSet();
			try
			{
				dSChat.Tables[0].Rows.Add(new Object[]{RoomID.Replace(" ","_"),RoomID,Session["s_userid"].ToString()});
				dSChat.Tables[3].Rows.Add(new Object[]{RoomID.Replace(" ","_"),Session["s_userid"].ToString()});
				return string.Format("<div id=\"{0}\" name=\"{0}\" ondblclick=\"{1}\" title=\"Double click to Open\">{2}</div>",RoomID.Replace(" ","_"),"addChatRoom(this)",RoomID);
			}
			catch
			{
			}
			return null;

		}
		[Ajax.AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
		public void AddUsersPrivateRooms(string RoomID,string UserID)
		{
			SetDataSet();
			try
			{
				dSChat.Tables[3].Rows.Add(new Object[]{RoomID,UserID});
			}
			catch
			{
			}
		}
		[Ajax.AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
		public string FillPrivateRooms()
		{
			StringBuilder StrBuilder=new StringBuilder();
			try
			{
				DataRow []Privaterooms=dSChat.Tables[3].Select("PrivateUserID='"+Session["s_userid"] as string+"'");
				foreach(DataRow row in Privaterooms)
				{
					DataRow Dr=dSChat.Tables[0].Rows.Find(row[0]);
					if(Dr!=null)
					{
						StrBuilder.AppendFormat("<div id=\"{0}\" name=\"{0}\" ondblclick=\"{1}\" title=\"Double click to Open\">{2}</div>",Dr[0],"addChatRoom(this)",Dr[1]);
					}
				}
				return StrBuilder.ToString();
			}
			catch
			{
			}
			return null;
		}
		[Ajax.AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
		public string FillUsers()
		{
			StringBuilder StrBuilder=new StringBuilder();
			foreach(DataRow Dr in this.dSChat.Tables[1].Rows)
			{
				StrBuilder.AppendFormat("<div id=\"{0}\" name=\"{0}\">{1}</div>",Dr[0],Dr[1]);
			}
			return StrBuilder.ToString();	
		}
		public void FillPublicRooms()
		{
			StringBuilder StrBuilder=new StringBuilder();
			foreach(DataRow Dr in this.dSChat.Tables[0].Rows)
			{
				if(Dr[2].ToString()=="Public")
				{
					StrBuilder.AppendFormat("<div id=\"{0}\" name=\"{0}\" ondblclick=\"{1}\" title=\"Double click to Open\" style=\"cursor:hand\">{2}</div>",Dr[0],"addChatRoom(this)",Dr[1]);
				}
			}
			this.Public_Rooms.InnerHtml=StrBuilder.ToString();
		}
		public void SetDataSet()
		{
			if(System.Web.HttpContext.Current.Cache["dSChat"]!=null)
			{
				dSChat= System.Web.HttpContext.Current.Cache["dSChat"] as DataSet;
			}
		}
		public void AddUsers()
		{
			SetDataSet();
			if(dSChat.Tables[1].Rows.Find(new Object[]{Session["s_userid"]})==null)
			{
				dSChat.Tables[1].Rows.Add(new object[]{Session["s_userid"],Session["s_Name"]});
			}
		}
		public void AddRooms()
		{
			SetDataSet();
			if(dSChat.Tables[0].Rows.Find(new Object[]{"Room-1"})==null)
			{
				dSChat.Tables[0].Rows.Add(new object[]{"Room-1","Room1","Public"});
				dSChat.Tables[0].Rows.Add(new object[]{"Room-2","Room2","Public"});
				dSChat.Tables[0].Rows.Add(new object[]{"Room-3","Room3","Public"});
				dSChat.Tables[0].Rows.Add(new object[]{"Room-4","Room4","Public"});
			}
		}
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dSChat = new System.Data.DataSet();
			this.Rooms = new System.Data.DataTable();
			this.RoomID = new System.Data.DataColumn();
			this.RoomName = new System.Data.DataColumn();
			this.dataColumn1 = new System.Data.DataColumn();
			this.User = new System.Data.DataTable();
			this.UserID = new System.Data.DataColumn();
			this.UserName = new System.Data.DataColumn();
			this.Messages = new System.Data.DataTable();
			this.MessageRoomID = new System.Data.DataColumn();
			this.MessageUserID = new System.Data.DataColumn();
			this.Message = new System.Data.DataColumn();
			this.PrivateRoomUsers = new System.Data.DataTable();
			this.PrivateRoomID = new System.Data.DataColumn();
			this.PrivateUserID = new System.Data.DataColumn();
			((System.ComponentModel.ISupportInitialize)(this.dSChat)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Rooms)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.User)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Messages)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PrivateRoomUsers)).BeginInit();
			// 
			// dSChat
			// 
			this.dSChat.DataSetName = "NewDataSet";
			this.dSChat.Locale = new System.Globalization.CultureInfo("en-US");
			this.dSChat.Tables.AddRange(new System.Data.DataTable[] {
																		this.Rooms,
																		this.User,
																		this.Messages,
																		this.PrivateRoomUsers});
			// 
			// Rooms
			// 
			this.Rooms.Columns.AddRange(new System.Data.DataColumn[] {
																		 this.RoomID,
																		 this.RoomName,
																		 this.dataColumn1});
			this.Rooms.Constraints.AddRange(new System.Data.Constraint[] {
																			 new System.Data.UniqueConstraint("Constraint1", new string[] {
																																			  "RoomID"}, true)});
			this.Rooms.PrimaryKey = new System.Data.DataColumn[] {
																	 this.RoomID};
			this.Rooms.TableName = "Rooms";
			// 
			// RoomID
			// 
			this.RoomID.AllowDBNull = false;
			this.RoomID.ColumnName = "RoomID";
			// 
			// RoomName
			// 
			this.RoomName.ColumnName = "RoomName";
			// 
			// dataColumn1
			// 
			this.dataColumn1.AllowDBNull = false;
			this.dataColumn1.ColumnName = "RoomOwner";
			// 
			// User
			// 
			this.User.Columns.AddRange(new System.Data.DataColumn[] {
																		this.UserID,
																		this.UserName});
			this.User.Constraints.AddRange(new System.Data.Constraint[] {
																			new System.Data.UniqueConstraint("Constraint1", new string[] {
																																			 "UserID"}, true)});
			this.User.PrimaryKey = new System.Data.DataColumn[] {
																	this.UserID};
			this.User.TableName = "User";
			// 
			// UserID
			// 
			this.UserID.AllowDBNull = false;
			this.UserID.ColumnName = "UserID";
			// 
			// UserName
			// 
			this.UserName.ColumnName = "UserName";
			// 
			// Messages
			// 
			this.Messages.Columns.AddRange(new System.Data.DataColumn[] {
																			this.MessageRoomID,
																			this.MessageUserID,
																			this.Message});
			this.Messages.Constraints.AddRange(new System.Data.Constraint[] {
																				new System.Data.ForeignKeyConstraint("RlnRoomMessage", "Rooms", new string[] {
																																								 "RoomID"}, new string[] {
																																															 "MessageRoomID"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade),
																				new System.Data.ForeignKeyConstraint("RlnUsermessage", "User", new string[] {
																																								"UserID"}, new string[] {
																																															"MessageUserID"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade)});
			this.Messages.TableName = "Messages";
			// 
			// MessageRoomID
			// 
			this.MessageRoomID.ColumnName = "MessageRoomID";
			// 
			// MessageUserID
			// 
			this.MessageUserID.ColumnName = "MessageUserID";
			// 
			// Message
			// 
			this.Message.ColumnName = "Message";
			// 
			// PrivateRoomUsers
			// 
			this.PrivateRoomUsers.Columns.AddRange(new System.Data.DataColumn[] {
																					this.PrivateRoomID,
																					this.PrivateUserID});
			this.PrivateRoomUsers.TableName = "PrivateRoomUsers";
			// 
			// PrivateRoomID
			// 
			this.PrivateRoomID.ColumnName = "PrivateRoomID";
			// 
			// PrivateUserID
			// 
			this.PrivateUserID.ColumnName = "PrivateUserID";
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.dSChat)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Rooms)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.User)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Messages)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PrivateRoomUsers)).EndInit();

		}
		#endregion
	}
}
