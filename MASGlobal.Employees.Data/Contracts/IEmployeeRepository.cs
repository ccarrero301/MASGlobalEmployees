using System.Collections.Generic;
using System.Threading.Tasks;
using MASGlobal.Employees.Domain;

namespace MASGlobal.Employees.Data.Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();

        Task<Employee> GetEmployeesById(int employeeId);
    }
}