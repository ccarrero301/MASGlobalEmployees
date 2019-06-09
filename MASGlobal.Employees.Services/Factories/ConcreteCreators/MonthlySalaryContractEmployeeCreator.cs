using MASGlobal.Employees.Domain.Entities;
using MASGlobal.Employees.Services.Factories.AbstractCreators;
using MASGlobal.Employees.Services.Factories.AbstractEmployees;
using MASGlobal.Employees.Services.Factories.ConcreteEmployees;
using DomainEmployee = MASGlobal.Employees.Domain.Entities.Employee;

namespace MASGlobal.Employees.Services.Factories.ConcreteCreators
{
    public class MonthlySalaryContractEmployeeCreator : DomainEmployee, IEmployeeContractFactory
    {
        public MonthlySalaryContractEmployeeCreator(int employeeId, string employeeName, EmployeeRole employeeRole,
            EmployeeContractType employeeContractType, double hourlySalary, double monthlySalary) : base(employeeId,
            employeeName, employeeRole, employeeContractType, hourlySalary, monthlySalary)
        {
        }

        public AnnualSalaryEmployee GetSalaryContractEmployee()
        {
            return new MonthlySalaryContractEmployee(EmployeeId, EmployeeName, EmployeeRole,
                EmployeeContractType, HourlySalary, MonthlySalary);
        }
    }
}