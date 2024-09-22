using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task DeleteAsync(int id);
        Task<IEnumerable<Product>> FilterByCategoryNameAsync(string categoryName);
        Task<IEnumerable<Product>> GetAllWithCategoryIdAsync(int categoryId);
        Task<IEnumerable<Product>> SearchByColorAsync(string color);
        Task<IEnumerable<Product>> SearchByNameAsync(string name);
        Task<IEnumerable<Product>> SortByCreatedDateAsync(bool ascending);
        Task<IEnumerable<Product>> SortWithPriceAsync(bool ascending);
    }
}
