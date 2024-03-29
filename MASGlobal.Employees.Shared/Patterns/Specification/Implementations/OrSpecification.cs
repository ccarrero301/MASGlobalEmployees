﻿using MASGlobal.Employees.Shared.Patterns.Specification.Base;
using MASGlobal.Employees.Shared.Patterns.Specification.Contracts;

namespace MASGlobal.Employees.Shared.Patterns.Specification.Implementations
{
    internal sealed class OrSpecification<TEntity> : CompositeSpecification<TEntity>
    {
        private readonly ISpecification<TEntity> _leftSpecification;
        private readonly ISpecification<TEntity> _rightSpecification;

        public OrSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
        {
            _leftSpecification = left;
            _rightSpecification = right;
        }

        public override bool IsSatisfiedBy(TEntity entityToTest) =>
            _leftSpecification.IsSatisfiedBy(entityToTest) || _rightSpecification.IsSatisfiedBy(entityToTest);
    }
}