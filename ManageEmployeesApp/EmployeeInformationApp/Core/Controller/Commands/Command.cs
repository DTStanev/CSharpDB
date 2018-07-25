namespace EmployeeInformationApp.Core.Controller.Commands
{
    using Interfaces;
    using EmployeeInformationServices.Services.Interfaces;


    public abstract class Command : IExecutable
    {
        protected IEmployeeService employeeService;
        protected IManagerService managerService;

        protected Command(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        protected Command(IManagerService managerService)
        {
            this.managerService = managerService;
        }

        public abstract string Execute(params string[] employeeInfo);       
    }
}
