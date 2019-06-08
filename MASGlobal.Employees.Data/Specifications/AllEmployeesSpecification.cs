using MASGlobal.Employees.DTOs.Data;
using MASGlobal.Employees.Patterns.Specification.Base;

namespace MASGlobal.Employees.Data.Specifications
{
    public class AllEmployeesSpecification : CompositeSpecification<Employee>
    {
        public override bool IsSatisfiedBy(Employee entityToTest) => All().IsSatisfiedBy(entityToTest);
    }
}