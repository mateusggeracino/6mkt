using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.ValueObjects.UserIdentifier;

namespace _6MKT.BackOffice.Domain.Services.Interfaces
{
    public interface IUserIdentifierService
    {
        Task<IUserIdentifier> GetUserAsync(string providerId, string type);
    }
}