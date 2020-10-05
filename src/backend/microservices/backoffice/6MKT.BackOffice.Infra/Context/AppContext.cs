using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _6MKT.BackOffice.Infra.Context
{
    public class AppContext : DbContext
    {
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}