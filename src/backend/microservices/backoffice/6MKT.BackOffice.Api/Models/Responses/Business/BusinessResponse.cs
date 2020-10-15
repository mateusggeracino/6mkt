using System.Collections.Generic;
using _6MKT.BackOffice.Api.Models.Responses.SubCategories;

namespace _6MKT.BackOffice.Api.Models.Responses.Business
{
    public class BusinessResponse
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string RegisteredNumber { get; set; }
        public string TradeName { get; set; }
        public string Phone { get; set; }
        public IEnumerable<SubCategoryResponse> SubCategories { get; set; }
    }
}