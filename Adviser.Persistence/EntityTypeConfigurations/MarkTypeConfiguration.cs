using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Adviser.Domain;

namespace Adviser.Persistence.EntityTypeConfigurations
{
    public class MarkTypeConfiguration : IEntityTypeConfiguration<Mark>
    {
        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder.HasKey(mark => mark.UserId);
            builder.HasIndex(mark => mark.UserId).IsUnique();
            builder.HasKey(mark => mark.ReviewId);
            builder.HasIndex(mark => mark.ReviewId).IsUnique();
        }
    }
}
