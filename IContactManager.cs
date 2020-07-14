namespace contact_manager
{
    public interface IContactManager<Contact>
    {
        bool Add(string name, string lastName, string phoneNumber);
        bool Update(string updateOption, string firstName, string lastName, string oldValue, string newValue);
        bool Delete(string name, string lastName);
    }
}