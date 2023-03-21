using Core.Entities;
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
        Task<IEnumerable<Actor>> GetActorByNameAsync(string name);
        Task<IEnumerable<Actor>> GetActorsAsync();
        Task CreateActorAsync(Actor actor);
        Task UpdateActorAsync(Actor actor);
        Task DeleteActorAsync(int id);

    }
}
