using _6MKT.BackOffice.Domain.Entities.Base;
using _6MKT.BackOffice.Infra.Configuration;
using _6MKT.BackOffice.Infra.Seeds;
using _6MKT.Common.Clock;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.ValueObjects.UserIdentifier;

namespace _6MKT.BackOffice.Infra.Context
{
    public class MktContext : DbContext
    {
        private readonly IClock _clock;
        private readonly IUserIdentifier _userIdentifier;

        public MktContext(DbContextOptions options, IClock clock, IUserIdentifier userIdentifier) : base(options)
        {
            _clock = clock;
            _userIdentifier = userIdentifier;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BusinessConfiguration());
            modelBuilder.ApplyConfiguration(new BusinessSubCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new NaturalPersonConfiguration());
            modelBuilder.ApplyConfiguration(new OfferConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
            modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseCompletedConfiguration());

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
                    entity.CreatedId = _userIdentifier?.Id;
                }

                if (entityEntry.State != EntityState.Modified) return;

                entity.ModifiedAt = _clock.GetUtcNow();
                entity.ModifiedId = _userIdentifier?.Id;
            });

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}