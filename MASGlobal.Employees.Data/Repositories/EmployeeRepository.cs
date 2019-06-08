﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MASGlobal.Employees.Data.Contracts;
using MASGlobal.Employees.Domain;
using MASGlobal.Employees.Rest.Contracts;
using MASGlobal.Employees.Rest.Entities;

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

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var employeesEndpointRequest = GetEmployeesEndpointRequest();

            var dtoEmployeeList =
                await _restClient.ExecuteGetResultAsync<IEnumerable<DTOs.Employee>>(employeesEndpointRequest);

            var domainEmployeeList = _mapper.Map<IEnumerable<DTOs.Employee>, IEnumerable<Employee>>(dtoEmployeeList);

            return domainEmployeeList;
        }

        public Task<Employee> GetEmployeesById(int employeeId)
        {
            throw new NotImplementedException();
        }

        private static RestClientRequest GetEmployeesEndpointRequest() =>
            new RestClientRequest("masglobaltestapi.azurewebsites.net/api/", "Employees", null, null, null,
                null);
    }
}