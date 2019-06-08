using System;
using System.Collections.Generic;
using MASGlobal.Employees.Data.Contracts;
using MASGlobal.Employees.Domain;

namespace MASGlobal.Employees.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeesById(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}