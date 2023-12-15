using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.Models;

namespace TaskApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> ReturnAllUsers();
        Task<UserModel> RetrieveUser(int id);
        Task<UserModel> AddUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user, int id);
        Task<bool> Delete(int id);
    }
}