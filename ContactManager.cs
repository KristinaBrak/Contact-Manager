using System;
using System.Collections.Generic;
namespace contact_manager
{
    class ContactManager : IContactManager<Contact>
    {
        private ICollection<Contact> contacts;
        private ICollection<string> phoneBook;
        private int contactParameters = 3;

        public ContactManager()
        {
            contacts = new LinkedList<Contact>();
            phoneBook = new LinkedList<string>();
        }

        public bool Add(string text)
        {
            string[] values = text.Split(' ');
            if (values.Length == contactParameters)
            {
                Add(values[0].Trim(), values[1].Trim(), values[2].Trim());
                return true;
            }
            return false;
        }

        public bool Add(string name, string lastName, string phoneNumber)
        {
            Contact newContact = FindContact(name, lastName);
            if (!IsPhoneNumberDublicate(phoneNumber))
            {
                if (newContact == null)
                {
                    phoneBook.Add(phoneNumber);

                    newContact = new Contact(name, lastName, phoneNumber);
                    contacts.Add(newContact);
                    return true;
                }
                else
                {
                    phoneBook.Add(phoneNumber);
                    newContact.AddPhoneNumber(phoneNumber);
                    return true;
                }
            }

            return false;

        }

        public bool Update(string updateOption, string firstName, string lastName, string oldValue, string newValue)
        {
            if (oldValue.Length > 0 || newValue.Length > 0)
            {
                Contact contact = FindContact(firstName, lastName);

                if (contact != null && FindContact(contact.firstName, contact.lastName) != null)
                {
                    switch (updateOption)
                    {
                        case "1":

                            if (FindContact(newValue, contact.lastName) == null)
                            {
                                contact.firstName = newValue;
                                return true;
                            }
                            return false;

                        case "2":

                            if (FindContact(contact.firstName, newValue) == null)
                            {
                                contact.lastName = newValue;
                                return true;
                            }
                            return false;

                        case "3":

                            if (!IsPhoneNumberDublicate(newValue))
                            {
                                contact.UpdatePhoneNumber(oldValue, newValue);
                                phoneBook.Remove(oldValue);
                                phoneBook.Add(newValue);
                                return true;
                            }
                            return false;

                        default:
                            break;
                    }
                }
            }

            return false;
        }


        public bool Delete(string name, string lastName)
        {
            Contact deletingContact = FindContact(name, lastName);
            if (deletingContact != null)
            {
                contacts.Remove(deletingContact);
                return true;
            }
            return false;
        }

        private bool IsPhoneNumberDublicate(string phoneNumber)
        {
            foreach (string number in phoneBook)
            {
                if (number.Equals(phoneNumber))
                {
                    return true;
                }
            }
            return false;
        }
        public Contact FindContact(string contactName, string contactLastName)
        {
            foreach (Contact contact in contacts)
            {
                if (contact.firstName.Equals(contactName) && contact.lastName.Equals(contactLastName))
                {
                    return contact;
                }
            }
            return null;
        }

        public string toString()
        {
            string text = "";
            foreach (Contact contact in contacts)
            {
                text += contact.toString();
            }
            return text;
        }
        public void AddContacts(string text)
        {
            string contactSeperator = Environment.NewLine;
            string valueSeperator = ",";
            string[] contacts = text.Split(contactSeperator);
            int valuesInContact = 3;

            for (int i = 0; i < contacts.Length; i++)
            {
                string[] values = contacts[i].Split(valueSeperator);
                if (values.Length == valuesInContact)
                {
                    Add(values[0].Trim(), values[1].Trim(), values[2].Trim());
                }
            }

        }
    }
}