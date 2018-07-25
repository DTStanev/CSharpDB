using System;

namespace EmployeeInformationApp.Core.Controller.Commands
{
    using IO;
    using EmployeeInformationApp.DTOs;
    using EmployeeInformationServices.Services.Interfaces;

    //Shows full information about specific employee 

    public class EmployeePersonalInfoCommand : Command
    {

        public EmployeePersonalInfoCommand(IEmployeeService employeeService)
            : base(employeeService)
        { }

        public override string Execute(params string[] employeeInfo)
        {
            if (employeeInfo.Length == 1 && int.TryParse(employeeInfo[0], out var empId))
            {
                var employee = this.employeeService.EmployeeInfo<EmployeePersonalInfoDto>(empId);

                if (employee == null)
                {
                    throw new ArgumentException(OutputMsg.InvalidEmployeeId);
                }

                return string.Format(OutputMsg.EmployeePersonalInfoDto,
                    employee.EmployeeId,
                    employee.FirstName,
                    employee.LastName,
                    employee.Salary,
                    Environment.NewLine,
                    employee.Birthday.Value.ToString(OutputMsg.DateFormat),
                    Environment.NewLine,
                    employee.Address);
            }

            throw new ArgumentException(OutputMsg.InvalidArgsInserted);
        }
    }
}
