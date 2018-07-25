namespace EmployeeInformationApp.Core.Controller.Commands
{
    using IO;
    using Factories.Interfaces;
    using Models;
    using EmployeeInformationServices.Services.Interfaces;
    using System;

    //Adding new employee to the database 

    public class AddEmployeeCommand : Command
    {
        private readonly IEmployeeFactory employeeFactory;
        
        public AddEmployeeCommand(IEmployeeService employeeService, IEmployeeFactory employeeFactory)
            :base(employeeService)
        {            
            this.employeeFactory = employeeFactory;
        }

        public override string Execute(params string[] employeeInfo)
        {
            if (employeeInfo.Length == 3 && decimal.TryParse(employeeInfo[2], out var salary))
            {
                var firstName = employeeInfo[0];
                var lastName = employeeInfo[1];

                var employee = (Employee)this.employeeFactory.Create(firstName, lastName, salary);

                this.employeeService.AddEmployee(employee);

                return OutputMsg.SuccessfulAddedEmployee;
            }

            throw new ArgumentException(OutputMsg.InvalidArgsInserted);
        }
    }
}
