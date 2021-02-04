using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    class WalletSummeryConfig : IEntityTypeConfiguration<WalletSummery>
    {
        public void Configure(EntityTypeBuilder<WalletSummery> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Detail).HasMaxLength(600);
            builder.HasOne(c => c.Wallet).WithMany(c => c.WalletSummeries)
                .HasForeignKey(c => c.WalletId);

        }
    }
}
