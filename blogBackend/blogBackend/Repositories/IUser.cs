using blogBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogBackend.Repositories
{
    public interface IUser
    {
        Task<string> Register(User model);
        Task<string> Login(LoginUser model);
    }
}
