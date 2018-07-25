using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EmployeeInformationApp
{
    using Data;
    using Core.IO;
    using Core.IO.Interfaces;
    using Core.Controller.Interfaces;
    using Core.Controller;
    using Core;
    using Factories.Interfaces;
    using Factories;
    using Core.Interfaces;
    using Core.Controller.Commands;
    using AutoMapper;
    using EmployeeInformationApp.MappingProfiles;
    using EmployeeInformationServices.Services.Interfaces;
    using EmployeeInformationServices.Services;

    public class StartUp
    {
        public static void Main()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<EmployeeProfile>());

            var service = ConfigureService();

            var engine = service.GetService<IEngine>();
            engine.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<EmployeesDBContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddTransient<IDBInitializerService, DBInitializeService>();

            serviceCollection.AddAutoMapper(conf => conf.AddProfile<EmployeeProfile>());

            serviceCollection.AddTransient<IReader, ConsoleReader>();

            serviceCollection.AddTransient<IWriter, ConsoleWriter>();

            serviceCollection.AddTransient<IEmployeeService, EmployeeService>();

            serviceCollection.AddTransient<IManagerService, ManagerService>();

            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();

            serviceCollection.AddTransient<IEmployeeFactory, Employeefactory>();

            serviceCollection.AddTransient<IEngine, Engine>();

            serviceCollection.AddTransient<SetAddressCommand, SetAddressCommand>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
