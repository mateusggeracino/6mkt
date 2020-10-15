using _6MKT.BackOffice.Api.Models.Requests.Address;
using System.Collections.Generic;

namespace _6MKT.BackOffice.Api.Models.Requests.Business
{
    public class BusinessAddRequest
    {
        public string Email { get; set; }
        public string RegisteredNumber { get; set; }
        public string TradeName { get; set; }
        public string Phone { get; set; }
        public IEnumerable<int> Subcategories { get; set; }
        public AddressAddRequest Address { get; set; }
    }
}