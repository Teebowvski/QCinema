using Microsoft.EntityFrameworkCore;
using QCinema.Data;
using QCinema.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QCinema.Data.Services
{
    public class ActorService:IActorService
    {
        private readonly ApplicationDbContext _context;
        public ActorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var data = await _context.Actors.Include(c => c.Movies).ToListAsync();
            return data;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var data = await _context.Actors.FirstOrDefaultAsync(c => c.Id == id);
            return data;
        }

        public async Task<Actor> UpdateAsync(Actor newActor)
        {
            var data = _context.Actors.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;

        }

        public async Task AddAsync(Actor Actor)
        {
            var data = _context.Actors.Add(Actor);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            _context.Actors.Remove(data);
            await _context.SaveChangesAsync();


        }

        public IEnumerable<Actor> Actors() => _context.Actors;
        
    }
}
