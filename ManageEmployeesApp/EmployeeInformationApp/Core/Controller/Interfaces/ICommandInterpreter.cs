namespace EmployeeInformationApp.Core.Controller.Interfaces
{
    public interface ICommandInterpreter
    {
        string InterpretCommand(params string[] data);
    }
}
