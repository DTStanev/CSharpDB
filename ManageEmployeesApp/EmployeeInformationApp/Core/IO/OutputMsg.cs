namespace EmployeeInformationApp.Core.IO
{
    public static class OutputMsg
    {
        public const string SuccessfulAddedEmployee = "The employee was added succesfully";

        public const string InvalidCommand = "Invalid Command!";

        public const string TheCommandIsNotIExecutable = "The command is not IExecutable!";

        public const string BirthdaySetSuccessfully = "The birthday was set successfully";

        public const string InvalidArgsInserted = "Inserted data is not valid!";

        public const string EmployeeAddressSet = "Employee address was set";

        public const string InvalidEmployeeId = "Invalid Employee Id";

        public const string EmployeeIngoMsg = "{0} - {1} {2} -  ${3:f2}";

        public const string ShutingDownApp = "The program will shut down after 5 seconds!";

        public const string ShutDownThankYouMsg = "Thank you for using our services!";

        public const string EmployeePersonalInfoDto = "ID: {0} - {1} {2} - ${3:f2}{4}Birthday: {5}{6}Address: {7}";

        public const string StringCommand = "Command";

        public const string DateFormat = "dd.MM.yyyy";

        public const string ManagerSetSuccessfully = "The manager was set successfully";

        public const string ManagerAndHisEmployeesCount = "{0} {1} | Employees: {2}";

        public const string ManagerEmployeesInfo = "    - {0} {1} - {2:f2}";

        public const string AvailableCommands = "Available commands:{0}";

        public const string NoManagerMsg = "[no manager]";

        public const string EmployeesBornAfterYearDtoOutput = "{0} {1} - ${2:f2} - Manager: {3}";

        public const string ThereArenoEmployeesOlderThanGivenAge = "There are no employees older than the given age";

        public const string InsertCommand = "Insert command: ";
    }
}
