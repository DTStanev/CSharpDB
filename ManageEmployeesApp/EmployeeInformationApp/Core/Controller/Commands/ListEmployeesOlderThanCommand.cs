using System;
using System.Text;

namespace EmployeeInformationApp.Core.Controller.Commands
{
    using IO;
    using DTOs;
    using EmployeeInformationServices.Services.Interfaces;

    //Shows info for employees older than given age

    public class ListEmployeesOlderThanCommand : Command
    {


        public ListEmployeesOlderThanCommand(IEmployeeService employeeService)
            : base(employeeService)
        { }

        public override string Execute(params string[] employeeInfo)
        {
            if (employeeInfo.Length == 1 && int.TryParse(employeeInfo[0], out var age))
            {
                var employees = this.employeeService.GetEmployeesOlderThan<EmployeesOlderThanDto>(age);

                if (employees.Count == 0)
                {
                    return OutputMsg.ThereArenoEmployeesOlderThanGivenAge;
                }

                var sb = new StringBuilder();

                foreach (var emp in employees)
                {
                    sb.AppendLine(string.Format(OutputMsg.EmployeesBornAfterYearDtoOutput, emp.FirstName, emp.LastName, emp.Salary, emp.ManagerName ?? OutputMsg.NoManagerMsg));
                }

                return sb.ToString().TrimEnd();
            }
            throw new ArgumentException(OutputMsg.InvalidArgsInserted);
        }
    }
}
