using MASGlobal.Employees.Patterns.Specification.Base;

namespace MASGlobal.Employees.Patterns.Specification.Implementations
{
    internal sealed class AllSpecification<TEntity> : CompositeSpecification<TEntity>
    {
        public override bool IsSatisfiedBy(TEntity entityToTest) => true;
    }
}