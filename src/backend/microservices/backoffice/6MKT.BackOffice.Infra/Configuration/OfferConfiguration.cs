using _6MKT.BackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _6MKT.BackOffice.Infra.Configuration
{
    public class OfferConfiguration : IEntityTypeConfiguration<OfferEntity>
    {
        public void Configure(EntityTypeBuilder<OfferEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(500);

            builder
                .HasOne(x => x.Purchase)
                .WithMany(x => x.Offers)
                .HasForeignKey(x => x.PurchaseId)
                .OnDelete(DeleteBehavior.NoAction);
                                          
            builder.ToTable("Offer", "backoffice");
        }
    }
}