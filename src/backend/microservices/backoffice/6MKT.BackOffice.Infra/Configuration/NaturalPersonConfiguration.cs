using _6MKT.BackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _6MKT.BackOffice.Infra.Configuration
{
    public class NaturalPersonConfiguration : IEntityTypeConfiguration<NaturalPersonEntity>
    {
        public void Configure(EntityTypeBuilder<NaturalPersonEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.LastName).HasMaxLength(80);
            builder.Property(x => x.SocialNumber).HasMaxLength(14);
            builder.Property(x => x.Phone).HasMaxLength(30);
            builder.Property(x => x.Email).HasMaxLength(200);

            builder.HasOne(x => x.Address);

            builder.ToTable("NaturalPerson","backoffice");
        }
    }
}