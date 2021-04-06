using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
	{
		protected readonly StoreContext _context;

		public BaseRepository(StoreContext context)
			=> _context = context;

		public async Task<T> GetByIdAsync(int id)
			=> await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

		public async Task<IReadOnlyList<T>> GetAllAsync()
			=> await _context.Set<T>().ToListAsync();
	}
}
