using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Adviser.Domain;

namespace Adviser.Persistence.EntityTypeConfigurations
{
    public class ReviewTypeConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(review => review.Id);
            builder.HasIndex(review => review.Id).IsUnique();
            builder.Property(review => review.Name).HasMaxLength(50);
            builder.Property(review => review.MarkdownContent).HasMaxLength(300);
            builder.Property(review => review.Wallpaper).HasMaxLength(200);
        }
    }
}
