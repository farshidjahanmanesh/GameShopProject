using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(c => c.FirstName).HasMaxLength(250).IsRequired();
            builder.Property(c => c.FamilyName).HasMaxLength(250).IsRequired();
            builder.HasOne(c => c.Wallet).WithOne(c => c.User).HasForeignKey<User>(c => c.WalletId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(c => c.Card).WithOne(c => c.User).HasForeignKey<User>(c => c.CardId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
