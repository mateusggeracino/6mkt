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

        }
    }
}