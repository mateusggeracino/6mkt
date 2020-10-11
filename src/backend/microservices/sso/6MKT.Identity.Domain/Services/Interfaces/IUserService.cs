using System.Threading.Tasks;
using _6MKT.Identity.Domain.Entities;
using _6MKT.Identity.Domain.ValueObjects.Tokens;

namespace _6MKT.Identity.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserEntity> AddAsync(UserEntity user);
        Task<Token> LoginAsync(UserEntity user);
    }
}