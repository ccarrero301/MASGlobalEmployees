using MASGlobal.Employees.Shared.Patterns.Specification.Base;

namespace MASGlobal.Employees.Shared.Patterns.Specification.Implementations
{
    internal sealed class AllSpecification<TEntity> : CompositeSpecification<TEntity>
    {
        public override bool IsSatisfiedBy(TEntity entityToTest) => true;
    }
}