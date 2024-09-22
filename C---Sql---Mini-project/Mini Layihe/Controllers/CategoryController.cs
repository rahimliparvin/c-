using Domain.Entities;
using Mini_Layihe.Controllers;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Layihe.Controllers
{
  
    public class CategoryController
    {
        private readonly ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task CreateCategory()
        {
            Console.WriteLine("Enter Category Name:");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Category name cannot be empty.");
            }

            await _categoryService.CreateAsync(new Category { Name = name });

            Console.WriteLine("Category created successfully.");
        }
        public async Task GetCategoriesAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            foreach (var category in categories)
            {
                Console.WriteLine($"Id: {category.Id}, Name: {category.Name}, Created Date: {category.CreatedDate}");
            }
        }

        public async Task GetAllWithProducts()
        {

            IEnumerable<Category> categories = await _categoryService.GetAllWithProducts();

            if (categories != null && categories.Count() > 0)
            {

                foreach (var category in categories)
                {
                    string categoryProducts = "";

                    if (category.Products.Count() > 0)
                    {
                        foreach (var categoryProduct in category.Products)
                        {
                            categoryProducts += " / " + categoryProduct.Id + " " + categoryProduct.Name;
                        }
                    }
                    Console.WriteLine($"Id : {category.Id} / Name : {category.Name}  / Create Date : {category.CreatedDate} / Products / Id / Name  {categoryProducts}");
                }
            }
            else
            {
                Console.WriteLine("Category not found !");
            }

        }
        public async Task UpdateCategoryAsync(int id)
        {

            try
            {
                var category = await _categoryService.GetByIdAsync(id);

                if (category != null)
                {

                    Console.WriteLine("Enter New Category Name:");
                NewName: string newName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(newName))
                    {
                        Console.WriteLine("Ad Bos ola bilmez");
                        goto NewName;
                    }

                    category.Name = newName;
                    await _categoryService.UpdateAsync(id, category);
                    Console.WriteLine("Category updated successfully.");
                }
                else
                {
                    Console.WriteLine("Category not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating category: {ex.Message}");
            }


        }

        public async Task DeleteCategoryAsync(int deleteCategoryId)
        {
            // Check if the category exists
            Console.WriteLine("Add category id:");
        Id: string idStr = Console.ReadLine();
            bool isCorrectIdFormat = int.TryParse(idStr, out int id);
            if (isCorrectIdFormat)
            {
                var category = await _categoryService.GetByIdAsync(id);

                if (category != null)
                {
                    // Category exists, proceed to delete
                    await _categoryService.DeleteAsync(id);
                    Console.WriteLine("Category deleted successfully.");
                }
                else
                {
                    // Category not found
                    Console.WriteLine("Category not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input:Please try again:");
                goto Id;
            }

        }

        public async Task SearchAsync()
        {
            Console.WriteLine("Please add search text !");

        SearchText: string searchText = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                Console.WriteLine("Please add the Category name in the correct format");
                goto SearchText;
            }
            else
            {
                IEnumerable<Category> categories = await _categoryService.SearchAsync(searchText);

                if (categories != null && categories.Count() > 0)
                {

                    foreach (var category in categories)
                    {
                        string categoryProducts = "";

                        if (category.Products.Count() > 0)
                        {
                            foreach (var categoryProduct in category.Products)
                            {
                                categoryProducts += categoryProduct.Id + " / " + categoryProduct.Name;
                            }
                        }
                        Console.WriteLine($"Id : {category.Id} / Name : {category.Name} / Create Date : {category.CreatedDate} / Products / Id / Name / {categoryProducts}");
                    }
                }
                else
                {
                    Console.WriteLine("Category not found !");
                }
            }
        }

        public async Task SortWithCreatedDateAsync()
        {
            var categories = await _categoryService.SortWithCreatedDate();

            if (categories != null && categories.Count() > 0)
            {
                foreach (var category in categories)
                {
                    Console.WriteLine($"Id : {category.Id} / Name : {category.Name} / Create Date : {category.CreatedDate}");
                }
            }
            else
            {
                Console.WriteLine("Category not found !");
            }
        }

        public async Task GetByIdAsync()
        {
            Console.WriteLine("Please add id");
			CategoryId: string categoryId = Console.ReadLine();

            bool isSuccess = int.TryParse(categoryId, out var id);

            if (isSuccess)
            {
                var category = await _categoryService.GetByIdAsync(id);

                if(category != null )
                {
					Console.WriteLine($"Id : {category.Id} / Name : {category.Name} / Create Date : {category.CreatedDate}");
				}
                else
                {
                    Console.WriteLine("Category not found !");
                }
            }
            else
            {
                Console.WriteLine("Please add category id correct format");
                goto CategoryId;
            }

        }
    }
}

