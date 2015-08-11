using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluct.Repo
{
    public static class ExtendIRepositoryForItemsWithId
    {
        public static Task<IEnumerable<T>> DeleteById<T, TId>(this IRepository<T> repository, IEnumerable<TId> ids)
            where T : IHaveId<TId>
        {
            return repository.Delete(x => ids.Contains(x.Id)); ;
        }

        public static Task<T> DeleteById<T, TId>(this IRepository<T> repository, TId id)
            where T : IHaveId<TId>
        {
            return repository.DeleteSingle(x => x.Id.Equals(id));
        }
    }
}
