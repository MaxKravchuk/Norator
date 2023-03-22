using Core.Entities;
using Core.Paginator;
using Core.Paginator.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IActorService
    {
        Task<Actor> GetActorByIdAsync(int id);
        Task<PagedList<Actor>> GetActorsAsync(ActorParameters actorParameters);
        Task CreateActorAsync(Actor actor);
        Task UpdateActorAsync(Actor actor);
        Task DeleteActorAsync(int id);

    }
}
