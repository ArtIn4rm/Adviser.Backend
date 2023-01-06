using Adviser.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adviser.Persistence.EntityTypeConfigurations
{
    public class TagTypeConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(tag => tag.Name);
            builder.HasIndex(tag => tag.Name).IsUnique();
            builder.Property(tag => tag.Name).HasMaxLength(20);
        }
    }
}
