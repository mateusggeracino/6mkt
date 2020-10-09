using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Clock;
using _6MKT.BackOffice.Domain.Entities.Base;
using _6MKT.BackOffice.Infra.Configuration;
using _6MKT.BackOffice.Infra.Seeds;
using Microsoft.EntityFrameworkCore;

namespace _6MKT.BackOffice.Infra.Context
{
    public class MktContext : DbContext
    {
        private readonly IClock _clock;
        public MktContext(DbContextOptions options, IClock clock) : base(options)
        {
            _clock = clock;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BusinessConfiguration());
            modelBuilder.ApplyConfiguration(new NaturalPersonConfiguration());
            modelBuilder.ApplyConfiguration(new OfferConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
            modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.Seeds();
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var addedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToList();
            addedEntities.ForEach(entityEntry =>
            {
                if (!(entityEntry.Entity is Entity entity))
                    return;

                if (entityEntry.State == EntityState.Added)
                {
                    entity.CreatedAt = _clock.GetUtcNow();
                    //entity.CriadoPorId = _usuarioIdentidade?.UsuarioId;
                }

                if (entityEntry.State != EntityState.Modified) return;

                entity.ModifiedAt = _clock.GetUtcNow();
                //entity.ModificadoPorId = _usuarioIdentidade?.UsuarioId;
            });

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}