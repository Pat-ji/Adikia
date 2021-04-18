using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class CharacterDialogueActionConfiguration : IEntityTypeConfiguration<CharacterDialogueAction>
    {
        public void Configure(EntityTypeBuilder<CharacterDialogueAction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TriggerWord).HasMaxLength(128);
            builder.Property(x => x.NextCharacterStage).IsRequired(false);
            builder.Property(x => x.NextGameStage).IsRequired(false);

            builder.HasOne(x => x.CharacterDialogue).WithMany(y => y.CharacterDialogueActions).HasForeignKey(x => x.CharacterDialogueId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
