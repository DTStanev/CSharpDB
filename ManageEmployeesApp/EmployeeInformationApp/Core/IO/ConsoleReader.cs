using EmployeeInformationApp.Core.IO.Interfaces;
using System;

namespace EmployeeInformationApp.Core.IO
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
