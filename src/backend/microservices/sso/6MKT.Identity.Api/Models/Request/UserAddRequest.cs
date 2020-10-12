using _6MKT.Identity.Domain.Enums;

namespace _6MKT.Identity.Api.Models.Request
{
    public class UserAddRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public UserEnum Type { get; set; }
    }
}