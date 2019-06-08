using MASGlobal.Employees.Shared.DTOs.Data;
using MASGlobal.Employees.Shared.Patterns.Specification.Base;

namespace MASGlobal.Employees.Data.Specifications
{
    public class AllEmployeesSpecification : CompositeSpecification<Employee>
    {
        public override bool IsSatisfiedBy(Employee entityToTest) => All().IsSatisfiedBy(entityToTest);
    }
}