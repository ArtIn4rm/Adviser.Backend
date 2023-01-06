using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Adviser.Domain;

namespace Adviser.Persistence.EntityTypeConfigurations
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Id).IsUnique();
            builder.Property(user => user.Name).HasMaxLength(40);
            builder.Property(user => user.Email).HasMaxLength(30);
            builder.Property(user => user.PasswordHash).HasMaxLength(65);
        }
    }
}
