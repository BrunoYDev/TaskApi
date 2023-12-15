using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.Models;

namespace TaskApi.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> ReturnAllTasks();
        Task<TaskModel> RetrieveTask(int id);
        Task<TaskModel> AddTask(TaskModel task);
        Task<TaskModel> UpdateTask(TaskModel task, int id);
        Task<bool> Delete(int id);
    }
}