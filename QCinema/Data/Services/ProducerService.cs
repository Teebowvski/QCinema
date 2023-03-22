using Microsoft.EntityFrameworkCore;
using QCinema.Data;
using QCinema.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QCinema.Data.Services
{
    public class ProducerService : IProducerService
    {

        private readonly ApplicationDbContext _context;
        public ProducerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producer>> GetAllAsync()
        {
            var data = await _context.Producers.Include(c=>c.Movies).ToListAsync();
            return data;
        }

        public async Task<Producer> GetByIdAsync(int id)
        {
            var data = await _context.Producers.FirstOrDefaultAsync(c=>c.Id == id);
            return data;
        }

        public async Task<Producer> UpdateAsync(Producer newProducer)
        {
            var data = _context.Producers.Update(newProducer);
            await _context.SaveChangesAsync();
            return newProducer;
            
        }

      public   async Task  AddAsync(Producer producer)
        {
            var data = _context.Producers.Add(producer);
          await  _context.SaveChangesAsync();
            
        }

      public async Task DeleteAsync(int id)
        {
            var data = await _context.Producers.FirstOrDefaultAsync(x=>x.Id==id);
                _context.Remove(id);
         await   _context.SaveChangesAsync(); 
           

        }

        public IEnumerable<Producer> Producers()=> _context.Producers;
        
    }
}
