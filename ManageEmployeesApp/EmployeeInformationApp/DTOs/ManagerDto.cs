using System.Collections.Generic;

namespace EmployeeInformationApp.DTOs
{
    public class ManagerDto
    {
        public ManagerDto()
        {
            this.EmployeesDto = new HashSet<EmployeeDto>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<EmployeeDto> EmployeesDto { get; set; }
    }
}
