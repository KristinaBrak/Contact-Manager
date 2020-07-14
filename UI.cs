using System;
using System.Collections.Generic;

namespace contact_manager
{
    public class UI
    {
        public static void ShowMenu()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Select action");
            Console.WriteLine("1. Add contact");
            Console.WriteLine("2. Update contact");
            Console.WriteLine("3. Delete contact");
            Console.WriteLine("4. View all contacts");
            Console.WriteLine("Any key to exit");

        }

        public static void ShowAddActionMessage()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Write name, last name and phone number");
            Console.WriteLine("seperated by space.");
        }

        public static void ShowRequestForContactUpdate()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Which contact do you want update?");
            Console.WriteLine("Enter name and last name");
            Console.WriteLine("seperated by space");
        }

        public static void ShowUpdateOptions()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("What do you want to update?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Last name");
            Console.WriteLine("3. Phone number");
        }
        public static void ShowRequestForOldValue()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("which old value should be replaced?");
        }
        public static void ShowRequestForNewValue()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("what should new value be?");
        }
        public static void ShowRequestForContactDelete()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Which contact do you want to delete?");
            Console.WriteLine("Enter name and last name");
            Console.WriteLine("seperated by space");
        }
        public static void ShowIncorrectInputMessage()
        {
            Console.WriteLine("Incorrect input");
        }

        public static void ViewAll(string text)
        {
            Console.WriteLine("---------------------------------------");
            string[] lines = text.Split(Environment.NewLine);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}