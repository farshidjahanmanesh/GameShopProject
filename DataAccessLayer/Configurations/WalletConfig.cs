using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    class WalletConfig : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany<WalletSummery>().WithOne(c => c.Wallet)
                .HasForeignKey(d => d.WalletId).OnDelete(DeleteBehavior.SetNull);

        }
    }
}
