using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
	{
		protected readonly StoreContext _context;

		public BaseRepository(StoreContext context)
			=> _context = context;

		public async Task<T> GetByIdAsync(int id)
			=> await Table().FirstOrDefaultAsync(x => x.Id == id);

		public async Task<IReadOnlyList<T>> GetAllAsync()
			=> await Table().ToListAsync();

		public async Task<bool> AnyWithSpecAsync(ISpecification<T> specification)
			=> await ApplySpecification(specification).AnyAsync();

		public async Task<T> GetWithSpecAsync(ISpecification<T> specification)
			=> await ApplySpecification(specification).FirstOrDefaultAsync();

		public async Task<IPagination<T>> GetAllWithSpecAsync(ISpecification<T> specification)
		{
			var result = await ApplySpecification(specification).ToListAsync();

			if (specification.IsPagingEnabled)
            {
				var count = await ApplySpecification(specification, false).CountAsync();
				return new Pagination<T>((specification.Skip / specification.Take) + 1, specification.Take, count, result);
			}
            else
            {
				return new Pagination<T>(0, result.Count, result.Count, result);
			}
		}
			

		public async Task<T> AddAsync(T entity, bool save = false)
		{
			Table().Add(entity);

			if (save)
				await _context.SaveChangesAsync();

			return entity;
		}

		public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, bool save = false)
		{
			Table().AddRange(entities);

			if (save)
				await _context.SaveChangesAsync();

			return entities;
		}

		public async Task<T> UpdateAsync(T entity, bool save = false)
		{
			Table().Update(entity);

			if (save)
				await _context.SaveChangesAsync();

			return entity;
		}

		private DbSet<T> Table()
			=> _context.Set<T>();

		private IQueryable<T> ApplySpecification(ISpecification<T> specification, bool paginate = true)
			=> SpecificationEvaluator<T>.GetQuery(Table().AsQueryable<T>(), specification, paginate);
    }
}
