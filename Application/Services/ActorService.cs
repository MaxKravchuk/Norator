using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var actor = await _actorRepository.GetByIdAsync(id);

            if(actor == null)
            {
                throw new NotFoundExeption();
            }

            return actor;
        }

        public async Task<Actor> GetActorByNameAsync(string name)
        {
            var actor = await _actorRepository.GetByNameAsync(name);

            if (actor == null)
            {
                throw new NotFoundExeption();
            }

            return actor;
        }

        public async Task<IEnumerable<Actor>> GetActorsAsync()
        {
            var actors = await _actorRepository.GetAsync(
                includeProperties: "Content_Actors.Content");

            return actors;
        }

        public async Task UpdateActorAsync(Actor actor)
        {
            _actorRepository.Update(actor);
            await _actorRepository.SaveChangesAsync();
        }
    }
}
