using MASGlobal.Employees.Domain.Entities;
using MASGlobal.Employees.Patterns.Specification.Base;

namespace MASGlobal.Employees.Data.Specifications
{
    public class EmployeesByIdSpecification : CompositeSpecification<Employee>
    {
        private readonly int _employeeId;

        public EmployeesByIdSpecification(int employeeId) => _employeeId = employeeId;

        public override bool IsSatisfiedBy(Employee entityToTest) => entityToTest.EmployeeId == _employeeId;
    }
}