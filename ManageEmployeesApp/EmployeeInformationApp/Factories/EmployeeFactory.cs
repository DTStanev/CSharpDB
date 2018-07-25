using EmployeeInformationApp.Factories.Interfaces;
using Models;
using Models.Interfaces;

namespace EmployeeInformationApp.Factories
{
    public class Employeefactory : IEmployeeFactory
    {
        public IEmployee Create(string firstname, string lastname, decimal salary)
        {
            return new Employee(firstname, lastname, salary);
        }
    }
}
