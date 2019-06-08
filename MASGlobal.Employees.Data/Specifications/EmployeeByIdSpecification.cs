using MASGlobal.Employees.Shared.DTOs.Data;
using MASGlobal.Employees.Shared.Patterns.Specification.Base;

namespace MASGlobal.Employees.Data.Specifications
{
    public class EmployeeByIdSpecification : CompositeSpecification<Employee>
    {
        private readonly int _employeeId;

        public EmployeeByIdSpecification(int employeeId) => _employeeId = employeeId;

        public override bool IsSatisfiedBy(Employee entityToTest) => entityToTest.EmployeeId == _employeeId;
    }
}