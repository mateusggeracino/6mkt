using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.ValueObjects.Token;
using _6MKT.BackOffice.Domain.Wrapper.Models.Request;
using Refit;

namespace _6MKT.BackOffice.Domain.Wrapper.Endpoint
{
    public interface IUserSsoEndpoint
    {
        [Post("/api/user")]
        Task<ApiResponse<string>> Add(UserModel user);
    }
}