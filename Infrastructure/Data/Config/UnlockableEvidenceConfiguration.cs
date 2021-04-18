using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class UnlockableEvidenceConfiguration : IEntityTypeConfiguration<UnlockableEvidence>
    {
        public void Configure(EntityTypeBuilder<UnlockableEvidence> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.GameStage);

            builder.HasOne(x => x.Game).WithMany(y => y.UnlockableEvidence).HasForeignKey(x => x.GameId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Evidence).WithMany(y => y.UnlockableEvidence).HasForeignKey(x => x.EvidenceId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
