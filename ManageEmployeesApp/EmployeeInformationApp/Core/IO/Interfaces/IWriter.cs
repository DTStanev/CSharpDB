namespace EmployeeInformationApp.Core.IO.Interfaces
{
    public interface IWriter
    {
        void Write(string input);

        void WriteLine(string input);

        void WriteLine(int input);
    }
}
