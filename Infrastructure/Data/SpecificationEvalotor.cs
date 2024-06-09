using Core.Entities.Products;
using Core.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SpecificationEvalotor<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetSpecificationEntity(IQueryable<TEntity> entities,
            ISpecification<TEntity> specification)
        {
            var query = entities;
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }
            query = specification.Includes.Aggregate(query ,(Current , include)=> Current.Include(include));
            return query;
        }
    }
}
