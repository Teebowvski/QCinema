using Microsoft.EntityFrameworkCore;
using QCinema.Data;
using QCinema.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QCinema.Data.Services
{
    public class GenreService:IGenreService
    {
        private readonly ApplicationDbContext _context;
        public GenreService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            var data = await _context.Genres.Include(c => c.Movies).ToListAsync();
            return data;
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            var data = await _context.Genres.FirstOrDefaultAsync(c => c.Id == id);
            return data;
        }

        public async Task<Genre> UpdateAsync(Genre newGenre)
        {
            var data = _context.Genres.Update(newGenre);
            await _context.SaveChangesAsync();
            return newGenre;

        }

        public async Task AddAsync(Genre Genre)
        {
            var data = _context.Genres.Add(Genre);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            _context.Genres.Remove(data);
            await _context.SaveChangesAsync();


        }

        public IEnumerable<Genre> Genres()=>_context.Genres; 
        
    }
}
