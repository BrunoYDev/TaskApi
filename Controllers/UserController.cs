using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UserModel>> ReturnAllUsers()
        {
            return Ok("Ok");
        }
    }
}