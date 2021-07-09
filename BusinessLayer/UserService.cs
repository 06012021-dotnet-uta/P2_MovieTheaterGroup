using Microsoft.EntityFrameworkCore;
using ModelsLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserService : IUserService
    {
        // first define the context 
        private readonly P2Context _context;
        private List<User> ps ;
        static User _user;

        // create a constructor
        /// <summary>
        /// create constructor to make the dependency injection
        /// </summary>
        /// <param name="context"></param>
        public UserService(P2Context context) { 
            this._context = context;
            _user = new User();
        }
        // currentUser
        User currentUser = null;
        
        /// <summary>
        ///  register new user before login
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> RegisterUserAsync(User user)
        {
            // create a try/catch  to save user
            await _context.Users.AddAsync(user);
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine($"There was a problem updating the Db => {ex.InnerException}");
                return false;
            }
            catch (DbUpdateException ex)
            {       //change this to logging
                Console.WriteLine($"There was a problem updating the Db => {ex.InnerException}");
                return false;
            }
            return true;
        }
        
        // login 1st method
        public async Task<bool> LoginAsync(User user)
        {

            try { var currentUser = _context.Users.Where(x => x.Username == user.Username 
                                                      && x.Passwd == user.Passwd).FirstOrDefault(); }
            catch (Exception ex)
            {
                Console.WriteLine($"User not found => {ex.InnerException}");
                return false;
            }
            currentUser = user;
            return true;
        }

        // login 2nd method
        public async Task<bool> UserLoginAsync(User a)
        {

            bool al = true;
            try
            {
                al = _context.Users.Where(x => x.Username == a.Username 
                            && x.Passwd == a.Passwd).ToList().Count > 0;

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"There was a problem gettign the players list => {ex.InnerException}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was a problem gettign the players list => {ex}");
                return false;
            }

            _user = _context.Users.ToList().Where(x => x.Username == a.Passwd).FirstOrDefault();
            //Console.WriteLine($"user => {User}");

            return al;
        }

        // userList 
        /// <summary>
        ///  get the list of all order of  all Users
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> UserListAsync()
        {
            // List<User> ps = null;
            // List<User> ps = new List<User>();
            try
            {
                ps = await _context.Users.ToListAsync();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"There was a problem gettign the players list => {ex.InnerException}"); //or {ex.Message}
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was a problem gettign the players list => {ex}");
            }
            return ps;
        }
    }
}
