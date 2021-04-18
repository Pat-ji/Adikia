using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class CharacterDialogueConfiguration : IEntityTypeConfiguration<CharacterDialogue>
    {
        public void Configure(EntityTypeBuilder<CharacterDialogue> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CharacterStage);

            builder.HasOne(x => x.Character).WithMany(y => y.CharacterDialogues).HasForeignKey(x => x.CharacterId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Dialogue).WithMany(y => y.CharacterDialogues).HasForeignKey(x => x.DialogueId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
