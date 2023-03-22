using QCinema.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QCinema.Data.Services
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        Task AddAsync(Cinema Cinema);
        Task DeleteAsync(int id);
        Task<Cinema> GetByIdAsync(int id);
        Task<Cinema> UpdateAsync(Cinema newCinema);
        IEnumerable<Cinema> Cinemas();
    }
}
