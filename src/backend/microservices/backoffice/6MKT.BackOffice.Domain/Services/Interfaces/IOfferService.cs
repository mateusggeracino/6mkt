using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;

namespace _6MKT.BackOffice.Domain.Services.Interfaces
{
    public interface IOfferService : IService<OfferEntity>
    {
        Task AddAsync(OfferEntity offer);
    }
}