using Microsoft.EntityFrameworkCore;
using QCinema.Data;
using QCinema.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QCinema.Data.Services
{
    public class CinemaService:ICinemaService
    {
        private readonly ApplicationDbContext _context;
        public CinemaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            var data = await _context.Cinemas.Include(c => c.Movies).ToListAsync();
            return data;
        }

        public async Task<Cinema> GetByIdAsync(int id)
        {
            var data = await _context.Cinemas.FirstOrDefaultAsync(c => c.Id == id);
            return data;
        }

        public async Task<Cinema> UpdateAsync(Cinema newCinema)
        {
            var data = _context.Cinemas.Update(newCinema);
            await _context.SaveChangesAsync();
            return newCinema;

        }

        public async Task AddAsync(Cinema Cinema)
        {
            var data = _context.Cinemas.Add(Cinema);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Cinemas.FirstOrDefaultAsync(x => x.Id == id);
            _context.Cinemas.Remove(data);
            await _context.SaveChangesAsync();


        }

        public IEnumerable<Cinema> Cinemas()=> _context.Cinemas;
        
    }

}
