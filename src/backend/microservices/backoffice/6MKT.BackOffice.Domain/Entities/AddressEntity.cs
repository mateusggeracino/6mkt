using _6MKT.BackOffice.Domain.Entities.Base;

namespace _6MKT.BackOffice.Domain.Entities
{
    public class AddressEntity : Entity
    {
        public string Street { get; set; }
        public string Zipcode { get; set; }
        public string Neighborhood { get; set; }
    }
}