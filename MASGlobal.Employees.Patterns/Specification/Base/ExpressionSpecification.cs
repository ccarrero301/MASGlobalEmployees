using MASGlobal.Employees.Patterns.Specification.Contracts;
using MASGlobal.Employees.Patterns.Specification.Implementations;

namespace MASGlobal.Employees.Patterns.Specification.Base
{
    public abstract class ExpressionSpecification<TEntity> : ISpecification<TEntity>
    {
        public abstract bool IsSatisfiedBy(TEntity entityToTest);

        public ISpecification<TEntity> And(ISpecification<TEntity> specification) =>
            new AndSpecification<TEntity>(this, specification);

        public ISpecification<TEntity> Or(ISpecification<TEntity> specification) =>
            new OrSpecification<TEntity>(this, specification);

        public ISpecification<TEntity> Not() => new NotSpecification<TEntity>(this);

        public ISpecification<TEntity> All() => new AllSpecification<TEntity>();

        public static ExpressionSpecification<TEntity> operator &(ExpressionSpecification<TEntity> specificationLeft,
            ExpressionSpecification<TEntity> specificationRight) =>
            new AndSpecification<TEntity>(specificationLeft, specificationRight);

        public static ExpressionSpecification<TEntity> operator |(ExpressionSpecification<TEntity> specificationLeft,
            ExpressionSpecification<TEntity> specificationRight) =>
            new OrSpecification<TEntity>(specificationLeft, specificationRight);

        public static ExpressionSpecification<TEntity> operator !(ExpressionSpecification<TEntity> specification) =>
            new NotSpecification<TEntity>(specification);
    }
}