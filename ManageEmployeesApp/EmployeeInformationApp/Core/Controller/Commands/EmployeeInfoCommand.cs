using System;

namespace EmployeeInformationApp.Core.Controller.Commands
{
    using IO;
    using EmployeeInformationApp.DTOs;
    using EmployeeInformationServices.Services.Interfaces;

    //Shows custom information about specific employee

    public class EmployeeInfoCommand:Command
    {
    

        public EmployeeInfoCommand(IEmployeeService employeeService)
            :base(employeeService)
        {
           
        }

        public override string Execute(params string[] employeeInfo)
        {
            if (employeeInfo.Length == 1 && int.TryParse(employeeInfo[0], out var empId))
            {
                var employee = this.employeeService.EmployeeInfo<EmployeeDto>(empId);

                if (employee == null)
                {
                    throw new ArgumentException(OutputMsg.InvalidEmployeeId);
                }

                return string.Format(OutputMsg.EmployeeIngoMsg, employee.EmployeeId, employee.FirstName, employee.LastName, employee.Salary);
            }

            throw new ArgumentException(OutputMsg.InvalidArgsInserted);
        }
    }
}
