using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Paginator.Parameters;
using Core.Paginator;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Extensions;

namespace DataAccess.Repositories
{
    public class ContentRepository : PagedRepository<Content, ContentParameters>, IContentRepository
    {
        public ContentRepository(NoratorContext noratorContext) : base(noratorContext)
        {
            
        }

        //public async Task<PagedList<Content>> GetAllAsync(
        //   ContentParameters parameters,
        //   Expression<Func<Content, bool>>? filter = null,
        //   Func<IQueryable<Content>, IOrderedQueryable<Content>>? orderBy = null,
        //   Func<IQueryable<Content>, IIncludableQueryable<Content, object>>? includeProperties = null)
        //{
        //    var specializations = await GetQuery(
        //        filter,
        //        orderBy,
        //        includeProperties,
        //        asNoTracking: true)
        //        .ToPagedListAsync(parameters.PageNumber, parameters.PageSize);

        //    return specializations;
        //}

        //private IQueryable<Content> GetQuery(
        //   Expression<Func<Content, bool>>? filter = null,
        //   Func<IQueryable<Content>, IOrderedQueryable<Content>>? orderBy = null,
        //   Func<IQueryable<Content>, IIncludableQueryable<Content, object>>? includeProperties = null,
        //   bool asNoTracking = false)
        //{
        //    IQueryable<Content> specializationsQuery = (
        //        filter is null
        //        ? DbSet
        //        : DbSet.Where(filter)
        //    );

        //    if (includeProperties is not null)
        //        specializationsQuery = includeProperties(specializationsQuery);

        //    if (orderBy is not null)
        //        specializationsQuery = orderBy(specializationsQuery);

        //    if (asNoTracking)
        //        specializationsQuery = specializationsQuery.AsNoTracking();

        //    return specializationsQuery;
        //}
    }
}
