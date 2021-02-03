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

        }
    }

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

    class WalletConfig : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany<WalletSummery>().WithOne(c => c.Wallet)
                .HasForeignKey(d => d.WalletId).OnDelete(DeleteBehavior.SetNull);

        }
    }

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

    class ShopCardConfig : IEntityTypeConfiguration<ShopCard>
    {
        public void Configure(EntityTypeBuilder<ShopCard> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.CardDetails);
        }
    }

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
