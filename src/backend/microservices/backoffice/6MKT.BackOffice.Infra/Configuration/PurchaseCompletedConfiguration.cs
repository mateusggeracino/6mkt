using _6MKT.BackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _6MKT.BackOffice.Infra.Configuration
{
    public class PurchaseCompletedConfiguration : IEntityTypeConfiguration<PurchaseCompletedEntity>
    {
        public void Configure(EntityTypeBuilder<PurchaseCompletedEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Offer).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Purchase).WithOne().OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("PurchaseCompleted", "backoffice");
        }
    }
}