using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BinarySoftCo.Client_Site
{
    public static class UserSession
    {
        private static ChatMember myMember = null;
        private static int currentChatWithMemberID = -1;
        private static List<ChatMember> members = new List<ChatMember>();

        public static ChatMember MyMember
        {
            get { return myMember; }
            set { myMember = value; }
        }

        public static int CurrentChatWithMemberID
        {
            get { return currentChatWithMemberID; }
            set { currentChatWithMemberID = value; }
        }

        public static List<ChatMember> Members
        {
            get { return members; }
            set { members = value; }
        }
    }
}