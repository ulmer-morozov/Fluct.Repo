using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fluct.Repo
{
    public interface IRepository<T>
        : IReadRepository<T>
    {
        Task<IList<T>> Store(IEnumerable<T> objects);
        Task<IList<T>> Delete(IEnumerable<T> objects);
    }
}
