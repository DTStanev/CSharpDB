using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeInformationServices.Services
{
    using Data;
    using Interfaces;
    using Models;

    public class EmployeeService : Service, IEmployeeService
    {
        public EmployeeService(EmployeesDBContext db) 
            : base(db)
        {
        }

        public void AddEmployee(Employee employee)
        {
            this.db.Employees.Add(employee);
            db.SaveChanges();
        }

        public TModel EmployeeInfo<TModel>(int empId)
        {
            var employee = db.Employees
                    .Where(e => e.EmployeeId == empId)
                    .ProjectTo<TModel>()
                    .SingleOrDefault();

            return employee;
        }

        public bool Exists(int empId) => db.Employees.Find(empId) != null;
       

        public ICollection<TModel> GetEmployeesOlderThan<TModel>(int age)
        {
            var employees = db.Employees.Where(emp => emp.BirthDay != null && (DateTime.Now.Year - emp.BirthDay.Value.Year) > age).ProjectTo<TModel>().ToList();

            return employees;
        }

        public void SetAddress(int empId, string address)
        {
            var employee = db.Employees.Find(empId);
            employee.Address = address;
            db.SaveChanges();
        }

        public void SetBirthday(int empId, DateTime date)
        {
            var employee = db.Employees.Find(empId);
            employee.BirthDay = date;
            db.SaveChanges();
        }       
    }
}
