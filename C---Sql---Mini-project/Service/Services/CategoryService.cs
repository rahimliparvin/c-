using Domain.Entities;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepo = new CategoryRepository();
        }

        public async Task CreateAsync(Category category)
        {
            await _categoryRepo.CreateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            var existCategory = await _categoryRepo.GetByIdAsync(id);
            await _categoryRepo.DeleteAsync(existCategory);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryRepo.GetAllAsync();
        }

        public async Task<IEnumerable<Category>> GetAllWithProducts()
        {
            return await _categoryRepo.GetAllWithProducts();
        }

        public Task<IEnumerable<Category>> GetArchiveCategories()
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepo.GetByIdAsync(id);
        }

        public Task<IEnumerable<Category>> Search(string searchText)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> SearchAsync(string searchText)
        {

            return await _categoryRepo.SearchAsync(searchText);
        }

        public async Task<IEnumerable<Category>> SortWithCreatedDate()
        {
            return await _categoryRepo.SortWithCreatedDateAsync();
        }

        public Task<IEnumerable<Category>> SortWithCreatedDateAsync()
        {
            return _categoryRepo.SortWithCreatedDateAsync();
        }

        public async Task UpdateAsync(int id, Category category)
        {
            var existCategory = await _categoryRepo.GetByIdAsync(id);
            existCategory.Name = category.Name;
            await _categoryRepo.UpdateAsync(existCategory);
        }

        public Task UpdateAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
