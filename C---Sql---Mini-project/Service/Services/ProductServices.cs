using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task CreateAsync(Product product)
        {
            await _productRepo.CreateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepo.DeleteAsync(id);
        }


        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepo.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepo.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
            await _productRepo.UpdateAsync(product);
        }

        public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
        {
            return await _productRepo.SearchByNameAsync(name);
        }

        public async Task<IEnumerable<Product>> FilterByCategoryNameAsync(string categoryName)
        {
            return await _productRepo.FilterByCategoryNameAsync(categoryName);
        }

        public async Task<IEnumerable<Product>> GetAllWithCategoryIdAsync(int categoryId)
        {
            return await _productRepo.GetAllWithCategoryIdAsync(categoryId);
        }

        public async Task<IEnumerable<Product>> SortWithPriceAsync(bool ascending)
        {
            return await _productRepo.SortWithPriceAsync(ascending);
        }

        public async Task<IEnumerable<Product>> SortByCreatedDateAsync(bool ascending)
        {
            return await _productRepo.SortByCreatedDateAsync(ascending);
        }

        public async Task<IEnumerable<Product>> SearchByColorAsync(string color)
        {
            return await _productRepo.SearchByColorAsync(color);
        }

        public Task EditAsync(Product product)
        {
            throw new NotImplementedException();
        }

        Task<List<Product>> IProductService.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}

