using Models.Interfaces;

namespace EmployeeInformationApp.Factories.Interfaces
{
    public interface IEmployeeFactory
    {
        IEmployee Create(string firstName, string lastName, decimal salary);
    }
}
