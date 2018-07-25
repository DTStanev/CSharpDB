namespace EmployeeInformationApp.Core.Controller.Interfaces
{
    public interface IExecutable
    {
        string Execute(params string[] employeeInfo);
    }
}
