using Adviser.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adviser.Persistence.EntityTypeConfigurations
{
    public class TagReviewTypeConfiguration : IEntityTypeConfiguration<TagReview>
    {
        public void Configure(EntityTypeBuilder<TagReview> builder)
        {
            builder.HasKey(tag => tag.TagId);
            builder.HasIndex(tag => tag.TagId).IsUnique();
            builder.Property(tag => tag.TagId).HasMaxLength(20);
            builder.HasKey(tag => tag.ReviewId);
            builder.HasIndex(tag => tag.ReviewId).IsUnique();
        }
    }
}
