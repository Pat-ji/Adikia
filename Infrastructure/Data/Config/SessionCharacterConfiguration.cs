using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class SessionCharacterConfiguration : IEntityTypeConfiguration<SessionCharacter>
    {
        public void Configure(EntityTypeBuilder<SessionCharacter> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CharacterStage);

            builder.HasOne(x => x.Session).WithMany(y => y.SessionCharacters).HasForeignKey(x => x.SessionId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Character).WithMany(y => y.SessionCharacters).HasForeignKey(x => x.SessionId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
