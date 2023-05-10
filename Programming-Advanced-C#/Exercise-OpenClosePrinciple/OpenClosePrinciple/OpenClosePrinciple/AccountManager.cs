
namespace OpenClosePrinciple
{
    public class AccountManager : IAccount
    {
        public Employee Create(IPerson person)
        {
            var employee = new Employee();  

            employee.FirstName = person.FirstName;
            employee.LastName = person.LastName;
            employee.Email = $"{person.FirstName}{person.LastName}@hpscorp.com";
            employee.isManger = true;

            return employee;
        }
    }
}
