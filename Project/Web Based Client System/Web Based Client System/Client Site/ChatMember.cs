using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BinarySoftCo.Client_Site
{
    public class ChatMember
    {
        private int dBID;
        private string firstName, lastName;
        private bool gender;

        public int DBID
        {
            get { return dBID; }
        }

        public string FirstName
        {
            get { return firstName; }
        }

        public string LastName
        {
            get { return lastName; }
        }

        public string DisplayName
        {
            get { return firstName + " " + lastName; }
        }

        public bool Gender
        {
            get { return gender; }
        }

        public ChatMember(int DBID, string FirstName, string LastName, bool Gender)
        {
            dBID = DBID;
            firstName = FirstName;
            lastName = LastName;
            gender = Gender;
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}