using _6MKT.Identity.Domain.Entities;
using _6MKT.Identity.Domain.ValueObjects.Tokens;
using System.Threading.Tasks;

namespace _6MKT.Identity.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> AddAsync(UserEntity user);
        Task<Token> LoginAsync(string email, string password);
    }
}