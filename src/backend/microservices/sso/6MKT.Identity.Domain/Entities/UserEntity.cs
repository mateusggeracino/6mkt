using _6MKT.Identity.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace _6MKT.Identity.Domain.Entities
{
    public class UserEntity : IdentityUser
    {
        public string Name { get; set; }
        public string FirstPassword { get; set; }
        public bool Active { get; set; }
        public UserEnum Type { get; set; }
    }
}