using Microsoft.EntityFrameworkCore;
using QCinema.Data;
using QCinema.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QCinema.Data.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;
        public MovieService(ApplicationDbContext context)
        {
            _context= context;
        }
        public async Task AddAsync(Movie movie)
        {
            var data = await _context.Movies.AddAsync(movie);
            
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(id);
            _context.SaveChanges();
        }

        public IEnumerable<Movie> FeaturedMovies() => _context.Movies.Include(x => x.Genre).Include(x => x.Category);
        

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            var data =await  _context.Movies.Include(x => x.Genre).Include(x => x.Producer).Include(x => x.Category).ToListAsync();
            return data;
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            var data = await _context.Movies.Include(c => c.Genre).Include(c => c.Category).Include(c => c.Actor).Include(c => c.Producer).FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public  IEnumerable<Movie> Movies()
        {  

            
            
            var data =  _context.Movies.Include(x => x.Genre).Include(x => x.Category).Include(x => x.Actor);
            
            return data;
        } 
        

        public async Task<Movie> UpdateAsync(Movie newMovie)
        {
            var data = _context.Movies.Update(newMovie);
           await _context.SaveChangesAsync();
            return newMovie;
                
        }
    }
}
