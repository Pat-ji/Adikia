using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class GameDialogueConfiguration : IEntityTypeConfiguration<GameDialogue>
    {
        public void Configure(EntityTypeBuilder<GameDialogue> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.GameStage);

            builder.HasOne(x => x.Game).WithMany(y => y.GameDialogues).HasForeignKey(x => x.GameId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Dialogue).WithMany(y => y.GameDialogues).HasForeignKey(x => x.GameId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
