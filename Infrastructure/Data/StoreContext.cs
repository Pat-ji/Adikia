using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class StoreContext : DbContext
	{
		public DbSet<Character> Characters { get; set; }
		public DbSet<CharacterDialogue> CharacterDialogues { get; set; }
		public DbSet<CharacterDialogueAction> CharacterDialogueActions { get; set; }
		public DbSet<Dialogue> Dialogues { get; set; }
		public DbSet<Evidence> Evidence { get; set; }
		public DbSet<Game> Games { get; set; }
		public DbSet<GameDialogue> GameDialogues { get; set; }
		public DbSet<GameDialogueAction> GameDialogueActions { get; set; }
		public DbSet<Hint> Hints { get; set; }
		public DbSet<Session> Sessions { get; set; }
		public DbSet<SessionCharacter> SessionCharacters { get; set; }
		public DbSet<SessionEvidence> SessionEvidence { get; set; }
		public DbSet<UnlockableEvidence> UnlockableEvidences { get; set; }
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
