using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository()
        {
            _context = new AppDbContext();
        }

        public async Task<IEnumerable<Category>> GetAllWithProducts()
        {
            return await _context.Categories.Include(c => c.Products).ToListAsync();
        }

        public async Task<IEnumerable<Category>> SearchAsync(string searchText)
        {
            return await _context.Categories
                                .Where(m => m.Name.Trim().ToUpper().Contains(searchText.Trim().ToUpper()))
                                .Include(m => m.Products)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> SortWithCreatedDateAsync()
        {
            return _context.Categories.OrderByDescending(c => c.CreatedDate);
        }
    }
}
