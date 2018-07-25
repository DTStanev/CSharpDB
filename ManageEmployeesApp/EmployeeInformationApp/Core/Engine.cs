using EmployeeInformationApp.Core.Controller.Interfaces;
using EmployeeInformationApp.Core.Interfaces;
using System;
using EmployeeInformationApp.Core.IO.Interfaces;
using EmployeeInformationApp.Core.Controller.Commands;
using EmployeeInformationApp.Core.IO;
using EmployeeInformationServices.Services.Interfaces;

namespace EmployeeInformationApp.Core
{
    //Read the input from the user and pass it to the CommandInterpreter

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IDBInitializerService dBInitializerService;

        public Engine(ICommandInterpreter commandInterpreter, IWriter writer, IReader reader, IDBInitializerService dBInitializerService)
        {
            this.commandInterpreter = commandInterpreter;
            this.writer = writer;
            this.reader = reader;
            this.dBInitializerService = dBInitializerService;
        }

        public void Run()
        {
            this.dBInitializerService.InitializeDb();

            this.writer.WriteLine(string.Format(OutputMsg.AvailableCommands,Environment.NewLine));

            foreach (var cmd in (AvailableCommands[])Enum.GetValues(typeof(AvailableCommands)))
            {
                this.writer.WriteLine(cmd.ToString());
            }

            while (true)
            {
                this.writer.Write(OutputMsg.InsertCommand);

                var input = reader.Read().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    var result = commandInterpreter.InterpretCommand(input);
                    writer.WriteLine(result);
                }
                catch (InvalidOperationException ioe)
                {
                    writer.WriteLine(ioe.Message);    
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }                
            }
        }
    }
}