using System.Threading.Tasks;
using MASGlobal.Employees.Data.Contracts;
using MASGlobal.Employees.Services.Contracts;

namespace MASGlobal.Employees.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task GetEmployeesAsync()
        {
            var allDomainEmployees = await _employeeRepository.GetAllEmployeesAsync().ConfigureAwait(false);
        }

        public async Task GetEmployeeByIdAsync(int employeeId)
        {
            var domainEmployee = await _employeeRepository.GetEmployeesByIdAsync(employeeId).ConfigureAwait(false);
        }
    }
}