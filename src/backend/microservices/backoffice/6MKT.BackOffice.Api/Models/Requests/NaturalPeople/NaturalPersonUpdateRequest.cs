using _6MKT.BackOffice.Api.Models.Requests.Address;

namespace _6MKT.BackOffice.Api.Models.Requests.NaturalPeople
{
    public class NaturalPersonUpdateRequest
    {
        public long Id { get; set; }
        public string SocialNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public AddressUpdateRequest Address { get; set; }
    }
}