using System;

namespace EmployeeInformationApp.Core.Controller.Commands
{
    using EmployeeInformationServices.Services.Interfaces;
    using IO;

    //Set address to specific employee in the database

    public class SetAddressCommand : Command
    {
        public SetAddressCommand(IEmployeeService employeeService)
            :base(employeeService)
        {
        }

        public override string Execute(params string[] employeeInfo)
        {
            if (employeeInfo.Length == 2 && int.TryParse(employeeInfo[0], out var empId))
            {

                if (this.employeeService.Exists(empId))
                {
                    var address = employeeInfo[1];
                    this.employeeService.SetAddress(empId, address);                    

                    return OutputMsg.EmployeeAddressSet; 
                }

                throw new ArgumentException(OutputMsg.InvalidEmployeeId);
            }
            throw new ArgumentException(OutputMsg.InvalidArgsInserted);
        }
    }
}
