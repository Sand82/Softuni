namespace OpenClosePrinciple
{
    public class Executive : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAccount Account { get; set; } = new AccountExecutive();
    }
}
