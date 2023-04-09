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
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly ILoggerManager _loggerManager;

        public ActorService(IActorRepository actorRepository, ILoggerManager loggerManager)
        {
            _actorRepository = actorRepository;
            _loggerManager = loggerManager;
        }

        public async Task CreateActorAsync(Actor actor)
        {
            try
            {
                await _actorRepository.InsertAsync(actor);
                await _actorRepository.SaveChangesAsync();
                _loggerManager.LogInfo($"Adding actor {actor.Name} successful");
            }
            catch
            {
                _loggerManager.LogError("$Adding actor {actor.Name} error");
            }
        }

        public async Task DeleteActorAsync(int id)
        {
            var actorToDelete = await GetActorByIdAsync(id);
            _actorRepository.Delete(actorToDelete);
            await _actorRepository.SaveChangesAsync();
            _loggerManager.LogInfo($"Deleting actor {actorToDelete.Name} successful");
        }

        public async Task<Actor> GetActorByIdAsync(int id)
        {
            var actor = await _actorRepository.GetByIdAsync(id, includeProperties: "Content_Actors.Content");
            if (actor == null)
            {
                _loggerManager.LogError($"Failed to find {id} actor");
                throw new NotFoundException();
            }
            _loggerManager.LogInfo($"Getting actor {id} successful");
            return actor;
        }

        public async Task<PagedList<Actor>> GetActorsAsync(ActorParameters actorParameters)
        {

            var filterQuery = GetFilterQuery(actorParameters.FilterParam);

            var actors = await _actorRepository.GetAllAsync(
                parameters: actorParameters,
                filter: filterQuery,
                includeProperties: q => q
                .Include(a => a.Content_Actors));

            _loggerManager.LogInfo($"Getting {actors.Count} actors");

            return actors;

        }

        public async Task UpdateActorAsync(Actor actor)
        {
            try
            {
                _actorRepository.Update(actor);
                await _actorRepository.SaveChangesAsync();
                _loggerManager.LogError($"Updating actor {actor.Name} successful");
            }
            catch
            {
                _loggerManager.LogError($"Updating actor {actor.Name} error");
            }
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
