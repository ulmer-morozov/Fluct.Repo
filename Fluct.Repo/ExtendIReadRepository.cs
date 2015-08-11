using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fluct.Repo
{
    public static class ExtendIReadRepository
    {
        public static Task<IList<T>> GetMany<T>(this IRepository<T> repository, int offset = 0, int sequenceCount = int.MaxValue)
        {
            return repository.GetMany(x => true, offset, sequenceCount);
        }
    }
}