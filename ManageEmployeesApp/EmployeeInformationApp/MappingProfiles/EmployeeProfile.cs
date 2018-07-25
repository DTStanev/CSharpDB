using AutoMapper;
using EmployeeInformationApp.DTOs;
using Models;

namespace EmployeeInformationApp.MappingProfiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
      
            CreateMap<Employee, EmployeePersonalInfoDto>().ReverseMap();

            CreateMap<Employee, ManagerDto>()
                .ForMember(cnfg => cnfg.EmployeesDto, 
                opt => opt.MapFrom(src => src.ManagerEmployees)).ReverseMap();

            CreateMap<Employee, EmployeesOlderThanDto>()
                .ForMember(cnfg => cnfg.ManagerName, opt => opt.MapFrom(src => src.Manager.LastName));
        }
    }
}
