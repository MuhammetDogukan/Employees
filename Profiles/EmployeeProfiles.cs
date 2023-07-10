using AutoMapper;
using Empoyee.Model;
using Employees.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Employees.Profiles
{
    public class EmployeeProfiles : Profile
    {
        //source -> destinition
        public EmployeeProfiles()
        {
            /*
            CreateMap<Employee, EmployeeReadDto>();
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();
            CreateMap<Employee, EmployeeUpdateDto>();
            */
        }
    }
}
