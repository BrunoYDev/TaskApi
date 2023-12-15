using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.Models;
using TaskApi.Repositories.Interfaces;

namespace TaskApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDBContext _dbContext;
        public UserRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }
        public async Task<UserModel> RetrieveUser(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        }
        public async Task<List<UserModel>> ReturnAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;

        }
        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel UserId = await RetrieveUser(id);
            if (UserId == null)
            {
                throw new Exception($"O usuario com o ID: {id} não foi encontrado.");
            }
            UserId.Name = user.Name;
            UserId.Email = user.Email;

            _dbContext.Users.Update(UserId);
            await _dbContext.SaveChangesAsync();

            return UserId;
        }
        public async Task<bool> Delete(int id)
        {
            UserModel UserId = await RetrieveUser(id);
            if (UserId == null)
            {
                throw new Exception($"O usuario com o ID: {id} não foi encontrado.");
            }
            _dbContext.Users.Remove(UserId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}