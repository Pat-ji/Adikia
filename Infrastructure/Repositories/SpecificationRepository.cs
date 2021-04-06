using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SpecificationRepository<T> : BaseRepository<T> where T : BaseEntity
    {
        public SpecificationRepository(StoreContext context) : base(context)
        { }

		public async Task<T> GetWithSpecAsync(ISpecification<T> specification)
			=> await ApplySpecification(specification).FirstOrDefaultAsync();

		public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> specification)
			=> await ApplySpecification(specification).ToListAsync();

		private IQueryable<T> ApplySpecification(ISpecification<T> specification)
			=> SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable<T>(), specification);
	}
}
