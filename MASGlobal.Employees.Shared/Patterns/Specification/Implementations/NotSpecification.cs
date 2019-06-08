using MASGlobal.Employees.Shared.Patterns.Specification.Base;
using MASGlobal.Employees.Shared.Patterns.Specification.Contracts;

namespace MASGlobal.Employees.Shared.Patterns.Specification.Implementations
{
    internal sealed class NotSpecification<TEntity> : CompositeSpecification<TEntity>
    {
        private readonly ISpecification<TEntity> _specification;

        public NotSpecification(ISpecification<TEntity> specification) => _specification = specification;

        public override bool IsSatisfiedBy(TEntity entityToTest) => !_specification.IsSatisfiedBy(entityToTest);
    }
}