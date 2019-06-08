using AutoMapper;
using MASGlobal.Employees.DTOs;

namespace MASGlobal.Employees.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, Domain.Employee>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Name));

            CreateMap<Domain.Employee, Employee>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.EmployeeName));
        }
    }
}