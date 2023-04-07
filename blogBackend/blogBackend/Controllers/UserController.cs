using blogBackend.Models;
using blogBackend.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace blogBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region DI
        private readonly IUser user;

        public UserController(IUser user) { this.user = user; }
        #endregion

        #region Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(User model)
        {
            try
            {
                var response = await user.Register(model);
                if (response == "Account Already Exists")
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
        #endregion

        #region Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUser model)
        {
            try {
                var response = await user.Login(model);
                if (response == "Authenticated") return Ok(response);
                else return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
