using _6MKT.BackOffice.Domain.Entities.Base;

namespace _6MKT.BackOffice.Domain.Entities
{
    public class ProviderEntity : Entity
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string SocialNumber { get; private set; }
    }
}