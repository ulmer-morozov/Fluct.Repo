using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fluct.Repo
{
    public class Repository<T> : IRepository<T>
    {
        private IQueryable<T> Items;

        public Repository(params T[] items)
        {
            Items = items.AsQueryable();
        }

        public async Task<IEnumerable<T>> Delete(IEnumerable<T> objects)
        {
            Items = Items.Except(objects);
            return objects;
        }

        public async Task<IList<T>> GetMany(Expression<Func<T, bool>> selector, int offset = 0, int sequenceCount = int.MaxValue)
        {
            return Items.Where(selector).Skip(offset).Take(sequenceCount).ToList();
        }

        public async Task<T> GetOne(Expression<Func<T, bool>> selector)
        {
            return Items.Single(selector);
        }

        public async Task<IEnumerable<T>> Store(IEnumerable<T> objects)
        {
            Items = Items.Concat(objects);
            return objects;
        }
    }
}