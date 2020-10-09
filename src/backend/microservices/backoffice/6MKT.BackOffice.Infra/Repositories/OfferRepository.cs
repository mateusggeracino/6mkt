using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Infra.Context;
using _6MKT.BackOffice.Infra.Repositories.Base;

namespace _6MKT.BackOffice.Infra.Repositories
{
    public class OfferRepository : RepositoryBase<OfferEntity>, IOfferRepository
    {
        public OfferRepository(MktContext context) : base(context)
        {
        }
    }
}