using Domain.Entities;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Layihe.Controllers
{
	internal class ProductController
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;

		public ProductController(IProductService productService,
								 ICategoryService categoryService)
		{
			_productService = productService;
			_categoryService = categoryService;
		}


		public async Task CreateProduct()
		{
			Console.WriteLine("Please enter Product Name:");
		ProductName: string name = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(name))
			{
				Console.WriteLine("Product name is not empty !");
				goto ProductName;
			}

			Console.WriteLine("Please enter product count:");
		ProductCount: string ProductCount = Console.ReadLine();
			bool isProductCountCorrect = int.TryParse(ProductCount, out var count);
			if (!isProductCountCorrect)
			{
				Console.WriteLine("Please add Product count correct format");
				goto ProductCount;
			}

			Console.WriteLine("Enter Product Price:");
		ProductPrice: string ProductPrice = Console.ReadLine();
			bool isProductPriceCorrect = decimal.TryParse(ProductPrice, out var price);
			if (!isProductPriceCorrect)
			{
				Console.WriteLine("Please add Product price correct format");
				goto ProductPrice;
			}

			Console.WriteLine("Please add Product Description");
		ProductDesc: string ProductDesc = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(ProductDesc))
			{
				Console.WriteLine("Product Description is not empty!");
				goto ProductDesc;
			}

			Console.WriteLine("Please add Product Color");
		ProductColor: string ProductColor = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(ProductColor))
			{
				Console.WriteLine("Product Color is not empty!");
				goto ProductColor;
			}

			var categories = await _categoryService.GetAllAsync();

		CategoryId: if (categories != null && categories.Count() > 0)
			{
				Console.WriteLine("Choose Category Id :");
				foreach (var category in categories)
				{
					Console.WriteLine(category.Id + " / " + category.Name);
				}
			}
			else
			{
				Console.WriteLine("Category not found !");
				return;
			}

			string CategoryId = Console.ReadLine();

			bool categoryIdSuccessFormat = int.TryParse(CategoryId, out var categoryId);

			if (categoryIdSuccessFormat)
			{
				if (!string.IsNullOrWhiteSpace(CategoryId))
				{
					var category = await _categoryService.GetByIdAsync(categoryId);

					if (category == null)
					{
						Console.WriteLine("Category Not Found");
						goto CategoryId;
					}
				}
			}
			else
			{
				Console.WriteLine("Please add category id correct format");
				goto CategoryId;
			}

			await _productService.CreateAsync(new Product { Name = name, Count = count, Price = price, Description = ProductDesc, Color = ProductColor, CategoryId = categoryId, CreatedDate = DateTime.Now });

			Console.WriteLine("Product created successfully.");
		}
		public async Task GetAllProductsAsync()
		{
			try
			{
				var products = await _productService.GetAllAsync();

				if (products != null && products.Count() > 0)
				{
					foreach (var product in products)
					{
						Console.WriteLine($"Id : {product.Id} / Name : {product.Name} / Price : {product.Price} / Count : {product.Count} / Desc : {product.Description} / Color : {product.Color} / CategoryId : {product.CategoryId}");
					}
				}
				else
				{
					Console.WriteLine("Product not found !");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error retrieving products: {ex.Message}");
			}
		}
		public async Task UpdateProduct(int id)
		{
			Console.WriteLine("Enter New Product Name:");
			string newName = Console.ReadLine();

			Console.WriteLine("Enter New Product Price:");
			decimal newPrice;
			while (!decimal.TryParse(Console.ReadLine(), out newPrice))
			{
				Console.WriteLine("Please enter a valid price.");
			}

			try
			{
				var product = await _productService.GetByIdAsync(id);
				if (product != null)
				{
					product.Name = newName;
					product.Price = newPrice;
					await _productService.UpdateAsync(product);
					Console.WriteLine("Product updated successfully.");
				}
				else
				{
					Console.WriteLine("Product not found.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating product: {ex.Message}");
			}
		}
		public async Task DeleteProduct(int id)
		{
			try
			{
				await _productService.DeleteAsync(id);
				Console.WriteLine("Product deleted successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting product: {ex.Message}");
			}
		}
		public async Task SearchByNameAsync()
		{
			Console.WriteLine("Please search text");
		SearchText: string searcText = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(searcText))
			{
				Console.WriteLine("Search text is not empty !");
				goto SearchText;
			}
			else
			{
				var products = await _productService.SearchByNameAsync(searcText);

				if (products != null && products.Count() > 0)
				{
					foreach (var product in products)
					{
						Console.WriteLine($"Id : {product.Id} / Name : {product.Name} / Price : {product.Price} / Count : {product.Count} / Desc : {product.Description} / Color : {product.Color} / CategoryId : {product.CategoryId}");
					}
				}
				else
				{
					Console.WriteLine("Product not found !");
				}
			};
		}
		public async Task FilterByCategoryNameAsync()
		{
			Console.WriteLine("Please add Category Name");
		CategoryName: string categoryName = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(categoryName))
			{
				Console.WriteLine("Category is not empty !");
				goto CategoryName;
			}
			else
			{
				var products = await _productService.FilterByCategoryNameAsync(categoryName);

				if(products != null && products.Count() > 0)
				{
					foreach (var product in products)
					{
						Console.WriteLine($"Id : {product.Id} / Name : {product.Name} / Price : {product.Price} / Count : {product.Count} / Desc : {product.Description} / Color : {product.Color} / CategoryId : {product.CategoryId} / CategoryName : {product.Category.Name}");
					}
				}else
				{
					Console.WriteLine("Product not found !");
				}

			}
			

		}
		//public async Task SortWithPriceAsync()
		//{

		//	var products = await _productService.SortWithPriceAsync();
		//}

	}
}