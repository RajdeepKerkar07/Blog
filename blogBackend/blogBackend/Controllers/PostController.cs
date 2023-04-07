using blogBackend.Models;
using blogBackend.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace blogBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        #region DI
        private readonly IPost post;
        public PostController(IPost post) { this.post = post; }
        #endregion

        #region Get All Posts
        [HttpGet]
        [Route("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts()
        {
            try
            {
                var result = await post.GetAllPosts();
                return Ok(result);
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Create Post
        [HttpPost]
        [Route("CreatePost")]
        public async Task<IActionResult> CreatePost(Post model)
        {
            try
            {
                var response = await post.CreatePost(model);
                if (response == "Post Created")
                {
                    return Ok(response);
                }
                else return BadRequest(response);
            }
            catch (Exception) { throw; }
        }
        #endregion
    }
}
