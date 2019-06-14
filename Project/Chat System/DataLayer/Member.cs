using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySoftCo.ChatSystem.DataLayer
{
    public class Member
    {
        #region Variables
        //
        int dBID;
        string firstName, middleName, lastName, nickName, email, webPage, mobile, phone, address, username, password;
        DateTime registerDate, lastLogin;
        bool isActive;
        //
        #endregion

        #region Properties
        //
        public int DBID
        {
            get { return dBID; }
        }

        public string FirstName
        {
            get { return firstName; }
        }

        public string MiddleName
        {
            get { return middleName; }
        }

        public string LastName
        {
            get { return lastName; }
        }

        public string NickName
        {
            get { return nickName; }
        }

        public string Email
        {
            get { return email; }
        }

        public string WebPage
        {
            get { return webPage; }
        }

        public string Mobile
        {
            get { return mobile; }
        }

        public string Phone
        {
            get { return phone; }
        }

        public string Address
        {
            get { return address; }
        }

        public string Username
        {
            get { return username; }
        }

        public string Password
        {
            get { return password; }
        }

        public DateTime RegisterDate
        {
            get { return registerDate; }
        }

        public DateTime LastLogin
        {
            get { return lastLogin; }
        }

        public bool IsActive
        {
            get { return isActive; }
        }
        //
        #endregion

        public Member()
        {
            dBID = -1;
            firstName = middleName = lastName = nickName = email = webPage = mobile = phone = address = username = password = "";
            registerDate = lastLogin = DateTime.MinValue;
            isActive = false;
        }

        public Member(int DBID, string FirstName, string MiddleName, string LastName, string NickName, 
            string Email, string WebPage, string Mobile, string Phone, string Address, string Username, 
            string Password, DateTime RegisterDate, DateTime LastLogin, bool IsActive)
            : this()
        {
            dBID = DBID;
            firstName = FirstName;
            middleName = MiddleName;
            lastName = LastName;
            nickName = NickName;
            email = Email;
            webPage = WebPage;
            mobile = Mobile;
            phone = Phone;
            address = Address;
            username = Username;
            password = Password;
            registerDate = RegisterDate;
            lastLogin = LastLogin;
            isActive = IsActive;
        }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
}
