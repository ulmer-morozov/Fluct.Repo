using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fluct.Repo
{
    public interface IRepository<T>
        : IReadRepository<T>
    {
        Task<IEnumerable<T>> Store(IEnumerable<T> objects);
        Task<IEnumerable<T>> Delete(IEnumerable<T> objects);
    }
}
