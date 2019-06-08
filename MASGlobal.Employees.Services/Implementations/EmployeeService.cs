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
using ServiceDtoEmployee = MASGlobal.Employees.DTOs.Services.Employee;

namespace MASGlobal.Employees.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ServiceDtoEmployee>> GetEmployeesAsync()
        {
            var allDomainEmployees = await _employeeRepository.GetAllEmployeesAsync().ConfigureAwait(false);

            var serviceEmployeesDtoList = allDomainEmployees.Select(GetEmployee).ToList();

            return serviceEmployeesDtoList;
        }

        public async Task<ServiceDtoEmployee> GetEmployeeByIdAsync(int employeeId)
        {
            var domainEmployee = await _employeeRepository.GetEmployeesByIdAsync(employeeId).ConfigureAwait(false);

            var serviceEmployeeDto = GetEmployee(domainEmployee);

            return serviceEmployeeDto;
        }

        private ServiceDtoEmployee GetEmployee(Employee domainEmployee)
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

            var annualSalaryEmployee = employeeContractFactory.GetEmployee();

            var serviceDtoEmployee = _mapper.Map<AnnualSalaryEmployee, ServiceDtoEmployee>(annualSalaryEmployee);

            return serviceDtoEmployee;
        }
    }
}