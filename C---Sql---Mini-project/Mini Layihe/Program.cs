

using System;
using System.Threading.Tasks;
using Service.Services.Interfaces;
using Service.Services; // Ensure this namespace contains your service implementations
using Domain.Entities; // Ensure this namespace contains your entity definitions
using Mini_Layihe.Controllers;
using Repository.Repositories.Interfaces;
using Repository.Repositories;
using Mini_Layihe.Helpers.Extentions;

namespace Mini_Layihe
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Create repository instances
            IProductRepository productRepository = new ProductRepository(); // Ensure this is your actual implementation
            ICategoryRepository categoryRepository = new CategoryRepository(); // Ensure this is your actual implementation

            // Create service instances
            ICategoryService categoryService = new CategoryService(categoryRepository);
            IProductService productService = new ProductService(productRepository);

            // Create controllers
            var categoryController = new CategoryController(categoryService);
            var productController = new ProductController(productService,categoryService);

            while (true)
            {
                ConsoleColor.Blue.WriteConsole("Please select one option");
                ConsoleColor.Red.WriteConsole("Category");
                ConsoleColor.Green.WriteConsole("\n  1.Create Category,\n  2. Get Categories \n  3. Get Category By ID, \n  4 Update Category, \n  5. Delete Category, \n  6. Search Categories, \n  7. Get Categories with Products, \n  8. Sort Categories by Created Date, \n  9. Get Archive Categories");
                Console.WriteLine();
                ConsoleColor.Blue.WriteConsole("Please select one option");
                ConsoleColor.Red.WriteConsole("Product");
                ConsoleColor.Green.WriteConsole(" \n  10. Create Product,\n  11. Get Products,\n  12. Update Product,\n  13. Delete Product,\n  14. Search Products by Name,\n  15. Filter Products by Category Name,\n  16. Sort Products by Price,\n  17. Sort Products by Created Date,\n  18. Search Products by Color,\n  19. Delete Product By ID,\n  20. Update Product By ID,\n  21. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await categoryController.CreateCategory();
                        break;
                    case "2":
                        await categoryController.GetCategoriesAsync();
                        break;
                    case "3":
                        await categoryController.GetByIdAsync(); // Added
                        break;
                    case "4":
                        Console.WriteLine("Enter Category ID to update:");
                        int updateCategoryId = int.Parse(Console.ReadLine());
                        await categoryController.UpdateCategoryAsync(updateCategoryId);
                        break;
                    case "5":
                        Console.WriteLine("Enter Category ID to delete:");
                        int deleteCategoryId = int.Parse(Console.ReadLine());
                        await categoryController.DeleteCategoryAsync(deleteCategoryId);
                        break;
                    case "6":
                        await categoryController.SearchAsync();
                        break;
                    case "7":
                        await categoryController.GetAllWithProducts();
                        break;
                    case "8":
                        await categoryController.SortWithCreatedDateAsync();
                        break;
                    //case "9":
                    //    await categoryController.GetArchiveCategoriesAsync(); // Added
                    //    break;
                    case "10":
                       await productController.CreateProduct();
                        break;
                    case "11":
                        await productController.GetAllProductsAsync();
                        break;
                    //case "12":
                    //    Console.WriteLine("Enter Product ID to update:");
                    //    int updateProductId = int.Parse(Console.ReadLine());
                    //    await productController.UpdateProductAsync(updateProductId); // Updated to async
                    //    break;
                    //case "13":
                    //    Console.WriteLine("Enter Product ID to delete:");
                    //    int deleteProductId = int.Parse(Console.ReadLine());
                    //    await productController.DeleteProductAsync(deleteProductId); // Updated to async
                    //    break;
                    case "14":
                        await productController.SearchByNameAsync();
                        break;
                    case "15":
                        await productController.FilterByCategoryNameAsync(); 
                        break;
                    //case "16":
                    //     await productController.SortWithPriceAsync(); // Updated to async
                    //    break;
                    //case "17":
                    //    var sortedByDate = await productController.SortByCreatedDateAsync(); // Updated to async
                    //    foreach (var product in sortedByDate)
                    //    {
                    //        Console.WriteLine($"Product: {product.Name}, Created Date: {product.CreatedDate}");
                    //    }
                    //    break;
                    //case "18":
                    //    Console.WriteLine("Enter color to search for products:");
                    //    string color = Console.ReadLine();
                    //    var colorSearchedProducts = await productController.SearchByColorAsync(color); // Updated to async
                    //    foreach (var product in colorSearchedProducts)
                    //    {
                    //        Console.WriteLine($"Found Product by Color: {product.Name}");
                    //    }
                    //    break;                                     
                    //case "19":
                    //    Console.WriteLine("Enter Product ID to delete:");
                    //    int prodIdToDelete = int.Parse(Console.ReadLine());
                    //    await productController.DeleteProductAsync(prodIdToDelete); // Added
                    //    break;
                    //case "20":
                    //    Console.WriteLine("Enter Product ID to update:");
                    //    int prodIdToUpdate = int.Parse(Console.ReadLine());
                    //    await productController.UpdateProductAsync(prodIdToUpdate); // Added
                    //    break;
                    case "21":
                        return; // Exit the application
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }
}