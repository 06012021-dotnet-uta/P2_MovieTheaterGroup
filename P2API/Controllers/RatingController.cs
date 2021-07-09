using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;
using BusinessLayer;

namespace P2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {

        private readonly RatingService _rating;

        public RatingController(IRatingService rating)
        {
            _rating = (RatingService) rating;
        }

        // GET: api/<RatingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RatingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RatingController>
        [HttpPost]
        public void Post([FromBody] Rating value)
        {
            if (ModelState.IsValid)
            {
                _rating.CreateRatingAsync(value);
            }
        }

        // PUT api/<RatingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RatingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
