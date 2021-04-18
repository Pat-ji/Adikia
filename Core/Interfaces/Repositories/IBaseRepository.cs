using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<bool> AnyWithSpecAsync(ISpecification<T> specification);
        Task<T> GetWithSpecAsync(ISpecification<T> specification);
        Task<IPagination<T>> GetAllWithSpecAsync(ISpecification<T> specification);

        Task<T> AddAsync(T entity, bool save = false);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, bool save = false);
        Task<T> UpdateAsync(T entity, bool save = false);
    }
}
