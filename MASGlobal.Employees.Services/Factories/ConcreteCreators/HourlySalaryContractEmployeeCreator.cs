using MASGlobal.Employees.Domain.Entities;
using MASGlobal.Employees.Services.Factories.AbstractCreators;
using MASGlobal.Employees.Services.Factories.AbstractEmployees;
using MASGlobal.Employees.Services.Factories.ConcreteEmployees;

namespace MASGlobal.Employees.Services.Factories.ConcreteCreators
{
    public class HourlySalaryContractEmployeeCreator : Employee, IEmployeeContractFactory
    {
        public HourlySalaryContractEmployeeCreator(int employeeId, string employeeName, EmployeeRole employeeRole,
            EmployeeContractType employeeContractType, double hourlySalary, double monthlySalary) : base(employeeId,
            employeeName, employeeRole, employeeContractType, hourlySalary, monthlySalary)
        {
        }

        public AnnualSalaryEmployee GetEmployee()
        {
            return new HourlySalaryContractEmployee(EmployeeId, EmployeeName, EmployeeRole,
                EmployeeContractType, HourlySalary, MonthlySalary);
        }
    }
}