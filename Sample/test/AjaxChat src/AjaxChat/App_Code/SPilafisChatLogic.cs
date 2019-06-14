using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Threading;
using System.Globalization;

namespace SpilafisChatLogic
{
    /// <summary>
    /// License and Disclaimer: All the intructions, code, html and everything presented with this solution is provided 'as is' with no warranties what so ever.
	/// The only condition for you to use this software is that you keep the link to http://www.spilafis.com.ar in the chat page as provided. Please support freeware keeping the link and clicking on my sponsors.
	/// Thank you!
    /// </summary>
    public class Business
    {
        public Business()
        {
        }

        public static User CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session["ChatCurrentUser"] == null)
                    HttpContext.Current.Session["ChatCurrentUser"] = new User();

                return (User)HttpContext.Current.Session["ChatCurrentUser"];
            }
            set
            {
                HttpContext.Current.Session["ChatCurrentUser"] = value;
            }
        }

        public static App CurrentApp
        {
            get
            {
                if (HttpContext.Current.Application["ChatCurrentApp"] == null)
                    HttpContext.Current.Application["ChatCurrentApp"] = new App();

                return (App)HttpContext.Current.Application["ChatCurrentApp"];
            }
            set
            {
                HttpContext.Current.Application["ChatCurrentApp"] = value;
            }
        }
    }

    public class User
    {
        #region Private Members

        private bool m_ajax_chat_counted;
        private string m_ajax_chat_user_name;
        private int m_ajax_chat_last_read_id;

        #endregion

        public User()
        {
            m_ajax_chat_counted = false;
            m_ajax_chat_user_name = "";
            m_ajax_chat_last_read_id = -1;
        }

        #region Properties

        public bool AjaxChatCounted
        {
            get { return m_ajax_chat_counted; }
            set { m_ajax_chat_counted = value; }
        }

        public string AjaxChatUserName
        {
            get { return m_ajax_chat_user_name; }
            set { m_ajax_chat_user_name = value; }
        }

        public int AjaxChatLastReadId
        {
            get { return m_ajax_chat_last_read_id; }
            set { m_ajax_chat_last_read_id = value; }
        }

        #endregion

    }


    public class App
    {
        #region Private Members

        private int m_ajax_chat_users_r;
        private Hashtable m_ajax_chat_users_w;
        private Hashtable m_ajax_chat_users_w_last_activity;
        private ArrayList m_ajax_chat;

        #endregion


        public App()
        {
            m_ajax_chat_users_w = new Hashtable();
            m_ajax_chat_users_w_last_activity = new Hashtable();
            m_ajax_chat = new ArrayList();
        }


        #region Properties

        public int AjaxChatUsersR
        {
            get { return m_ajax_chat_users_r; }
            set { m_ajax_chat_users_r = value; }
        }

        public Hashtable AjaxChatUsersW
        {
            get { return m_ajax_chat_users_w; }
            set { m_ajax_chat_users_w = value; }
        }

        public Hashtable AjaxChatUsersWLastActivity
        {
            get { return m_ajax_chat_users_w_last_activity; }
            set { m_ajax_chat_users_w_last_activity = value; }
        }

        public ArrayList AjaxChat
        {
            get { return m_ajax_chat; }
            set { m_ajax_chat = value; }
        }

        #endregion
    }


    public class Chat
    {
        #region Constants

        public static int MaxMessageLength = 100;
        public static int MaxChatLines = 50;
        public static int MaxLoggedInUsers = 5;
        public static string[] BadWords = { "asshole", "boludo"}; // Add your bad word dictionary here

        #endregion

        public Chat()
        {
        }

        #region Methods

        private static void IncrementUsersReading()
        {
            Business.CurrentApp.AjaxChatUsersR = GetIntUsersReading() + 1;
        }

        private static int GetIntUsersReading()
        {
            return Business.CurrentApp.AjaxChatUsersR;
        }

        private static int GetId(string message)
        {
            return Convert.ToInt32(message.Split('-')[0]);
        }

        private static string GetMessage(string message)
        {
            return message.Split('-')[1];
        }

        private static string GetNextId(ArrayList ajax_chat_list)
        {
            int id = GetMaxId(ajax_chat_list);
            if (id < Int32.MaxValue)
                id++;
            else
                id = 0;
            return id.ToString() + "-";
        }

        private static int GetMaxId(ArrayList ajax_chat_list)
        {
            if (ajax_chat_list.Count > 0)
                return GetId(ajax_chat_list[0].ToString());
            else
                return 0;
        }

        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public static string GetUserName()
        {
            if (Business.CurrentUser.AjaxChatUserName == "")
                Chat.GetNextUserName();
            return Business.CurrentUser.AjaxChatUserName;
        }

        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public static string GetNextUserName()
        {
            string user_name = "";
            // Count user reading if not counted yet
            if (!Business.CurrentUser.AjaxChatCounted)
            {
                Business.CurrentUser.AjaxChatCounted = true;
                IncrementUsersReading();  // Is decremented in session end
            }
            else
            {
                if (Business.CurrentUser.AjaxChatUserName != null && Business.CurrentUser.AjaxChatUserName != "")
                    return Business.CurrentUser.AjaxChatUserName;
            }

            int user_number = Business.CurrentApp.AjaxChatUsersW.Count + 1;
            // If user may log in 
            if (user_number <= MaxLoggedInUsers)
            {
                // Get first not used guest user name
                while (Business.CurrentApp.AjaxChatUsersW["ChatGuest" + user_number.ToString()] != null)
                {
                    if (user_number < int.MaxValue)
                        user_number++;
                    else
                        return "";
                }

                // Add to writing users list
                Business.CurrentApp.AjaxChatUsersW.Add("Guest" + user_number.ToString(), 1);

                // Save user name to session
                Business.CurrentUser.AjaxChatUserName = "Guest" + user_number.ToString();

                UpdateUserLastActivityTime();
            }
            return user_name;
        }

        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public static void ChangeUserName(string tentative_name)
        {
            if (Business.CurrentUser.AjaxChatUserName == "")
            {
                int user_number = Business.CurrentApp.AjaxChatUsersW.Count + 1;
                // If user may not log in inform
                if (user_number > MaxLoggedInUsers)
                    throw new Exception("Max. number of writing users reached. You'll be inform when someone leaves.");
            }

            tentative_name = tentative_name.Trim();
            if (tentative_name == "")
                throw new Exception("You must enter a user name to be able to chat.");
            if (tentative_name.IndexOf('-') >= 0)
                throw new Exception("Character '-' is not allowed in the user name.");
            if (tentative_name.Length > 10)
                tentative_name = tentative_name.Substring(0, 10);

            // If exists inform
            if (Business.CurrentApp.AjaxChatUsersW[tentative_name] != null)
                throw new Exception("User name already in use. Please enter another.");

            // Remove old user name from the list
            // Add to writing users list
            ChangeUserNameInWList(tentative_name);

            // Save user name to session
            Business.CurrentUser.AjaxChatUserName = tentative_name;

            UpdateUserLastActivityTime();
        }

        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public static void ChangeUserNameInWList(string new_name)
        {
            // If it already had a user name then remove from writing users
            if (Business.CurrentUser.AjaxChatUserName != null && Business.CurrentUser.AjaxChatUserName != "")
            {
                Business.CurrentApp.AjaxChatUsersW.Remove(Business.CurrentUser.AjaxChatUserName);

                // If it had a saved last activity time remove it
                Business.CurrentApp.AjaxChatUsersWLastActivity.Remove(Business.CurrentUser.AjaxChatUserName);

                // Add to writing users list
                Business.CurrentApp.AjaxChatUsersW.Add(new_name, 1);
                // NOTE: It is not necessary to add it to the last activity table because it will be added after this
            }
        }

        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public static void Post(string message)
        {
            // Cut max message length
            message = message.Trim();
            if (message.Length > MaxMessageLength)
                message = message.Substring(0, MaxMessageLength);

            if (message != "")
            {
                // Add time and nickname to identify message
                string message_head = Business.CurrentUser.AjaxChatUserName + " says: ";
                message = message_head + message;

                ValidateMessage(Business.CurrentApp.AjaxChat, message);

                // Add message id
                message = GetNextId(Business.CurrentApp.AjaxChat) + message;

                // Insert new message
                Business.CurrentApp.AjaxChat.Insert(0, message);

                // Delete lines after MaxChatLines
                while (Business.CurrentApp.AjaxChat.Count > MaxChatLines)
                    Business.CurrentApp.AjaxChat.RemoveAt(Business.CurrentApp.AjaxChat.Count - 1);

                UpdateUserLastActivityTime();
            }
        }

        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public static void ValidateMessage(ArrayList ajax_chat_list, string message)
        {
            int index;
            // Create array list of chat without message numbers
            ArrayList ajax_chat_nonumbers = new ArrayList();

            for (index = 0; index < ajax_chat_list.Count; index++)
                ajax_chat_nonumbers.Add(ajax_chat_list[index].ToString().Split('-')[1]);

            // Check for spam
            if (ajax_chat_nonumbers.Contains(message))
                throw new Exception("Please no spam...");

            // Create message words array
            string[] m_w = message.Replace("\n", " ").Replace("\r", "").Split(' ');
            ArrayList message_words = new ArrayList();
            for (index = 0; index < m_w.Length; index++)
                message_words.Add(m_w[index]);

            // Check for bad words
            for (index = 0; index < BadWords.Length; index++)
                if (message_words.Contains(BadWords[index]))
                    throw new Exception("Please no bad words...");
        }

        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public static void UpdateUserLastActivityTime()
        {
            if (Business.CurrentUser.AjaxChatUserName != null && Business.CurrentUser.AjaxChatUserName != "")
                UpdateUserLastActivityTime(Business.CurrentApp.AjaxChatUsersWLastActivity);
        }

        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public static void UpdateUserLastActivityTime(Hashtable ajax_chat_users_w_last_activity)
        {
            if (ajax_chat_users_w_last_activity[Business.CurrentUser.AjaxChatUserName] == null)
                ajax_chat_users_w_last_activity.Add(Business.CurrentUser.AjaxChatUserName, DateTime.Now);
            else
                ajax_chat_users_w_last_activity[Business.CurrentUser.AjaxChatUserName] = DateTime.Now;
        }

        public static DataTable GetUsersDataSource()
        {
            // Create data source
            DataTable dtSource = new DataTable();
            dtSource.Columns.Add(new DataColumn("ChatUsers"));
            dtSource.Columns.Add(new DataColumn("ChatLastActivity"));
            DataRow drSource;
            DateTime last_activity;

            if (Business.CurrentApp.AjaxChatUsersW.Keys.Count > 0)
            {
                // Add list of users to datasource
                foreach (object key in Business.CurrentApp.AjaxChatUsersW.Keys)
                {
                    drSource = dtSource.NewRow();
                    drSource["ChatUsers"] = key.ToString();
                    // Get last activity time
                    if (Business.CurrentApp.AjaxChatUsersWLastActivity[key] != null)
                    {
                        last_activity = (DateTime)Business.CurrentApp.AjaxChatUsersWLastActivity[key];
                        // Convert to GMT time
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                        string dateFormat = CultureInfo.InvariantCulture.DateTimeFormat.RFC1123Pattern.Replace("'GMT'", "zzz");
                        string dateString = last_activity.ToString(dateFormat);
                        drSource["ChatLastActivity"] = dateString;

                    }
                    else
                        drSource["ChatLastActivity"] = "<none>";
                    dtSource.Rows.Add(drSource);
                }
            }
            else
            {
                drSource = dtSource.NewRow();
                drSource["ChatUsers"] = "<none>";
                drSource["ChatLastActivity"] = "<none>";
                dtSource.Rows.Add(drSource);
            }


            // Sort by user name
            dtSource.DefaultView.Sort = "ChatUsers";

            return dtSource;
        }

        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public static string Read()
        {
            int id;
            int max_id = 0;
            string message;

            // Create chat list if not created
            System.Text.StringBuilder chat = new System.Text.StringBuilder();

            // Get chat from application level
            ArrayList ajax_chat_list = Business.CurrentApp.AjaxChat;

            // Get last read id from user session if already saved
            int last_read_id = Business.CurrentUser.AjaxChatLastReadId;

            // Write it to a string
            int index;
            ArrayList chat_arr = new ArrayList();
            for (index = 0; index < ajax_chat_list.Count; index++)
            {
                id = GetId(ajax_chat_list[index].ToString());
                if (index == 0)
                    max_id = id;
                message = GetMessage(ajax_chat_list[index].ToString());

                // If last read message read reached then stop reading
                if (id == last_read_id)
                    break;
                // Note: Why not "<="?
                //       Because "<=" may cause stop of reading
                // Example: If last message read is 9, and then the id 10 message was sent
                //          and then the id message 1 was sent, first message read would be id 1 that is < than 9
                //          and wouldn't be read although it should be
                //          (if read, comparing just equal, then id 10 would be read and in 9 it would stop)

                chat_arr.Add(System.Web.HttpUtility.HtmlEncode(message) + "\n");
                //chat.Append(Server.HtmlEncode(message) + "\n");
            }

            // Build inverted order chat string
            for (index = chat_arr.Count - 1; index >= 0; index--)
                chat.Append(chat_arr[index].ToString());

            // Set max_id as new last_read_id to user session
            Business.CurrentUser.AjaxChatLastReadId = max_id;

            UpdateUserLastActivityTime();

            // Return chat string to user with max_id to set as new last_read_id
            return chat.ToString();
        }

        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public static string GetUsersWriting()
        {
            return Business.CurrentApp.AjaxChatUsersW.Count.ToString();
        }

        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public static string GetUsersReading()
        {
            return GetIntUsersReading().ToString();
        }

        #endregion
    }

}

