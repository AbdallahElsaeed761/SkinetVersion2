using Core.Entities.Products;
using Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int Id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetByIdAsyncWithSpecification(ISpecification<T> specification);
        Task<IReadOnlyList<T>> ListAllAsyncSpecification(ISpecification<T> specification);
    }
}
