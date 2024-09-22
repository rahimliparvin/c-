using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(User user);
        Task DeleteAsync(int id);
        Task<List<User>> GetAllAsync();
        Task GetByIdAsync(int id);
        Task UpdateAsync(object user);
    }
}
