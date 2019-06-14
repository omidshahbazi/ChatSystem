using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySoftCo.ChatSystem.ServerDataLayer
{
    public class Person
    {
        #region Variables
        //
        int personDBID;
        string firstName, middleName, lastName, nickName, email, webPage, mobile, phone, address;
        //
        #endregion

        #region Properties
        //
        public int PersonDBID
        {
            get { return personDBID; }
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
        //
        #endregion

        public Person()
        {
            personDBID = -1;
            firstName = middleName = lastName = nickName = email = webPage = mobile = phone = address = "";
        }

        public Person(string FirstName, string MiddleName, string LastName, string NickName,
            string Email, string WebPage, string Mobile, string Phone, string Address)
            : this()
        {
            firstName = FirstName;
            middleName = MiddleName;
            lastName = LastName;
            nickName = NickName;
            email = Email;
            webPage = WebPage;
            mobile = Mobile;
            phone = Phone;
            address = Address;
        }

        public Person(int PersonDBID, string FirstName, string MiddleName, string LastName, string NickName,
            string Email, string WebPage, string Mobile, string Phone, string Address)
            : this()
        {
            personDBID = PersonDBID;
            firstName = FirstName;
            middleName = MiddleName;
            lastName = LastName;
            nickName = NickName;
            email = Email;
            webPage = WebPage;
            mobile = Mobile;
            phone = Phone;
            address = Address;
        }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
}
