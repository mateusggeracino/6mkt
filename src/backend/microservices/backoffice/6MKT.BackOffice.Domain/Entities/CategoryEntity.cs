using _6MKT.BackOffice.Domain.Entities.Base;
using System.Collections.Generic;

namespace _6MKT.BackOffice.Domain.Entities
{
    public class CategoryEntity : Entity
    {
        public string Description { get; set; }

        public IEnumerable<SubCategoryEntity> SubCategories { get; set; }

        public static IEnumerable<CategoryEntity> Seed()
        {
            return new List<CategoryEntity>
            {
                new CategoryEntity { Id = 1, Description = "Casa, Móveis e Decoração" },
                new CategoryEntity { Id = 2, Description = "Celulares e Telefones" },
                new CategoryEntity { Id = 3, Description = "Games" }
            };
        }
    }
}