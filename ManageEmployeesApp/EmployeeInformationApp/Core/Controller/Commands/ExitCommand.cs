using System;
using System.Threading;

namespace EmployeeInformationApp.Core.Controller.Commands
{
    using Interfaces;
    using IO;
    using IO.Interfaces;

    //Exit the programm 

    public class ExitCommand : IExecutable
    {
        private readonly IWriter writer;

        public ExitCommand(IWriter writer)
        {
            this.writer = writer;
        }

        public string Execute(params string[] employeeInfo)
        {
            writer.WriteLine(OutputMsg.ShutingDownApp);

            for (int i = 5; i >= 1; i--)
            {
                this.writer.WriteLine(i);
                Thread.Sleep(1000);
            }

            writer.WriteLine(OutputMsg.ShutDownThankYouMsg);
            Environment.Exit(0);

            return string.Empty;
        }
    }
}
