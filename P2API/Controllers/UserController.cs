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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
        public async Task<ActionResult> CreateNewUser(User u)
        {
            //check that the model binding worked.
            if (!ModelState.IsValid)
            {
                RedirectToAction("Create");
            }

            // injecting the interface allows you to Mock the implementation in the testing suite.
            bool myBool = await _us.RegisterUserAsync(u);

            if (myBool)
            {
                User uTest = new User()
                {
                    Username = "username",
                    Passwd = "passwd",
                    FirstName = "firstName",
                    LastName = "lastName",
                    RoleId = 0
                };
                return Created("website.com/my/resource", u);
            }
            else
            {
                return NotFound($"This action was not successful. It was {myBool}.");
            }
        }
        // POST api/<UserController>


        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return value;
        }


        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
