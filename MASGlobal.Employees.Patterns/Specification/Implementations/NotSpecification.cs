using MASGlobal.Employees.Patterns.Specification.Base;
using MASGlobal.Employees.Patterns.Specification.Contracts;

namespace MASGlobal.Employees.Patterns.Specification.Implementations
{
    internal sealed class NotSpecification<TEntity> : CompositeSpecification<TEntity>
    {
        private readonly ISpecification<TEntity> _specification;

        public NotSpecification(ISpecification<TEntity> specification) => _specification = specification;

        public override bool IsSatisfiedBy(TEntity entityToTest) => !_specification.IsSatisfiedBy(entityToTest);
    }
}