
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Fluct.Repo
{
    public static class ExtendIRepositoryForIDeletable
    {
        public async static IEnumerable<T> GetDeletable<T>(this IRepository<T> repo, bool isDeleted, Expression<Func<T, bool>> selector)
            where T : IDeletable
        {
            Expression<Func<T, bool>> additionalSelector = x => x.IsDeleted == isDeleted;
            Expression<Func<T, bool>> combinedSelector = x => true;//тут нужно исправить
            throw new NotImplementedException();
            var objects = repo.GetMany(combinedSelector);
            return objects;
        }

        public static IEnumerable<T> GetDeleted<T>(this IRepository<T> repo, Expression<Func<T, bool>> selector)
            where T : IDeletable
        {
            return GetDeletable(repo, true, selector);
        }

        public static IEnumerable<T> GetNotDeleted<T>(this IRepository<T> repo, Expression<Func<T, bool>> selector)
            where T : IDeletable
        {
            return GetDeletable(repo, false, selector);
        }

        public static IEnumerable<T> MarkAsDeleted<T>(this IRepository<T> repo, Expression<Func<T, bool>> selector)
            where T : IDeletable
        {
            var objects = GetNotDeleted(repo, selector);
            foreach (var obj in objects)
            {
                obj.MarkAsDeleted();
            }
            return objects;
        }

        public static T MarkAsDeletedSingle<T>(this IRepository<T> repository, Expression<Func<T, bool>> selector)
            where T : IDeletable
        {
            var deletedArray = MarkAsDeleted(repository, selector);
            var deleted = deletedArray.Single();
            return deleted;
        }
    }
}
