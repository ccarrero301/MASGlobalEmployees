﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MASGlobal.Employees.Domain;

namespace MASGlobal.Employees.Data.Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        Task<Employee> GetEmployeesByIdAsync(int employeeId);
    }
}