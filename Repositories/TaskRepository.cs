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
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSystemDBContext _dbContext;
        public TaskRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }
        public async Task<TaskModel> RetrieveTask(int id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(task => task.Id == id);
        }
        public async Task<List<TaskModel>> ReturnAllTasks()
        {
            return await _dbContext.Tasks.ToListAsync();
        }
        public async Task<TaskModel> AddTask(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;

        }
        public async Task<TaskModel> UpdateTask(TaskModel task, int id)
        {
            TaskModel TaskId = await RetrieveTask(id);
            if (TaskId == null)
            {
                throw new Exception($"A Tarefa com o ID: {id} não foi encontrada.");
            }
            TaskId.Name = task.Name;
            TaskId.Description = task.Description;
            TaskId.Status = task.Status;
            TaskId.UserId = task.UserId;

            _dbContext.Tasks.Update(TaskId);
            await _dbContext.SaveChangesAsync();

            return TaskId;
        }
        public async Task<bool> Delete(int id)
        {
            TaskModel TaskId = await RetrieveTask(id);
            if (TaskId == null)
            {
                throw new Exception($"A Tarefa com o ID: {id} não foi encontrada.");
            }
            _dbContext.Tasks.Remove(TaskId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}