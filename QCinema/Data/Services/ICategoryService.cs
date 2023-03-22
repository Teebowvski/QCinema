using QCinema.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QCinema.Data.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task AddAsync(Category Category);
        Task DeleteAsync(int id);
        Task<Category> GetByIdAsync(int id);
        Task<Category> UpdateAsync(Category newCategory);
        IEnumerable<Category> CurrentCategory();
    }
}
