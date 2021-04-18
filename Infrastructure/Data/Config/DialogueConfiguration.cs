using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class DialogueConfiguration : IEntityTypeConfiguration<Dialogue>
    {
        public void Configure(EntityTypeBuilder<Dialogue> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Messages);
        }
    }
}
