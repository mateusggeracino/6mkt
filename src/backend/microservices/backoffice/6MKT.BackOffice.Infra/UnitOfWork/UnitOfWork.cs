using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.UnitOfWork;
using _6MKT.BackOffice.Infra.Context;

namespace _6MKT.BackOffice.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MktContext _appContext;

        public UnitOfWork(MktContext appContext) => _appContext = appContext;

        public async Task<bool> Commit() => await _appContext.SaveChangesAsync() > 0;
    }
}