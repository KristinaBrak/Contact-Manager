using System;
using System.Collections.Generic;
namespace contact_manager
{
    public class Contact
    {
        private string _firstName;
        private string _lastName;
        private ICollection<string> personalPhoneBook;

        public string firstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }


        public Contact(string firstName, string lastName, string phoneNumber)
        {
            personalPhoneBook = new LinkedList<string>();
            _firstName = firstName;
            _lastName = lastName;
            personalPhoneBook.Add(phoneNumber);
        }

        public bool UpdatePhoneNumber(string oldNumber, string newNumber)
        {
            if (HasPhoneNumber(oldNumber))
            {
                personalPhoneBook.Remove(oldNumber);
                personalPhoneBook.Add(newNumber);
                return true;
            }
            return false;
        }

        public void AddPhoneNumber(string phoneNumber)
        {
            if (!HasPhoneNumber(phoneNumber))
            {
                personalPhoneBook.Add(phoneNumber);
            }
        }

        public bool HasPhoneNumber(string phoneNumber)
        {
            foreach (string number in personalPhoneBook)
            {
                if (number.Equals(phoneNumber))
                {
                    return true;
                }
            }
            return false;
        }


        public string toString()
        {
            string text = "";
            foreach (string phoneNumber in personalPhoneBook)
            {
                text += firstName;
                text += ", ";
                text += lastName;
                text += ", ";
                text += phoneNumber;
                text += Environment.NewLine;
            }

            return text;
        }
    }
}