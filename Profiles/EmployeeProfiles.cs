using AutoMapper;
using Empoyee.Model;
using Empoyees.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Empoyees.Profiles
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
