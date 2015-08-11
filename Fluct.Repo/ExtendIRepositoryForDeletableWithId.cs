using System.Collections.Generic;
using System.Linq;

namespace Fluct.Repo
{
    public static class ExtendIRepositoryForDeletableWithId
    {
        public static IEnumerable<T> MarkAsDeletedById<T, TId>(this IRepository<T> repository, IEnumerable<TId> ids)
    where T : IHaveId<TId>, IDeletable
        {
            var deleted = repository.MarkAsDeleted(x => ids.Contains(x.Id));
            return deleted;
        }

        public static T MarkAsDeletedById<T, TId>(this IRepository<T> repository, TId id)
            where T : IHaveId<TId>, IDeletable
        {
            var deleted = repository.MarkAsDeletedSingle(x => x.Id.Equals(id));
            return deleted;
        }
    }
}
