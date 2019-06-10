using MASGlobal.Employees.Shared.Patterns.Specification.Base;
using DataEmployeeDto = MASGlobal.Employees.Shared.DTOs.Data.Employee;

namespace MASGlobal.Employees.Services.Specifications
{
    internal sealed class EmployeeByIdSpecification : CompositeSpecification<DataEmployeeDto>
    {
        private readonly int _employeeId;

        public EmployeeByIdSpecification(int employeeId) => _employeeId = employeeId;

        public override bool IsSatisfiedBy(DataEmployeeDto entityToTest) => entityToTest.EmployeeId == _employeeId;
    }
}