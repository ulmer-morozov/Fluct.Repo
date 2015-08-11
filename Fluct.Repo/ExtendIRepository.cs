using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fluct.Repo
{
    public static class ExtendIRepository
    {
        public async static Task<T> Store<T>(this IRepository<T> repository, T obj)
        {
            var storedObjects = await repository.Store(new[] { obj });
            var result = storedObjects.Single();
            return result;
        }

        public async static Task<IEnumerable<T>> Delete<T>(this IRepository<T> repository, Expression<Func<T, bool>> selector)
        {
            var objectsForDeletion = await repository.GetMany(selector);
            var deleted = await repository.Delete(objectsForDeletion);
            return deleted;
        }

        public async static Task<T> DeleteSingle<T>(this IRepository<T> repository, Expression<Func<T, bool>> selector)
        {
            var objectForDeletion = await repository.GetOne(selector);
            var deletedArray = await repository.Delete(new[] { objectForDeletion });
            var deleted = deletedArray.Single();
            return deleted;
        }

    }
}
