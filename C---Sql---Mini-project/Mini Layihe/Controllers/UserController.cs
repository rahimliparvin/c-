//using Domain.Entities;
//using Service.Services.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Mini_Layihe.Controllers
//{
//    internal class UserController
//    {         
//            private readonly IUserService _userService;

//            public UserController(IUserService userService)
//            {
//                _userService = userService;
//            }

//        public UserController()
//        {
//        }

//        public async Task CreateUser()
//            {
//                Console.WriteLine("Enter Username:");
//                string username = Console.ReadLine();

//                Console.WriteLine("Enter Email:");
//                string email = Console.ReadLine();

//                Console.WriteLine("Enter Password:");
//                string password = Console.ReadLine();

//                await _userService.CreateAsync(new User { Username = username, Email = email, Password = password, CreatedDate = DateTime.Now });

//                Console.WriteLine("User created successfully.");
//            }

//            public async Task<List<User>> GetUsers()
//            {
//                try
//                {
//                    return (List<User>)await _userService.GetAllAsync();
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Error retrieving users: {ex.Message}");
//                    return new List<User>();
//                }
//            }

//            public async Task UpdateUser(int id)
//            {
//                Console.WriteLine("Enter New Username:");
//                string newUsername = Console.ReadLine();

//                Console.WriteLine("Enter New Email:");
//                string newEmail = Console.ReadLine();

//                Console.WriteLine("Enter New Password:");
//                string newPassword = Console.ReadLine();

//                try
//                {
//                    var user = await _userService.GetByIdAsync(id);
//                    if (user != null)
//                    {
//                        user.Username = newUsername;
//                        user.Email = newEmail;
//                        user.Password = newPassword;
//                        await _userService.UpdateAsync(user);
//                        Console.WriteLine("User updated successfully.");
//                    }
//                    else
//                    {
//                        Console.WriteLine("User not found.");
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Error updating user: {ex.Message}");
//                }
//            }

//            public async Task DeleteUser(int id)
//            {
//                try
//                {
//                    await _userService.DeleteAsync(id);
//                    Console.WriteLine("User deleted successfully.");
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Error deleting user: {ex.Message}");
//                }
//            }
//        }

//    }

