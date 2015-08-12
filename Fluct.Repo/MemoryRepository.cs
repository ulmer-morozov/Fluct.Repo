using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fluct.Repo.Cakes.WithSugar.ForTasks;

namespace Fluct.Repo
{
    public class MemoryRepository<T> : IRepository<T>
    {
        private IQueryable<T> _items;

        public MemoryRepository(params T[] items)
        {
            _items = items.AsQueryable();
        }

        public Task<IList<T>> Delete(IEnumerable<T> objects)
        {
            var objectList = objects as IList<T> ?? objects.ToList();
            _items = _items.Except(objectList);
            var task = AsyncHelpers.StartNewTask(() => objectList);
            return task;
        }

        public Task<IList<T>> GetMany(Expression<Func<T, bool>> selector, int offset = 0, int sequenceCount = int.MaxValue)
        {
            IList<T> objects = _items.Where(selector).Skip(offset).Take(sequenceCount).ToList();
            var task = AsyncHelpers.StartNewTask(() => objects);
            return task;
        }

        public Task<T> GetOne(Expression<Func<T, bool>> selector)
        {
            var obj = _items.Single(selector);
            var task = AsyncHelpers.StartNewTask(() => obj);
            return task;
        }

        public Task<IList<T>> Store(IEnumerable<T> objects)
        {
            var objectList = objects as IList<T> ?? objects.ToList();
            _items = _items.Concat(objectList);
            var task = AsyncHelpers.StartNewTask(() => objectList);
            return task;
        }
    }
}