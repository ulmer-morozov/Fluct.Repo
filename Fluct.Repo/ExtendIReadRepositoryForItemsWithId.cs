using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluct.Repo
{
    public static class ExtendIReadRepositoryForItemsWithId
    {
        public static Task<T> GetOneById<T, TId>(this IRepository<T> repo, TId id)
            where T : IHaveId<TId>
        {
            return repo.GetOne(x => x.Id.Equals(id));
        }

        public static Task<IList<T>> GetManyById<T, TId>(this IRepository<T> repo, IEnumerable<TId> ids)
            where T : IHaveId<TId>
        {
            return repo.GetMany(x => ids.Contains(x.Id));
        }
    }
}
