using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceEmployeeDto = MASGlobal.Employees.Shared.DTOs.Services.Employee;

namespace MASGlobal.Employees.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<ServiceEmployeeDto>> GetAllEmployeesAsync();

        Task<ServiceEmployeeDto> GetSingleEmployeeByIdAsync(int employeeId);
    }
}