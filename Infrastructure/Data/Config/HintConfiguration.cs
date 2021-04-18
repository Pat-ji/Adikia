using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class HintConfiguration : IEntityTypeConfiguration<Hint>
    {
        public void Configure(EntityTypeBuilder<Hint> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.GameStage);
            builder.Property(x => x.Information).HasMaxLength(256);

            builder.HasOne(x => x.Game).WithMany(y => y.Hints).HasForeignKey(x => x.GameId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
