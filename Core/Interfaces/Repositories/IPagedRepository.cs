using Core.Paginator;
using Core.Paginator.Parameters;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IPagedRepository<T, V> : IRepository<T>
        where T : class
        where V : class
    {
        Task<PagedList<T>> GetAllAsync(
            V parameters,
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? includeProperties = null);

        IQueryable<T> GetPagedQuery(
           Expression<Func<T, bool>>? filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>>? includeProperties = null,
           bool asNoTracking = false);
    }
}
