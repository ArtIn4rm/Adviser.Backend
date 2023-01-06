using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Adviser.Domain;

namespace Adviser.Persistence.EntityTypeConfigurations
{
    public class CommentTypeConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(comment => comment.UserId);
            builder.HasIndex(comment => comment.UserId).IsUnique();
            builder.HasKey(comment => comment.ReviewId);
            builder.HasIndex(comment => comment.ReviewId).IsUnique();
            builder.Property(comment => comment.CommentText).HasMaxLength(200);
        }
    }
}
