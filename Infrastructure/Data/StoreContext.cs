using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class StoreContext : DbContext
	{
		public DbSet<Game> Games { get; set; }
		public DbSet<Session> Sessions { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserGame> UserGames { get; set; }

		public StoreContext(DbContextOptions<StoreContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
