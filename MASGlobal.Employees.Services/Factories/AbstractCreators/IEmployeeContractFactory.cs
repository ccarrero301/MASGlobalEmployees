using MASGlobal.Employees.Services.Factories.AbstractEmployees;

namespace MASGlobal.Employees.Services.Factories.AbstractCreators
{
    internal interface IEmployeeContractFactory
    {
        AnnualSalaryEmployee GetSalaryContractEmployee();
    }
}