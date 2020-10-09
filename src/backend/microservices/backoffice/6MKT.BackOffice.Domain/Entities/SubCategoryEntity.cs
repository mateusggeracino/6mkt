using _6MKT.BackOffice.Domain.Entities.Base;
using System.Collections.Generic;

namespace _6MKT.BackOffice.Domain.Entities
{
    public class SubCategoryEntity : Entity
    {
        public string Description { get; set; }

        public long CategoryId { get; set; }
        public CategoryEntity Category { get; set; }

        public IEnumerable<PurchaseEntity> Purchases { get; set; }

        public static IEnumerable<SubCategoryEntity> Seed()
        {
            return new List<SubCategoryEntity>
            {
                new SubCategoryEntity{Id = 1, Description = "Banheiros", CategoryId = 1},
                new SubCategoryEntity{Id = 2, Description = "Colchões e Camas Box", CategoryId = 1},
                new SubCategoryEntity{Id = 3, Description = "Cortinas e Acessórios", CategoryId = 1},
                new SubCategoryEntity{Id = 4, Description = "Móveis para Casa", CategoryId = 1},

                new SubCategoryEntity{Id = 5, Description = "Acessórios para Celulares", CategoryId = 2},
                new SubCategoryEntity{Id = 6, Description = "Celulares e Smartphones", CategoryId = 2},
                new SubCategoryEntity{Id = 7, Description = "Tarifadores e Cabines", CategoryId = 2},

                new SubCategoryEntity{Id = 8, Description = "Consoles", CategoryId = 3},
                new SubCategoryEntity{Id = 9, Description = "Peças para Consoles", CategoryId = 3},
                new SubCategoryEntity{Id = 10, Description = "Acessórios para PC Gaming", CategoryId = 3},
                new SubCategoryEntity{Id = 11, Description = "Video Games", CategoryId = 3},
            };
        }
    }
}