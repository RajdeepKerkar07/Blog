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
        #region DI
        private readonly BlogDbContext context;
        public User(BlogDbContext context) { this.context = context; }
        #endregion

        #region Login
        public async Task<string> Login(Models.LoginUser model)
        {
            if (model == null) throw new ArgumentException("Null Login Model");
            byte[] bytes = Encoding.Unicode.GetBytes(model.password);
            byte[] encrypted = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            model.password = Convert.ToBase64String(encrypted);
            var user = await context.Users.FirstOrDefaultAsync(x => x.username == model.username && x.password == model.password);
            if (user == null)
            {
                return "User Not Found";
            }
            else
                return "Authenticated";
        }
        #endregion

        #region Register
        public async Task<string> Register(Models.User model)
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
                return "Account Created";
            }
            else
            {
                return "Account Already Exists";
            }
        }
        #endregion
    }
}
