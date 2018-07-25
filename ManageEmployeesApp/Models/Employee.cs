using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Employee : IEmployee
    {
        private Employee()
        { }

        public Employee(string firstName, string lastName, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;

            this.ManagerEmployees = new HashSet<Employee>();
        }

        [Key]
        public int EmployeeId { get; private set; }

        [Required]
        public string FirstName { get; private set; }

        [Required]
        public string LastName { get; private set; }

        public decimal Salary { get; private set; }

        public DateTime? BirthDay { get; set; }

        public string Address { get; set; }

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        public ICollection<Employee> ManagerEmployees { get; set; }
    }
}
