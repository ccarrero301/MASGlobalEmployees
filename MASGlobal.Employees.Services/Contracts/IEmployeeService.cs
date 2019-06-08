using System.Collections.Generic;
using System.Threading.Tasks;
using MASGlobal.Employees.DTOs.Services;

namespace MASGlobal.Employees.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();

        Task<Employee> GetEmployeeByIdAsync(int employeeId);
    }
}