
namespace OpenClosePrinciple
{
    public class AccountExecutive : IAccount
    {
        public Employee Create(IPerson person)
        {
            var employee = new Employee();

            employee.FirstName = person.FirstName;
            employee.LastName = person.LastName;
            employee.Email = $"{person.FirstName}{person.LastName}@hpscorp.com";
            employee.isManger = true;
            employee.isExecutive = true;

            return employee;
        }
    }
}
