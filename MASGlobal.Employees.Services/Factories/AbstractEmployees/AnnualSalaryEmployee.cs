using MASGlobal.Employees.Domain.Entities;
using DomainEmployee = MASGlobal.Employees.Domain.Entities.Employee;

namespace MASGlobal.Employees.Services.Factories.AbstractEmployees
{
    public abstract class AnnualSalaryEmployee : DomainEmployee
    {
        protected AnnualSalaryEmployee(int employeeId, string employeeName, EmployeeRole employeeRole,
            EmployeeContractType employeeContractType, double hourlySalary, double monthlySalary) : base(employeeId,
            employeeName, employeeRole, employeeContractType, hourlySalary, monthlySalary)
        {
        }

        public abstract double AnnualSalary { get; }
    }
}