using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.StartDate);
            builder.Property(x => x.FinishDate).IsRequired(false);
            builder.Property(x => x.GameStage);

            builder.HasOne(x => x.Game).WithMany(y => y.Sessions).HasForeignKey(x => x.GameId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.AppUser).WithMany(y => y.Sessions).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
