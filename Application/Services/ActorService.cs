using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Paginator;
using Core.Paginator.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }


        public async Task CreateActorAsync(Actor actor)
        {
            await _actorRepository.InsertAsync(actor);
            await _actorRepository.SaveChangesAsync();
        }

        public async Task DeleteActorAsync(int id)
        {
            var actorToDelete = await GetActorByIdAsync(id);

            _actorRepository.Delete(actorToDelete);
            await _actorRepository.SaveChangesAsync();
        }

        public async Task<Actor> GetActorByIdAsync(int id)
        {
            var actor = await _actorRepository.GetByIdAsync(id, includeProperties: "Content_Actors.Content");

            if(actor == null)
            {
                throw new NotFoundException();
            }

            return actor;
        }

        public async Task<IEnumerable<Actor>> GetActorByNameAsync(string name)
        {
            var actors = await _actorRepository.GetAsync(includeProperties: "Content_Actors.Content");
            var result = actors.Where(a => a.Name.Contains(name));

            if (result == null)
            {
                throw new NotFoundException();
            }

            return result;
        }

        public async Task<PagedList<Actor>> GetActorsAsync(ActorParameters actorParameters)
        {
            var filterQuery = GetFilterQuery(actorParameters.FilterParam);

            var actors = await _actorRepository.GetAllAsync(
                parameters: actorParameters,
                filter: filterQuery,
                includeProperties: q => q
                .Include(a => a.Content_Actors));

            return actors;
        }

        public async Task UpdateActorAsync(Actor actor)
        {
            _actorRepository.Update(actor);
            await _actorRepository.SaveChangesAsync();
        }
        private static Expression<Func<Actor, bool>>? GetFilterQuery(string? filterParam)
        {
            Expression<Func<Actor, bool>>? filterQuery = null;

            if (filterParam is not null)
            {
                string formatedFilter = filterParam.Trim().ToLower();

                filterQuery = u => u.Name!.ToLower().Contains(formatedFilter);
            }

            return filterQuery;
        }
    }
}
