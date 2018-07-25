using System;

namespace EmployeeInformationServices.Services.Interfaces
{
    using Models;
    using System.Collections.Generic;

    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);

        TModel EmployeeInfo<TModel>(int empId);

        ICollection<TModel> GetEmployeesOlderThan<TModel>(int age);

        void SetAddress(int empId, string address);

        void SetBirthday(int empId, DateTime date);

        bool Exists(int empId);

    }
}
