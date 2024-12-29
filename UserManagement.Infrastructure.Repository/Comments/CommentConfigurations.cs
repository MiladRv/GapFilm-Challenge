using CommentManagement.Entity.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pluralize.NET;

namespace CommentManagement.Infrastructure.Repository.Comments
{
    internal class CommentConfigurations : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            var pluralizer = new Pluralizer();
            builder.ToTable(pluralizer.Pluralize(nameof(Comment)));

            builder
                .HasKey(c => c.Id);

            builder
                .Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .Property(c => c.Content)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}
