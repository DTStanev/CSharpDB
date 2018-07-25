using System;

namespace Models.Interfaces
{
    public interface IEmployee
    {
        int EmployeeId { get; }

        string FirstName { get; }

        string LastName { get; }

        decimal Salary { get; }

        DateTime? BirthDay { get; }

        string Address { get; }
    }
}
