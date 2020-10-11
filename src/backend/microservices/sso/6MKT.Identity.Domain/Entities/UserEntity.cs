using Microsoft.AspNetCore.Identity;

namespace _6MKT.Identity.Domain.Entities
{
    public class UserEntity : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }
    }
}