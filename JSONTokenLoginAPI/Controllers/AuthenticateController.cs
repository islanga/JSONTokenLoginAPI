using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSONTokenLoginAPI.Models;
using JSONTokenLoginAPI.Service;
using JSONTokenLoginAPI.Helper;

namespace JSONTokenLoginAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private IAuthenticationService _authService;
        public AuthenticateController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("authenticate")]
        public IActionResult AuthenticateUser(AuthenticateRequest model)
        {
            var response = _authService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
      
    }
}
