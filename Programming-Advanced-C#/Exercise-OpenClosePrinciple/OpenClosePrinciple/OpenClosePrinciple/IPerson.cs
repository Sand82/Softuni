namespace OpenClosePrinciple
{
    public interface IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAccount Account { get; set; }
    }
}
