using System.Linq;
using AutoMapper.QueryableExtensions;

namespace EmployeeInformationServices.Services
{
    using Data;
    using Interfaces;

    public class ManagerService : Service, IManagerService
    {
        public ManagerService(EmployeesDBContext db)
            : base(db)
        {
        }

        public bool Exists(int managerId)
        {
            var manager = db.Employees.Find(managerId) != null;

            return manager;
        }

        public TModel ManagerInfo<TModel>(int managerId)
        {
           var manager =  db.Employees.Where(m => m.EmployeeId == managerId).ProjectTo<TModel>().SingleOrDefault();

            return manager;
        }

        public void SetManager(int empId, int managerId)
        {
            var employee = db.Employees.Find(empId);

            var manager = db.Employees.Find(managerId);

            employee.Manager = manager;

            db.SaveChanges();
        }
    }
}
