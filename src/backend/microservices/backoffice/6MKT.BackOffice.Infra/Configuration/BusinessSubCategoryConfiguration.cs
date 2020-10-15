using _6MKT.BackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _6MKT.BackOffice.Infra.Configuration
{
    public class BusinessSubCategoryConfiguration : IEntityTypeConfiguration<BusinessSubCategory>
    {
        public void Configure(EntityTypeBuilder<BusinessSubCategory> builder)
        {
            builder.HasKey(x => new { x.SubCategoryId, x.BusinessId });

            builder
                .HasOne(x => x.SubCategory)
                .WithMany(x => x.Businesses)
                .HasForeignKey(x => x.SubCategoryId);

            builder
                .HasOne(x => x.Business)
                .WithMany(x => x.SubCategories)
                .HasForeignKey(x => x.BusinessId);

            builder.ToTable("BusinessSubCategory", "backoffice");
        }
    }
}