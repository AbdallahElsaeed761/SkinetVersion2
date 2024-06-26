﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class Specification<T> : ISpecification<T>
    {
        public Specification()
        {

        }
        public Specification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected void AddInClude(Expression<Func<T,object>> expression)
        {
            Includes.Add(expression);
        }
        protected void AddOrderBy(Expression<Func<T, object>> order)
        {
            OrderBy = order;
        }
        protected void AddOrderByDesc(Expression<Func<T, object>> orderdesc)
        {
            OrderByDesc = orderdesc;
        }
        protected void Pagenation(int take ,int skip)
        {
            Take = take;
            Skip = skip;
            IsPagingEnabled = true;
        }

    }
}
