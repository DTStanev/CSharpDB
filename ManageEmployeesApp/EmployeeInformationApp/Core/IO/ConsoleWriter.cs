using EmployeeInformationApp.Core.IO.Interfaces;
using System;

namespace EmployeeInformationApp.Core.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string input)
        {
            Console.Write(input);
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }

        public void WriteLine(int input)
        {
            Console.WriteLine(input);
        }
    }
}
