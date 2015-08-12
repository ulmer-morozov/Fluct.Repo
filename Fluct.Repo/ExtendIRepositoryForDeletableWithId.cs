using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluct.Repo
{
    public static class ExtendIRepositoryForDeletableWithId
    {
        public static Task<IList<T>> MarkAsDeletedById<T, TId>(this IRepository<T> repository, IEnumerable<TId> ids)
    where T : IHaveId<TId>, IDeletable
        {
            var deleted = repository.MarkAsDeleted(x => ids.Contains(x.Id));
            return deleted;
        }

        public static Task<T> MarkAsDeletedById<T, TId>(this IRepository<T> repository, TId id)
            where T : IHaveId<TId>, IDeletable
        {
            var deleted = repository.MarkAsDeletedSingle(x => x.Id.Equals(id));
            return deleted;
        }
    }
}
