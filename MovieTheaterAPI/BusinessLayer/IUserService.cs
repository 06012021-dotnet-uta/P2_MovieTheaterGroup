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
        Task<bool> DeleteUserAsync(int user_id); // delete user       
        Task<List<User>> UserListAsync(); // UserLiest
    }
}
