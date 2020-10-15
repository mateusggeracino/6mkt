using _6MKT.BackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _6MKT.BackOffice.Infra.Configuration
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<PurchaseEntity>
    {
        public void Configure(EntityTypeBuilder<PurchaseEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.Title).HasMaxLength(150);
            
            builder
                .HasOne(x => x.SubCategory)
                .WithMany(x => x.Purchases)
                .HasForeignKey(x => x.SubCategoryId);
            
            builder.ToTable("Purchase", "backoffice");
        }
    }
}