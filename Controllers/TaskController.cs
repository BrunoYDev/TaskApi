using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;
using TaskApi.Repositories.Interfaces;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> ReturnAllTasks()
        {
            List<TaskModel> tasksList = await _taskRepository.ReturnAllTasks();
            return Ok(tasksList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> RetrieveTask(int id)
        {
            TaskModel task = await _taskRepository.RetrieveTask(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> Register([FromBody] TaskModel TaskModel)
        {
            TaskModel task = await _taskRepository.AddTask(TaskModel);

            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> Update([FromBody] TaskModel TaskModel,int id)
        {
            TaskModel.Id = id;

            TaskModel task = await _taskRepository.UpdateTask(TaskModel,id);

            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> Delete(int id)
        {
            bool apagado = await _taskRepository.Delete(id);
            return Ok(apagado);
        }
    }
}