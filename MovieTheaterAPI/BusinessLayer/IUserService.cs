using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(User user); // register new user
        Task<bool> LoginAsync(User user); // login 1st method
        Task<bool> UserLoginAsync(User a);  // login 2nd method
        Task<List<User>> UserListAsync(); // UserLiest
    }
}
