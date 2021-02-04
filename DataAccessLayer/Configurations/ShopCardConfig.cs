using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    class ShopCardConfig : IEntityTypeConfiguration<ShopCard>
    {
        public void Configure(EntityTypeBuilder<ShopCard> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.CardDetails);
        }
    }
}
