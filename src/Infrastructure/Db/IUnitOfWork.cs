using System.Threading.Tasks;

namespace Infrastructure.Db
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}