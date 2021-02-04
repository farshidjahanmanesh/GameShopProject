using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    class TagConfig : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(c => c.TagName).IsRequired()
                .HasMaxLength(200);
            builder.HasMany(c => c.ProductTags)
                .WithOne(c => c.Tag)
                .HasForeignKey(c => c.Tagid)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
