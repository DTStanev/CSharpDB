using System;
using System.Globalization;

namespace EmployeeInformationApp.Core.Controller.Commands
{
    using EmployeeInformationServices.Services.Interfaces;
    using IO;

    //Set birthday to specific employee in the database

    public class SetBirthdayCommand : Command
    {
        public SetBirthdayCommand(IEmployeeService employeeService)
            : base(employeeService)
        { }

        public override string Execute(params string[] employeeInfo)
        {
            if (employeeInfo.Length == 2 && int.TryParse(employeeInfo[0], out var empId))
            {
                if (DateTime.TryParseExact(employeeInfo[1], "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                {
                    if (this.employeeService.Exists(empId))
                    {
                        this.employeeService.SetBirthday(empId, date);

                        return OutputMsg.BirthdaySetSuccessfully;
                    }

                    throw new ArgumentException(OutputMsg.InvalidEmployeeId);
                }
            }

            throw new ArgumentException(OutputMsg.InvalidArgsInserted);
        }
    }
}
