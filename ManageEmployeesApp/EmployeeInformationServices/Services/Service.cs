namespace EmployeeInformationServices.Services
{
    using Data;

    public abstract class Service
    {
        protected readonly EmployeesDBContext db;

        protected Service(EmployeesDBContext db)
        {
            this.db = db;
        }
    }
}
