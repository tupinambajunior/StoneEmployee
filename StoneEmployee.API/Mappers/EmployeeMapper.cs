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
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ConstructUsing(e =>
                    new Employee(e.Id,
                                 e.FirstName,
                                 e.LastName,
                                 e.Document,
                                 e.Sector,
                                 e.GrossSalary,
                                 e.AdmissionDate.Date,
                                 e.HasHealthPlan,
                                 e.HasDentalPlan,
                                 e.HasTransportationVouchers)
                    );

            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.Document, opt => opt.MapFrom(src => src.Document.Value));
        }
    }
}
