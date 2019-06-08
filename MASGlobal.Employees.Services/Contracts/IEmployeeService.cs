using System.Threading.Tasks;

namespace MASGlobal.Employees.Services.Contracts
{
    public interface IEmployeeService
    {
        Task GetEmployeesAsync();
    }
}