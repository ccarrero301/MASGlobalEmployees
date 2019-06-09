using System;
using System.Linq.Expressions;

namespace MASGlobal.Employees.Shared.Patterns.Specification.Base
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