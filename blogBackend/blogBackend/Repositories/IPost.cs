using blogBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogBackend.Repositories
{
    public interface IPost
    {
        Task<IEnumerable<Post>> GetAllPosts();
        Task<string> CreatePost(Post model);
        Task<IEnumerable<Post>> GetPostsByAuthor(string author);
    }
}
