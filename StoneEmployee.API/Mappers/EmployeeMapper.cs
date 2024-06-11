using AutoMapper;
using StoneEmployee.Application.DTO;
using StoneEmployee.Core.Entities;

namespace StoneEmployee.API.Mappers
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<CreateEmployeeDTO, Employee>();
            CreateMap<Employee, CreateEmployeeDTO>();
        }
    }
}
