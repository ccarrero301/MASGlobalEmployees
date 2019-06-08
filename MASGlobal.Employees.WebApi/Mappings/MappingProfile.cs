using System;
using AutoMapper;
using MASGlobal.Employees.Domain.Entities;
using EmployeeDataDto = MASGlobal.Employees.DTOs.Data.Employee;

namespace MASGlobal.Employees.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() =>
            CreateMap<EmployeeDataDto, Employee>().ConstructUsing(source => new Employee(source.EmployeeId,
                source.EmployeeName,
                new EmployeeRole(source.EmployeeRoleId, source.EmployeeRoleName, source.EmployeeRoleDescription),
                ConstructEmployeeContractType(source.EmployeeContractType),
                Convert.ToDouble(source.EmployeeHourlySalary), Convert.ToDouble(source.EmployeeMonthlySalary)));

        private static EmployeeContractType ConstructEmployeeContractType(string enumCandidate)
        {
            Enum.TryParse(enumCandidate, true, out EmployeeContractType employeeContractTypeResult);

            return employeeContractTypeResult;
        }
    }
}