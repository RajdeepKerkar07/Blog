using blogBackend.Data;
using blogBackend.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace blogBackend.Services
{
    public class User : IUser
    {
        private readonly BlogDbContext context;
        public User(BlogDbContext context) { this.context = context; }
        public async Task<Models.User> Register(Models.User model)
        {

            if (model == null) throw new ArgumentNullException("Null Post Model");
            var user = await context.Users.FirstOrDefaultAsync(x => x.username == model.username);
            if (user == null)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(model.password);
                byte[] encrypted = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
                model.password = Convert.ToBase64String(encrypted);
                await context.Users.AddAsync(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
