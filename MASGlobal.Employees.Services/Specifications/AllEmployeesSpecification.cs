using MASGlobal.Employees.Shared.Patterns.Specification.Base;
using DataEmployeeDto = MASGlobal.Employees.Shared.DTOs.Data.Employee;

namespace MASGlobal.Employees.Services.Specifications
{
    internal sealed class AllEmployeesSpecification : CompositeSpecification<DataEmployeeDto>
    {
        public override bool IsSatisfiedBy(DataEmployeeDto entityToTest) => All().IsSatisfiedBy(entityToTest);
    }
}