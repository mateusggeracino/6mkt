using _6MKT.BackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _6MKT.BackOffice.Infra.Configuration
{
    public class BusinessConfiguration : IEntityTypeConfiguration<BusinessEntity>
    {
        public void Configure(EntityTypeBuilder<BusinessEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RegisteredNumber).HasMaxLength(20);
            builder.Property(x => x.TradeName).HasMaxLength(80);

            builder.ToTable("Business", "backoffice");
        }
    }
}