using AutoMapper;
using StoneEmployee.Application.DTO;
using StoneEmployee.Core.Entities;

namespace StoneEmployee.API.Mappers
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<EmployeeDTO, Employee>()
                .ConstructUsing(e =>
                    new Employee("",
                                 e.FirstName,
                                 e.LastName,
                                 e.Document,
                                 e.Sector,
                                 e.GrossSalary,
                                 e.AdmissionDate.Date,
                                 e.HasHealthPlan,
                                 e.HasDentalPlan,
                                 e.HasTransportationVouchers)
                    ) ;
            CreateMap<Employee, EmployeeDTO>();
        }
    }
}
