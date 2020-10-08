using System.Threading;
using System.Threading.Tasks;
using _6MKT.BackOffice.Infra.Configuration;
using Microsoft.EntityFrameworkCore;

namespace _6MKT.BackOffice.Infra.Context
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new BusinessConfiguration());
            //modelBuilder.ApplyConfiguration(new NaturalPersonConfiguration());

            //modelBuilder.SeedData();
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}