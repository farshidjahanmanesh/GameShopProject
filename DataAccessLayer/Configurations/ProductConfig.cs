using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations
{
    class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(300).IsRequired(true);
            builder.Property(c => c.Detail).IsRequired(true);
            builder.HasMany(c => c.Comments).WithOne(c => c.Product).HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.ProductTags).WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(c => c.ProductCategorys).WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
