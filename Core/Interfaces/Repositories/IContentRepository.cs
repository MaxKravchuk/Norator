using Core.Entities;
using Core.Paginator.Parameters;
using Core.Paginator;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IContentRepository : IPagedRepository<Content, ContentParameters>
    {
        /*
        Task<PagedList<Content>> GetAllAsync(
            ContentParameters parameters,
            Expression<Func<Content, bool>>? filter = null,
            Func<IQueryable<Content>, IOrderedQueryable<Content>>? orderBy = null,
            Func<IQueryable<Content>, IIncludableQueryable<Content, object>>? includeProperties = null);
        */
    }
}
