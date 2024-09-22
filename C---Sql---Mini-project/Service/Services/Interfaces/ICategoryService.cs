using Domain.Entities;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ICategoryService 
    {
        Task CreateAsync(Category category);
        Task UpdateAsync(int id, Category category);
        Task DeleteAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<IEnumerable<Category>> Search(string searchText);
        Task<IEnumerable<Category>> GetAllWithProducts();
        Task<IEnumerable<Category>> SortWithCreatedDate();
        Task<IEnumerable<Category>> GetArchiveCategories();
        Task UpdateAsync(Category category);
        Task<IEnumerable<Category>> SearchAsync(string searchText);
    }
}
