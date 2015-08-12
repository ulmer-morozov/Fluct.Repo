using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fluct.Repo.Cakes.WithSugar.ForExpressions;

namespace Fluct.Repo
{
    public static class ExtendIRepositoryForIDeletable
    {
        public static Task<IList<T>> GetDeletable<T>(this IRepository<T> repo, bool isDeleted, Expression<Func<T, bool>> selector)
            where T : IDeletable
        {
            Expression<Func<T, bool>> additionalSelector = x => x.IsDeleted == isDeleted;
            var combinedSelector = selector.And(additionalSelector);
            var objects = repo.GetMany(combinedSelector);
            return objects;
        }

        public static Task<IList<T>> GetDeleted<T>(this IRepository<T> repo, Expression<Func<T, bool>> selector)
            where T : IDeletable
        {
            return GetDeletable(repo, true, selector);
        }

        public static Task<IList<T>> GetNotDeleted<T>(this IRepository<T> repo, Expression<Func<T, bool>> selector)
            where T : IDeletable
        {
            return GetDeletable(repo, false, selector);
        }

        public async static Task<IList<T>> MarkAsDeleted<T>(this IRepository<T> repo, Expression<Func<T, bool>> selector)
            where T : IDeletable
        {
            var objects = await GetNotDeleted(repo, selector);
            foreach (var obj in objects)
            {
                obj.MarkAsDeleted();
            }
            return objects;
        }

        public async static Task<T> MarkAsDeletedSingle<T>(this IRepository<T> repository, Expression<Func<T, bool>> selector)
            where T : IDeletable
        {
            var deletedArray = await MarkAsDeleted(repository, selector);
            var deleted = deletedArray.Single();
            return deleted;
        }
    }
}
