using _6MKT.BackOffice.Api.Models.Responses.Categories;

namespace _6MKT.BackOffice.Api.Models.Responses.SubCategories
{
    public class SubCategoryResponse
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
    }
}