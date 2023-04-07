using blogBackend.Data;
using blogBackend.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace blogBackend.Services
{
    public class Post : IPost
    {
        #region DI
        private readonly BlogDbContext context;
        public Post(BlogDbContext context)
        {
            this.context = context;
        }
        #endregion

        #region Get All Posts
        public async Task<IEnumerable<Models.Post>> GetAllPosts()
        {
            var posts = await context.Posts.ToListAsync();
            return posts;
        }
        #endregion

        #region Create Post
        public async Task<string> CreatePost(Models.Post model)
        {
            if (model == null) throw new ArgumentNullException("Null Post Model");
            model.id = new Guid();
            model.dateposted = DateTime.Now;
            await context.Posts.AddAsync(model);
            await context.SaveChangesAsync();
            return "Post Created";
        }
        #endregion
    }
}
