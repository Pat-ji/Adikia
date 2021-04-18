using System.Linq;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification, bool paginate)
        {
            var query = inputQuery;

            if (specification.Criteria != null)
                query = specification.Criteria.Aggregate(query, (current, criteria) => current.Where(criteria));

            if (specification.OrderBy != null)
                query = query.OrderBy(specification.OrderBy);

            if (specification.OrderByDescending != null)
                query = query.OrderByDescending(specification.OrderByDescending);

            if (specification.IsPagingEnabled && paginate)
                query = query.Skip(specification.Skip).Take(specification.Take);

            if (specification.Includes != null)
                query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
