using System.Collections.Generic;
using System.Threading.Tasks;
using DataEmployeeDto = MASGlobal.Employees.Shared.DTOs.Data.Employee;

namespace MASGlobal.Employees.Data.Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<DataEmployeeDto>> GetAllEmployeesAsync();
    }
}