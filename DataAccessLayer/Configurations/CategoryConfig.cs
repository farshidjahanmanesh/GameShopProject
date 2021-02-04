using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.CategoryName).IsRequired()
                .HasMaxLength(200);
            builder.HasMany(c => c.ProductCategorys)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.Categoryid)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
