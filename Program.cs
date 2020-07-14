using System;

namespace contact_manager
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactManager manager = new ContactManager();
            Persistence persistence = new Persistence("D:\\coding\\dotNet\\contact_manager\\contacts.csv");
            manager.AddContacts(persistence.Load());
            Console.WriteLine("--------------------------");

            while (true)
            {

                UI.ShowMenu();
                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":

                        UI.ShowAddActionMessage();
                        string text = Console.ReadLine();
                        bool isAdded = manager.Add(text);

                        if (!isAdded)
                        {
                            Console.WriteLine("Incorrect input");
                        }
                        break;

                    case "2"://update contact

                        UI.ShowRequestForContactUpdate();
                        //ex. James Bond
                        string fullName = Console.ReadLine();

                        string[] nameAndLastName = SplitFullName(fullName.Trim());

                        if (nameAndLastName == null)
                        {
                            UI.ShowIncorrectInputMessage();
                            break;
                        }

                        string firstName = nameAndLastName[0];
                        string lastName = nameAndLastName[1];

                        UI.ShowUpdateOptions();
                        //1 name, 2 - lastname, 3 phone
                        string option = Console.ReadLine();

                        UI.ShowRequestForOldValue();
                        string oldValue = Console.ReadLine();

                        UI.ShowRequestForNewValue();
                        string newValue = Console.ReadLine();

                        if (!manager.Update(option, firstName.Trim(), lastName.Trim(), oldValue, newValue))
                        {
                            UI.ShowIncorrectInputMessage();
                        }
                        break;

                    case "3":
                        UI.ShowRequestForContactDelete();
                        //ex James Bond
                        String nameFull = Console.ReadLine();
                        string[] names = SplitFullName(nameFull);

                        if (names == null)
                        {
                            UI.ShowIncorrectInputMessage();
                            break;
                        }

                        string name = names[0];
                        string surName = names[1];

                        if (!manager.Delete(name, surName))
                        {
                            UI.ShowIncorrectInputMessage();
                            break;
                        }

                        break;

                    case "4":
                        UI.ViewAll(manager.toString());
                        //view all contacts
                        break;

                    default:
                        persistence.Save(manager.toString());
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public static string[] SplitFullName(string text)
        {
            string[] nameAndLastName = text.Split(" ");
            int wordCount = 2; //fullName consists of two words

            if (nameAndLastName.Length != wordCount)
            {
                return null;

            }
            return nameAndLastName;

        }

    }
}
