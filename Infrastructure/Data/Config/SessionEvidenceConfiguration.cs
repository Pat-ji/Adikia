using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class SessionEvidenceConfiguration : IEntityTypeConfiguration<SessionEvidence>
    {
        public void Configure(EntityTypeBuilder<SessionEvidence> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Session).WithMany(y => y.SessionEvidence).HasForeignKey(x => x.SessionId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Evidence).WithMany(y => y.SessionEvidence).HasForeignKey(x => x.SessionId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
