using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeInformationApp.Core.Controller
{
    using Interfaces;
    using IO;

    //Find the inserted command in the assembly and execute it

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string InterpretCommand(params string[] data)
        {
            var assembly = Assembly.GetCallingAssembly();

            var commandName = data[0];

            var type = assembly.GetTypes().FirstOrDefault(t => t.Name == commandName + OutputMsg.StringCommand);

            if (type == null)
            {
                throw new InvalidOperationException(OutputMsg.InvalidCommand);
            }

            if (!typeof(IExecutable).IsAssignableFrom(type))
            {
                throw new ArgumentException(OutputMsg.TheCommandIsNotIExecutable);
            }

            var constructor = type.GetConstructors().First();

            var ctorParameters = constructor.GetParameters().Select(p => p.ParameterType).ToArray();

            var services = ctorParameters.Select(serviceProvider.GetService).ToArray();

            var command = (IExecutable)constructor.Invoke(services);

            var args = data.Skip(1).ToArray();

            var result = command.Execute(args);

            return result;
        }
    }
}
