using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Adviser.Domain;

namespace Adviser.Application.Interfaces
{
    public interface IDbContext
    {
        DbSet<Comment>  Comments { get; set; }

        DbSet<Mark> Marks { get; set; }

        DbSet<Review> Reviews { get; set; }

        DbSet<Subject> Subjects { get; set; }

        DbSet<Tag> Tags { get; set; }

        DbSet<TagReview> TagReviews { get; set; }

        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
