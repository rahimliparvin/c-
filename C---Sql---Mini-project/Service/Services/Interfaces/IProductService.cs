using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IProductService 
    {
        Task CreateAsync(Product product);
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(Product product);
        Task EditAsync(Product product);
        Task<IEnumerable<Product>> SearchByNameAsync(string name);
        Task<IEnumerable<Product>> FilterByCategoryNameAsync(string categoryName);
        Task<IEnumerable<Product>> GetAllWithCategoryIdAsync(int categoryId);
        Task<IEnumerable<Product>> SortWithPriceAsync(bool ascending);
        Task<IEnumerable<Product>> SortByCreatedDateAsync(bool ascending);
        Task<IEnumerable<Product>> SearchByColorAsync(string color);

    }
}
