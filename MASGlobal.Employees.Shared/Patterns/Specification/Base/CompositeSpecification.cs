using MASGlobal.Employees.Shared.Patterns.Specification.Contracts;
using MASGlobal.Employees.Shared.Patterns.Specification.Implementations;

namespace MASGlobal.Employees.Shared.Patterns.Specification.Base
{
    public abstract class CompositeSpecification<TEntity> : ISpecification<TEntity>
    {
        public abstract bool IsSatisfiedBy(TEntity entityToTest);

        public ISpecification<TEntity> And(ISpecification<TEntity> specification)
        {
            return new AndSpecification<TEntity>(this, specification);
        }

        public ISpecification<TEntity> Or(ISpecification<TEntity> specification)
        {
            return new OrSpecification<TEntity>(this, specification);
        }

        public ISpecification<TEntity> Not()
        {
            return new NotSpecification<TEntity>(this);
        }

        public ISpecification<TEntity> All()
        {
            return new AllSpecification<TEntity>();
        }

        public static CompositeSpecification<TEntity> operator &(CompositeSpecification<TEntity> specificationLeft,
            CompositeSpecification<TEntity> specificationRight)
        {
            return new AndSpecification<TEntity>(specificationLeft, specificationRight);
        }

        public static CompositeSpecification<TEntity> operator |(CompositeSpecification<TEntity> specificationLeft,
            CompositeSpecification<TEntity> specificationRight)
        {
            return new OrSpecification<TEntity>(specificationLeft, specificationRight);
        }

        public static CompositeSpecification<TEntity> operator !(CompositeSpecification<TEntity> specification)
        {
            return new NotSpecification<TEntity>(specification);
        }
    }
}