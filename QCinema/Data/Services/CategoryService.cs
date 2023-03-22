using Microsoft.EntityFrameworkCore;
using QCinema.Data;
using QCinema.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QCinema.Data.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var data = await _context.Categories.Include(c => c.Movies).ToListAsync();
            return data;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var data = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return data;
        }

        public async Task<Category> UpdateAsync(Category newCategory)
        {
            var data = _context.Categories.Update(newCategory);
            await _context.SaveChangesAsync();
            return newCategory;

        }

        public async Task AddAsync(Category Category)
        {
            var data = _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            _context.Categories.Remove(data);
            await _context.SaveChangesAsync();


        }

        public IEnumerable<Category> Categories()=>_context.Categories;

        public IEnumerable<Category> CurrentCategory()=>_context.Categories;
        
    }
}
