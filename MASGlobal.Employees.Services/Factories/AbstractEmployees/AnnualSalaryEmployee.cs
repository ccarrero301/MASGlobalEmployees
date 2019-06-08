using MASGlobal.Employees.Domain.Entities;

namespace MASGlobal.Employees.Services.Factories.AbstractEmployees
{
    public abstract class AnnualSalaryEmployee : Employee
    {
        protected AnnualSalaryEmployee(int employeeId, string employeeName, EmployeeRole employeeRole,
            EmployeeContractType employeeContractType, double hourlySalary, double monthlySalary) : base(employeeId,
            employeeName, employeeRole, employeeContractType, hourlySalary, monthlySalary)
        {
        }

        public abstract double AnnualSalary { get; }
    }
}