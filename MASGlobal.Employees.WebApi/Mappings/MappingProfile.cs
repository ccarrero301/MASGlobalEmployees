using System;
using AutoMapper;
using MASGlobal.Employees.Domain.Entities;
using MASGlobal.Employees.Services.Factories.AbstractEmployees;
using EmployeeDataDto = MASGlobal.Employees.DTOs.Data.Employee;
using EmployeeServiceDto = MASGlobal.Employees.DTOs.Services.Employee;

namespace MASGlobal.Employees.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDataDto, Employee>().ConstructUsing(source => new Employee(source.EmployeeId,
                source.EmployeeName,
                new EmployeeRole(source.EmployeeRoleId, source.EmployeeRoleName, source.EmployeeRoleDescription),
                ConstructEmployeeContractType(source.EmployeeContractType),
                Convert.ToDouble(source.EmployeeHourlySalary), Convert.ToDouble(source.EmployeeMonthlySalary)));

            CreateMap<AnnualSalaryEmployee, EmployeeServiceDto>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.EmployeeName))
                .ForMember(dest => dest.EmployeeContractType, opt => opt.MapFrom(src => src.EmployeeContractType))
                .ForMember(dest => dest.EmployeeRoleId, opt => opt.MapFrom(src => src.EmployeeRole.EmployeeRoleId))
                .ForMember(dest => dest.EmployeeRoleName, opt => opt.MapFrom(src => src.EmployeeRole.EmployeeRoleName))
                .ForMember(dest => dest.EmployeeRoleDescription, opt => opt.MapFrom(src => src.EmployeeRole.EmployeeRoleDescription))
                .ForMember(dest => dest.EmployeeHourlySalary, opt => opt.MapFrom(src => src.HourlySalary))
                .ForMember(dest => dest.EmployeeMonthlySalary, opt => opt.MapFrom(src => src.MonthlySalary))
                .ForMember(dest => dest.AnnualSalary, opt => opt.MapFrom(src => src.AnnualSalary));

        }

        private static EmployeeContractType ConstructEmployeeContractType(string enumCandidate)
        {
            Enum.TryParse(enumCandidate, true, out EmployeeContractType employeeContractTypeResult);

            return employeeContractTypeResult;
        }
    }
}