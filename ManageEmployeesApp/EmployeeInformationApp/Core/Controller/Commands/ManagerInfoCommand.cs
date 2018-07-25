using System;
using System.Text;

namespace EmployeeInformationApp.Core.Controller.Commands
{
    using IO;
    using DTOs;
    using EmployeeInformationServices.Services.Interfaces;

    //Gives information about specific manager, the count of his employees 

    public class ManagerInfoCommand : Command
    {
        public ManagerInfoCommand(IManagerService managerService)
            : base(managerService)
        { }

        public override string Execute(params string[] employeeInfo)
        {
            if (employeeInfo.Length == 1 && int.TryParse(employeeInfo[0], out var managerId))
            {
                if (this.managerService.Exists(managerId))
                {
                    var sb = new StringBuilder();

                    var manager = this.managerService.ManagerInfo<ManagerDto>(managerId);

                    sb.AppendLine(string.Format(OutputMsg.ManagerAndHisEmployeesCount, manager.FirstName, manager.LastName, manager.EmployeesDto.Count));

                    foreach (var emp in manager.EmployeesDto)
                    {
                        sb.AppendLine(string.Format(OutputMsg.ManagerEmployeesInfo, emp.FirstName, emp.LastName, emp.Salary));
                    }

                    return sb.ToString().TrimEnd();
                }
               
                    throw new ArgumentException(OutputMsg.InvalidEmployeeId);
            }

            throw new ArgumentException(OutputMsg.InvalidArgsInserted);
        }
    }
}
