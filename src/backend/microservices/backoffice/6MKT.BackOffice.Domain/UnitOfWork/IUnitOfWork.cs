using System.Threading.Tasks;

namespace _6MKT.BackOffice.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}