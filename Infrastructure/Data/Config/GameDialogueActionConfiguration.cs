using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class GameDialogueActionConfiguration : IEntityTypeConfiguration<GameDialogueAction>
    {
        public void Configure(EntityTypeBuilder<GameDialogueAction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Action).HasMaxLength(128);
            builder.Property(x => x.NextGameStage);

            builder.HasOne(x => x.GameDialogue).WithMany(y => y.GameDialogueActions).HasForeignKey(x => x.GameDialogueId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
