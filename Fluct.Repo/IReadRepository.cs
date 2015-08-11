using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fluct.Repo
{
    public interface IReadRepository<T>
    {
        Task<IList<T>> GetMany(Expression<Func<T, bool>> selector, int offset = 0, int sequenceCount = int.MaxValue);
        Task<T> GetOne(Expression<Func<T, bool>> selector);
    }
}