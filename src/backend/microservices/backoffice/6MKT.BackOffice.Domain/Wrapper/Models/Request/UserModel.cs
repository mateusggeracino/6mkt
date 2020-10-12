using _6MKT.BackOffice.Domain.Enums;

namespace _6MKT.BackOffice.Domain.Wrapper.Models.Request
{
    public class UserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public UserEnum Type { get; set; }
    }
}