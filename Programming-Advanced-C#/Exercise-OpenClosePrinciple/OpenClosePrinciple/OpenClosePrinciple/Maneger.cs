namespace OpenClosePrinciple
{
    public  class Maneger : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAccount Account { get; set; } = new AccountManager();
        
    }
}
