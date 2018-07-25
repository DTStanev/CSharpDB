namespace EmployeeInformationServices.Services
{
    using Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class DBInitializeService : Service, IDBInitializerService
    {
        public DBInitializeService(EmployeesDBContext db) 
            : base(db)
        {
        }

        public void InitializeDb()
        {
            db.Database.Migrate();
        }
    }
}
