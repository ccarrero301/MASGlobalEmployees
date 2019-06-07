using MASGlobal.Employees.Patterns.Specification.Base;

namespace MASGlobal.Employees.Patterns.Specification.Implementations
{
    internal sealed class AllSpecification<TEntity> : ExpressionSpecification<TEntity>
    {
        public override bool IsSatisfiedBy(TEntity entityToTest) => true;
    }
}