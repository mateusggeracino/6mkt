using _6MKT.BackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _6MKT.BackOffice.Infra.Configuration
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<SubCategoryEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(500);

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.SubCategories)
                .HasForeignKey(x => x.CategoryId);

            builder.ToTable("SubCategory", "backoffice");
        }
    }
}