using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Paginator.Parameters;
using Core.Paginator;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Core.Extensions;

namespace DataAccess.Repositories
{
    public class PagedRepository<T, V> : Repository<T>, IPagedRepository<T, V> where T: class where V : ElementParameters
    {
        private readonly NoratorContext _noratorContext;
        protected readonly DbSet<T> DbSet;

        public PagedRepository(NoratorContext NoratorContext) : base(NoratorContext)
        {
            _noratorContext = NoratorContext;
            DbSet = _noratorContext.Set<T>();
        }

        public async Task<PagedList<T>> GetAllAsync(
            V parameters,
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? includeProperties = null)
        {
            var specializations = await GetPagedQuery(
                filter,
                orderBy,
                includeProperties,
                asNoTracking: true)
                .ToPagedListAsync(parameters.PageNumber, parameters.PageSize);

            return specializations;
        }

        public IQueryable<T> GetPagedQuery(
           Expression<Func<T, bool>>? filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>>? includeProperties = null,
           bool asNoTracking = false)
        {
            IQueryable<T> specializationsQuery = (
                filter is null
                ? DbSet
                : DbSet.Where(filter)
            );

            if (includeProperties is not null)
                specializationsQuery = includeProperties(specializationsQuery);

            if (orderBy is not null)
                specializationsQuery = orderBy(specializationsQuery);

            if (asNoTracking)
                specializationsQuery = specializationsQuery.AsNoTracking();

            return specializationsQuery;
        }
    }
}
