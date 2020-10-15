using System.Collections.Generic;
using _6MKT.BackOffice.Api.Models.Requests.Address;

namespace _6MKT.BackOffice.Api.Models.Requests.Business
{
    public class BusinessUpdateRequest
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string TradeName { get; set; }
        public string Phone { get; set; }
        public IEnumerable<long> Subcategories { get; set; } 
        public AddressUpdateRequest Address { get; set; }
    }
}