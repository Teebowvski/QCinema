using QCinema.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QCinema.Data.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task AddAsync(Movie movie);
        Task<Movie> UpdateAsync(Movie newMovie);
        Task<Movie> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        IEnumerable<Movie> Movies();
        IEnumerable<Movie> FeaturedMovies();
    }
}
