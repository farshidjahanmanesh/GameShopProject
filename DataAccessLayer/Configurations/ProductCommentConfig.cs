using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    class ProductCommentConfig : IEntityTypeConfiguration<ProductComment>
    {
        public void Configure(EntityTypeBuilder<ProductComment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(300).IsRequired(true);
            builder.Property(c => c.Email).HasMaxLength(300).IsRequired(true);
            builder.Property(c => c.Comment).HasMaxLength(700).IsRequired(true);
            builder.HasMany(c => c.ChildComments).WithOne(c => c.ParentComment)
                .HasForeignKey(c => c.ParentCommentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
