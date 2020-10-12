using _6MKT.Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _6MKT.Identity.Infra.Context
{
    public class IdentityContext : IdentityDbContext<UserEntity>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }
    }
}