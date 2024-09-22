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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository()
        {
            _context = new AppDbContext();
        }
        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> FilterByCategoryNameAsync(string categoryName)
        {
            return await _context.Products.Where(m => m.Category.Name.Trim().ToUpper().Contains(categoryName.Trim().ToUpper())).Include(m=>m.Category).ToListAsync();
        }

        public Task<IEnumerable<Product>> GetAllWithCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> SearchByColorAsync(string color)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
        {
            return await _context.Products.Where(m => m.Name.Trim().ToUpper().Contains(name.Trim().ToUpper())).
                                           ToListAsync();

        }

        public Task<IEnumerable<Product>> SortByCreatedDateAsync(bool ascending)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> SortWithPriceAsync(bool ascending)
        {
            throw new NotImplementedException();
        }
    }
}