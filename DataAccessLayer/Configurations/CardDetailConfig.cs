using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    class CardDetailConfig : IEntityTypeConfiguration<CardDetail>
    {
        public void Configure(EntityTypeBuilder<CardDetail> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Product)
                .WithMany().HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
