using System;
using System.Linq.Expressions;
using MASGlobal.Employees.Patterns.Specification.Contracts;
using MASGlobal.Employees.Patterns.Specification.Implementations;

namespace MASGlobal.Employees.Patterns.Specification.Base
{
    public abstract class ExpressionSpecification<TEntity> : CompositeSpecification<TEntity>
    {
        public abstract Expression<Func<TEntity, bool>> ToExpression();

        public override bool IsSatisfiedBy(TEntity entityToTest)
        {
            var predicate = ToExpression().Compile();
            return predicate(entityToTest);
        }
    }
}