using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private readonly IUserService _us;

        // create a constructor for businesslayer
        public UserController(IUserService us, ILogger<UserController> logger)
        {
            this._us = us;
            this._logger = logger;

        }
       
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            List<User> userList = await  _us.UserListAsync();
            return userList;
            //return new string[] { "value1", "value2" };
        }
        // UserList 
        [HttpGet("UserList")]
        public async Task<IEnumerable<User>> UserList()
        {
            List<User> userList = await _us.UserListAsync();
            return userList;
        }

        // Create New User
        [HttpPost("CreateNewUser")]
        public async Task<ActionResult<User>> CreateNewUser( User u)
        {
            await _us.RegisterUserAsync(u);
            return CreatedAtAction(nameof(Get), new { userId = u.UserId }, u);
        }
    
        // POST api/<UserController>
        

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        // public string Get(int id)
        public async Task<User> Get(int id)
        {
            List<User> userList = await _us.UserListAsync();
            //return userList;
            var returnedUser = userList.Where(x => x.UserId == id).FirstOrDefault();

            return returnedUser;
            //return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            _us.RegisterUserAsync(value);
            //return value;
        }


        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void delete(int id)
         //public async Task<ActionResult<User>> Delete(int id)
        {
            _us.DeleteUserAsync(id);
           // var xx =  _us.UserListAsync();
         
            //return userList;
            //List<User> userList1 = new List<User>();
            //foreach (var x in userList)
            //{ if (x.UserId != id) userList1.Add(x); }

            // return RedirectToAction("Get");
        }
    }
}
