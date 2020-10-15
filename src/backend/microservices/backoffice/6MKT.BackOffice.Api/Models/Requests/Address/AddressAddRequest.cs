namespace _6MKT.BackOffice.Api.Models.Requests.Address
{
    public class AddressUpdateRequest
    {
        public long Id { get; set; }
        public string Street { get; set; }
        public string Zipcode { get; set; }
        public string Neighborhood { get; set; }
    }
}