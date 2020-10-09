using _6MKT.BackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace _6MKT.BackOffice.Infra.Seeds
{
    public static class GenerateSeed
    {
        public static void Seeds(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<CategoryEntity>()
                .HasData(CategoryEntity.Seed());

            modelBuilder
                .Entity<SubCategoryEntity>()
                .HasData(SubCategoryEntity.Seed());
        }
    }
}