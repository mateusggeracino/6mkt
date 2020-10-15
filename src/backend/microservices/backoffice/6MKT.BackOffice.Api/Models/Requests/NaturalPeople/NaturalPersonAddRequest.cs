using _6MKT.BackOffice.Api.Models.Requests.Address;

namespace _6MKT.BackOffice.Api.Models.Requests.NaturalPeople
{
    public class NaturalPersonAddRequest
    {
        public string Email { get; set; }
        public string SocialNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public AddressAddRequest Address { get; set; }
    }
}