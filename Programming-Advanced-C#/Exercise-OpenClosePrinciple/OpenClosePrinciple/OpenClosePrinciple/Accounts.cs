
namespace OpenClosePrinciple
{
    public class Accounts : IAccount
    {
        public Employee Create(IPerson person)
        {
            var employee = new Employee();

            employee.FirstName = person.FirstName;
            employee.LastName = person.LastName;
            employee.Email = $"{person.FirstName.Substring(0, 1)}{person.LastName}@hps.com";

            return employee;
        }
    }
}
