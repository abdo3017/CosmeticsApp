using Microsoft.EntityFrameworkCore.Query;
using MyApp.Domain.Core.Specifications;
using System.Linq.Expressions;

namespace MyApp.Application.Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification(){ }
            public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, IIncludableQueryable<T, object>>>> IncludesWithSub { get; } = new List<Expression<Func<T, IIncludableQueryable<T, object>>>>();
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public List<string> IncludeStrings { get; } = new List<string>();
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        public Expression<Func<T, object>> GroupBy { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public int TotalCount { get; set; }
        public bool IsPagingEnabled { get; private set; } = false;

        public virtual BaseSpecification<T> AddIncludeWithSubIncludes(Expression<Func<T, IIncludableQueryable<T, object>>> includeExpression)
        {
            IncludesWithSub.Add(includeExpression);
            return this;
        }
        public virtual BaseSpecification<T> AddInclude(Expression<Func<T,  object>> includeExpression)
        {
            Includes.Add(includeExpression);
            return this;
        }
        public virtual BaseSpecification<T> AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
            return this;
        }

        public virtual BaseSpecification<T> ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            if(Take > 0)
                IsPagingEnabled = true;
            return this;
        }

        public virtual BaseSpecification<T> ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
            return this;
        }

        public virtual BaseSpecification<T> ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
            return this;
        }

        public virtual BaseSpecification<T> ApplyGroupBy(Expression<Func<T, object>> groupByExpression)
        {
            GroupBy = groupByExpression;
            return this;
        }

    }
}
