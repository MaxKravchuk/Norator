using Core.Entities;
using Core.Interfaces.Repositories;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Paginator;
using Core.Paginator.Parameters;
using Core.Extensions;

namespace DataAccess.Repositories
{
    public class ActorRepository : PagedRepository<Actor, ActorParameters>, IActorRepository
    {
        public ActorRepository(NoratorContext noratorContext) : base(noratorContext)
        {
            
        }
        /*
        public async Task<PagedList<Actor>> GetAllAsync(
            ActorParameters parameters,
            Expression<Func<Actor, bool>>? filter = null,
            Func<IQueryable<Actor>, IOrderedQueryable<Actor>>? orderBy = null,
            Func<IQueryable<Actor>, IIncludableQueryable<Actor, object>>? includeProperties = null)
        {
            var specializations = await GetQuery(
                filter,
                orderBy,
                includeProperties,
                asNoTracking: true)
                .ToPagedListAsync(parameters.PageNumber, parameters.PageSize);

            return specializations;
        }

        private IQueryable<Actor> GetQuery(
           Expression<Func<Actor, bool>>? filter = null,
           Func<IQueryable<Actor>, IOrderedQueryable<Actor>>? orderBy = null,
           Func<IQueryable<Actor>, IIncludableQueryable<Actor, object>>? includeProperties = null,
           bool asNoTracking = false)
        {
            IQueryable<Actor> specializationsQuery = (
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
        */
    }
}
