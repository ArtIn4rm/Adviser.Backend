using Adviser.Domain;
using Adviser.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Adviser.Persistence.EntityTypeConfigurations;

namespace Adviser.Persistence
{
    public class AppDbContext : DbContext, IDbContext
    {
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<TagReview> TagReviews { get; set; }

        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new CommentTypeConfiguration())
                .ApplyConfiguration(new MarkTypeConfiguration())
                .ApplyConfiguration(new ReviewTypeConfiguration())
                .ApplyConfiguration(new SubjectTypeConfiguration())
                .ApplyConfiguration(new TagTypeConfiguration())
                .ApplyConfiguration(new TagReviewTypeConfiguration())
                .ApplyConfiguration(new UserTypeConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
