using QCinema.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QCinema.Data.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAllAsync();
        Task AddAsync(Actor Actor);
        Task DeleteAsync(int id);
        Task<Actor> GetByIdAsync(int id);
        Task<Actor> UpdateAsync(Actor newActor);
        IEnumerable<Actor> Actors();
    }
}
