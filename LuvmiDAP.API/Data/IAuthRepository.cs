using LuvmiDAP.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuvmiDAP.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, String password);
        Task<User> Login(String username, String password);
        Task<bool> UserExist(String username);
    }
}
