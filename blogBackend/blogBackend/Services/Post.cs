using blogBackend.Data;
using blogBackend.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        #region Get Posts By Author
        public async Task<IEnumerable<Models.Post>> GetPostsByAuthor(string author)
        {
            var Posts = from x in context.Posts select x;
            Posts = Posts.Where(x => x.author.Equals(author));
            if (Posts.Count() == 0) { return null; }
            else return await Posts.AsNoTracking().ToListAsync();
        }
        #endregion
    }
}
