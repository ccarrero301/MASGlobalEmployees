using System;
using AutoMapper;
using MASGlobal.Employees.Domain.Entities;
using EmployeeDto = MASGlobal.Employees.DTOs.Entities.Employee;

namespace MASGlobal.Employees.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() => CreateMap<EmployeeDto, Employee>().ConstructUsing(source =>
            new Employee(source.EmployeeId, source.EmployeeName,
                new EmployeeRole(source.EmployeeRoleId, source.EmployeeRoleName, source.EmployeeRoleDescription),
                ConstructEmployeeContractType(source.EmployeeContractType)));

        private static EmployeeContractType ConstructEmployeeContractType(string enumCandidate)
        {
            Enum.TryParse(enumCandidate, true, out EmployeeContractType employeeContractTypeResult);

            return employeeContractTypeResult;
        }
    }
}