using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Adviser.Domain;

namespace Adviser.Persistence.EntityTypeConfigurations
{
    public class SubjectTypeConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(subject => subject.Id);
            builder.HasIndex(subject => subject.Id).IsUnique();
            builder.Property(subject => subject.Name).HasMaxLength(50);
        }
    }
}
