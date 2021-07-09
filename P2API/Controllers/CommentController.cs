using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Newtonsoft.Json;
using ModelsLayer;

namespace P2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly CommentService _comment;

        public CommentController(ICommentService comment)
        {
            _comment = (CommentService)comment;
        }

        // GET: api/<CommentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CommentController>
        [HttpPost]
        public void CreateComment([FromBody] Comment value)
        {
            if (ModelState.IsValid)
            {
                _comment.CreateCommentAsync(value);
            }

        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
