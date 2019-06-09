﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MASGlobal.Employees.Data.Contracts;
using MASGlobal.Employees.Data.Specifications;
using MASGlobal.Employees.Shared.Resources;
using MASGlobal.Employees.Shared.Rest.Contracts;
using MASGlobal.Employees.Shared.Rest.Entities;
using DataDtoEmployee = MASGlobal.Employees.Shared.DTOs.Data.Employee;
using DomainEmployee = MASGlobal.Employees.Domain.Entities.Employee;

namespace MASGlobal.Employees.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMapper _mapper;
        private readonly IRestClient _restClient;

        public EmployeeRepository(IRestClient restClient, IMapper mapper)
        {
            _restClient = restClient;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DomainEmployee>> GetAllEmployeesAsync()
        {
            var allEmployeesSpecification = new AllEmployeesSpecification();

            var dataDtoEmployeeList = await GetDataDtoEmployeeListAsync().ConfigureAwait(false);

            var dataDtoEmployeeListFiltered = dataDtoEmployeeList.Where(allEmployeesSpecification.IsSatisfiedBy);

            var domainEmployeeList =
                _mapper.Map<IEnumerable<DataDtoEmployee>, IEnumerable<DomainEmployee>>(dataDtoEmployeeListFiltered);

            return domainEmployeeList;
        }


        public async Task<DomainEmployee> GetEmployeesByIdAsync(int employeeId)
        {
            var employeeByIdSpecification = new EmployeeByIdSpecification(employeeId);

            var dataDtoEmployeeList = await GetDataDtoEmployeeListAsync().ConfigureAwait(false);

            var dataDtoEmployee = dataDtoEmployeeList.Where(employeeByIdSpecification.IsSatisfiedBy).FirstOrDefault();

            var domainEmployee = _mapper.Map<DataDtoEmployee, DomainEmployee>(dataDtoEmployee);

            return domainEmployee;
        }

        private async Task<IEnumerable<DataDtoEmployee>> GetDataDtoEmployeeListAsync()
        {
            var employeesEndpointRequest = GetEmployeesEndpointRequest();

            var dtoEmployeeList =
                await _restClient.ExecuteGetResultAsync<IEnumerable<DataDtoEmployee>>(employeesEndpointRequest)
                    .ConfigureAwait(false);

            return dtoEmployeeList;
        }

        private static RestClientRequest GetEmployeesEndpointRequest() =>
            new RestClientRequest(Rest.ExternalEmployeeBaseUri, Rest.ExternalAllEmployeesResource);
    }
}