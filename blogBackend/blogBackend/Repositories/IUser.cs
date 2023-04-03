using blogBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogBackend.Repositories
{
    public interface IUser
    {
        Task<User> Register(User model);
    }
}
