using System;

namespace EmployeeInformationApp.Core.Controller.Commands
{
    using EmployeeInformationServices.Services.Interfaces;
    using IO;

    //Set manager to specific employee

    public class SetManagerCommand : Command
    {      
        public SetManagerCommand(IManagerService managerService)
            :base(managerService)
        {  }

        public override string Execute(params string[] employeeInfo)
        {            
            if (employeeInfo.Length == 2 && int.TryParse(employeeInfo[0], out var empId) && int.TryParse(employeeInfo[1], out var mngId))
            {
                if (this.managerService.Exists(empId) && this.managerService.Exists(mngId))
                {
                    this.managerService.SetManager(empId, mngId);

                    return OutputMsg.ManagerSetSuccessfully; 
                }

                throw new ArgumentException(OutputMsg.InvalidEmployeeId);
            }

            throw new ArgumentException(OutputMsg.InvalidArgsInserted);
        }
    }
}
