using System;
using AutoMapper;
using MASGlobal.Employees.Domain.Entities;
using MASGlobal.Employees.Services.Factories.AbstractEmployees;
using DomainEmployee = MASGlobal.Employees.Domain.Entities.Employee;
using ServiceEmployeeDto = MASGlobal.Employees.Shared.DTOs.Services.Employee;
using DataEmployeeDto = MASGlobal.Employees.Shared.DTOs.Data.Employee;

namespace MASGlobal.Employees.WebApi.Mappings
{
    internal sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DataEmployeeDto, DomainEmployee>().ConstructUsing(source => new DomainEmployee(source.EmployeeId,
                source.EmployeeName,
                new EmployeeRole(source.EmployeeRoleId, source.EmployeeRoleName, source.EmployeeRoleDescription),
                ConstructDomainEmployeeContractType(source.EmployeeContractType),
                Convert.ToDouble(source.EmployeeHourlySalary), Convert.ToDouble(source.EmployeeMonthlySalary)));

            CreateMap<AnnualSalaryEmployee, ServiceEmployeeDto>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.EmployeeName))
                .ForMember(dest => dest.EmployeeContractType,
                    opt => opt.MapFrom(src => ConstructServiceDtoEmployeeContractType(src.EmployeeContractType)))
                .ForMember(dest => dest.EmployeeRoleId, opt => opt.MapFrom(src => src.EmployeeRole.EmployeeRoleId))
                .ForMember(dest => dest.EmployeeRoleName, opt => opt.MapFrom(src => src.EmployeeRole.EmployeeRoleName))
                .ForMember(dest => dest.EmployeeRoleDescription,
                    opt => opt.MapFrom(src => src.EmployeeRole.EmployeeRoleDescription))
                .ForMember(dest => dest.EmployeeHourlySalary, opt => opt.MapFrom(src => src.HourlySalary))
                .ForMember(dest => dest.EmployeeMonthlySalary, opt => opt.MapFrom(src => src.MonthlySalary))
                .ForMember(dest => dest.AnnualSalary, opt => opt.MapFrom(src => src.AnnualSalary));
        }

        private static EmployeeContractType ConstructDomainEmployeeContractType(string enumCandidate)
        {
            Enum.TryParse(enumCandidate, true, out EmployeeContractType employeeContractTypeResult);

            return employeeContractTypeResult;
        }

        private static string ConstructServiceDtoEmployeeContractType(EmployeeContractType employeeContractType)
        {
            switch (employeeContractType)
            {
                case EmployeeContractType.NotDefined:
                    return "Not defined";
                case EmployeeContractType.HourlySalaryEmployee:
                    return "Hourly Salary Employee";
                case EmployeeContractType.MonthlySalaryEmployee:
                    return "Monthly Salary Employee";
                default:
                    throw new ArgumentOutOfRangeException(nameof(employeeContractType), employeeContractType, null);
            }
        }
    }
}