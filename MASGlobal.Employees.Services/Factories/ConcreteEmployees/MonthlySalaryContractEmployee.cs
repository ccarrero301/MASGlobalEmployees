using MASGlobal.Employees.Domain.Entities;
using MASGlobal.Employees.Services.Factories.AbstractEmployees;

namespace MASGlobal.Employees.Services.Factories.ConcreteEmployees
{
    internal sealed class MonthlySalaryContractEmployee : AnnualSalaryEmployee
    {
        public MonthlySalaryContractEmployee(int employeeId, string employeeName, EmployeeRole employeeRole,
            EmployeeContractType employeeContractType, double hourlySalary, double monthlySalary) : base(employeeId,
            employeeName, employeeRole, employeeContractType, hourlySalary, monthlySalary)
        {
        }

        public override double AnnualSalary => MonthlySalary * 12;
    }
}