using System;

namespace OpenClosePrinciple // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var persons = CreateStaff();

            var employees = new List<Employee>();

            var account = new Accounts();

            foreach (var person in persons)
            {
                var employee = person.Account.Create(person);
                employees.Add(employee);
            }

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.Email}" +
                    $", Is Manager: {emp.isManger}, Is Executive: {emp.isExecutive}");
            }
        }

        private static List<IPerson> CreateStaff()
        {
            return new List<IPerson>()
            {
                new Maneger(){ FirstName = "Sand", LastName = "Stefanov"},
                new Executive(){ FirstName = "Mish", LastName = "Stefanov"},
                new Person(){ FirstName = "Lub", LastName = "Stefanov"},
                new Person(){ FirstName = "Mim", LastName = "Stefanova"},
            };
        }
    }
}
