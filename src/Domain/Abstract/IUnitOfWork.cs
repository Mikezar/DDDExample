using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IUnitOfWork
    {
         Task SaveChangesAsync();
    }
}