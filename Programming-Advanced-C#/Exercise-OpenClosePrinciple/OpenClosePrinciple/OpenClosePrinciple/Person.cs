namespace OpenClosePrinciple
{
    public class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAccount Account { get; set; } = new Accounts();
    }
}
