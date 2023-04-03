using blogBackend.Models;
using blogBackend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser user;

        public UserController(IUser user) { this.user = user; }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(User model)
        {
            try
            {
                var response = await user.Register(model);
                if (response == null)
                {
                    return BadRequest("Account already exists");
                }
                else
                {
                    return Ok(response);
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
