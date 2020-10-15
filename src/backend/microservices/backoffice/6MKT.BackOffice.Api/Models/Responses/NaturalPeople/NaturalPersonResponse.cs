using _6MKT.BackOffice.Api.Models.Responses.Address;

namespace _6MKT.BackOffice.Api.Models.Responses.NaturalPeople
{
    public class NaturalPersonResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SocialNumber { get; set; }
        public string Phone { get; set; }

        public AddressResponse Address { get; set; }
    }
}