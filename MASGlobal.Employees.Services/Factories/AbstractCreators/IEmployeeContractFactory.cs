using MASGlobal.Employees.Services.Factories.AbstractEmployees;

namespace MASGlobal.Employees.Services.Factories.AbstractCreators
{
    public interface IEmployeeContractFactory
    {
        AnnualSalaryEmployee GetEmployee();
    }
}