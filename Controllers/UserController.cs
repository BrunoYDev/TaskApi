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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> ReturnAllUsers()
        {
            List<UserModel> usersList = await _userRepository.ReturnAllUsers();
            return Ok(usersList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> RetrieveUser(int id)
        {
            UserModel user = await _userRepository.RetrieveUser(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Register([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepository.AddUser(userModel);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel,int id)
        {
            userModel.Id = id;

            UserModel user = await _userRepository.UpdateUser(userModel,id);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete(int id)
        {
            bool apagado = await _userRepository.Delete(id);
            return Ok(apagado);
        }
    }
}