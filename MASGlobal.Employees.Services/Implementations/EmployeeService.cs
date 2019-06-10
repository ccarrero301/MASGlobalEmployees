using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MASGlobal.Employees.Data.Contracts;
using MASGlobal.Employees.Domain.Entities;
using MASGlobal.Employees.Services.Contracts;
using MASGlobal.Employees.Services.Factories.AbstractCreators;
using MASGlobal.Employees.Services.Factories.AbstractEmployees;
using MASGlobal.Employees.Services.Factories.ConcreteCreators;
using MASGlobal.Employees.Services.Specifications;
using DomainEmployee = MASGlobal.Employees.Domain.Entities.Employee;
using ServiceEmployeeDto = MASGlobal.Employees.Shared.DTOs.Services.Employee;
using DataEmployeeDto = MASGlobal.Employees.Shared.DTOs.Data.Employee;

namespace MASGlobal.Employees.Services.Implementations
{
    public sealed class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ServiceEmployeeDto>> GetAllEmployeesAsync()
        {
            var allEmployeesSpecification = new AllEmployeesSpecification();

            var allDataEmployesDtoList = await _employeeRepository.GetAllEmployeesAsync().ConfigureAwait(false);

            var allDataEmployeesListWithSpecificationApplied =
                allDataEmployesDtoList.Where(allEmployeesSpecification.IsSatisfiedBy);

            var allDomainEmployeesList =
                _mapper.Map<IEnumerable<DataEmployeeDto>, IEnumerable<DomainEmployee>>(
                    allDataEmployeesListWithSpecificationApplied);

            var serviceEmployeesDtoList = allDomainEmployeesList.Select(GetSalaryContractEmployee).ToList();

            return serviceEmployeesDtoList;
        }

        public async Task<ServiceEmployeeDto> GetSingleEmployeeByIdAsync(int employeeId)
        {
            var singleEmployeeByIdSpecification = new EmployeeByIdSpecification(employeeId);

            var allDataEmployesDtoList = await _employeeRepository.GetAllEmployeesAsync().ConfigureAwait(false);

            var singleDataEmployeeWithSpecificationApplied = allDataEmployesDtoList
                .Where(singleEmployeeByIdSpecification.IsSatisfiedBy).SingleOrDefault();

            if(singleDataEmployeeWithSpecificationApplied == null)
                throw new Exception("No Employee matched");

            var singleDomainEmployee =
                _mapper.Map<DataEmployeeDto, DomainEmployee>(singleDataEmployeeWithSpecificationApplied);

            var serviceEmployeeDto = GetSalaryContractEmployee(singleDomainEmployee);

            return serviceEmployeeDto;
        }

        private ServiceEmployeeDto GetSalaryContractEmployee(DomainEmployee domainEmployee)
        {
            IEmployeeContractFactory employeeContractFactory;

            switch (domainEmployee.EmployeeContractType)
            {
                case EmployeeContractType.NotDefined:
                    throw new Exception("There is not contract defined for the Employee");

                case EmployeeContractType.HourlySalaryEmployee:
                    employeeContractFactory = new HourlySalaryContractEmployeeCreator(domainEmployee.EmployeeId,
                        domainEmployee.EmployeeName, domainEmployee.EmployeeRole, domainEmployee.EmployeeContractType,
                        domainEmployee.HourlySalary, domainEmployee.MonthlySalary);
                    break;

                case EmployeeContractType.MonthlySalaryEmployee:
                    employeeContractFactory = new MonthlySalaryContractEmployeeCreator(domainEmployee.EmployeeId,
                        domainEmployee.EmployeeName, domainEmployee.EmployeeRole, domainEmployee.EmployeeContractType,
                        domainEmployee.HourlySalary, domainEmployee.MonthlySalary);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            var annualSalaryEmployee = employeeContractFactory.GetSalaryContractEmployee();

            var serviceDtoEmployee = _mapper.Map<AnnualSalaryEmployee, ServiceEmployeeDto>(annualSalaryEmployee);

            return serviceDtoEmployee;
        }
    }
}