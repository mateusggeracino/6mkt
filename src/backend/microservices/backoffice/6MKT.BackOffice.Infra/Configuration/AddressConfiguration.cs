using _6MKT.BackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _6MKT.BackOffice.Infra.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Street).HasMaxLength(200);
            builder.Property(x => x.Zipcode).HasMaxLength(15);
            builder.Property(x => x.Neighborhood).HasMaxLength(100);

            builder.ToTable("Address", "backoffice");
        }
    }
}