using System.Collections.Generic;
using MASGlobal.Employees.Domain;

namespace MASGlobal.Employees.Data.Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee GetEmployeesById(int employeeId);
    }
}