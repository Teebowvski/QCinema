using QCinema.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QCinema.Data.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAllAsync();
        Task AddAsync(Genre Genre);
        Task DeleteAsync(int id);
        Task<Genre> GetByIdAsync(int id);
        Task<Genre> UpdateAsync(Genre newGenre);
        IEnumerable<Genre> Genres(); 
    }
}
