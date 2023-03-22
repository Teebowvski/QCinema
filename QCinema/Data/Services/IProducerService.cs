using QCinema.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QCinema.Data.Services
{
    public interface IProducerService
    {
        Task<IEnumerable<Producer>> GetAllAsync();
        Task AddAsync(Producer producer);
        Task DeleteAsync (int id);
        Task<Producer> GetByIdAsync(int id);
        Task<Producer> UpdateAsync(Producer newProducer);
        IEnumerable<Producer> Producers();
    }
}
