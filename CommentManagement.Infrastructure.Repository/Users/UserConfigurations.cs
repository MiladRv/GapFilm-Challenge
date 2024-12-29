using CommentManagement.Entity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pluralize.NET;

namespace CommentManagement.Infrastructure.Repository.Users
{
    public sealed class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var pluralizer = new Pluralizer();
            builder.ToTable(pluralizer.Pluralize(nameof(User)));

            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .Property(u => u.Email)
                .IsRequired();

            builder
                .HasIndex(u => u.Email);

            builder
                .HasMany(u => u.Comments)
                .WithOne()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
