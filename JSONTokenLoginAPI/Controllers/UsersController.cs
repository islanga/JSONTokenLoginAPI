using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSONTokenLoginAPI.Service;
using JSONTokenLoginAPI.Helper;

namespace JSONTokenLoginAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("GetUserById")]
        public IActionResult GetUserById(int id)
        {
            var users = _userService.GetById(id);
            return Ok(users);
        }
    }
}
