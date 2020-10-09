namespace _6MKT.BackOffice.Api.Models.Requests.SubCategories
{
    public class SubCategoryUpdateRequest
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
    }
}