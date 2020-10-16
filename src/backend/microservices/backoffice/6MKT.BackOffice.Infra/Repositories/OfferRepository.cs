using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Infra.Context;
using _6MKT.BackOffice.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace _6MKT.BackOffice.Infra.Repositories
{
    public class OfferRepository : RepositoryBase<OfferEntity>, IOfferRepository
    {
        public OfferRepository(MktContext context) : base(context)
        {
        }

        public override async Task<OfferEntity> GetById(long id) =>
            await DbSet.FirstOrDefaultAsync(x => x.Id == id);
    }
}