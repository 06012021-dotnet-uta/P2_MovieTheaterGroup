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
    public class TheaterMovieController : ControllerBase
    {
        private readonly ILogger<TheaterMovieController> _logger;

        private readonly ITheaterMovieService _tms;

        // create a constructor for businesslayer
        public TheaterMovieController(ITheaterMovieService tms, ILogger<TheaterMovieController> logger)
        {
            this._tms = tms;
            this._logger = logger;

        }

        // GET: api/<TheaterController>
        [HttpGet]
        public async Task<IEnumerable<TheaterMovie>> Get()
        {
            List<TheaterMovie> theaterMovieList = await _tms.TheaterMovieListAsync();
            return theaterMovieList;
            //return new string[] { "value1", "value2" };
        }
        //  public IEnumerable<string> Get()
        // {
        //    return new string[] { "value1", "value2" };
        // }

        // TheaterMovieList 
        [HttpGet("TheaterMovieList")]
        public async Task<IEnumerable<TheaterMovie>> TheaterMovieList()
        {
            List<TheaterMovie> theaterMovieList = await _tms.TheaterMovieListAsync();
            return theaterMovieList;
        }

        // Add new TheaterMovie
        [HttpPost("AddTheaterMovie")]
        public async Task<ActionResult<User>> AddTheaterMovie(TheaterMovie tm)
        {
            await _tms.AddTheaterMovieAsync(tm);
            return CreatedAtAction(nameof(Get), new { theaterMovieId = tm.TheaterMovieId }, tm);
        }

        // GET api/<TheaterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TheaterController>
        [HttpPost]
        public void Post([FromBody] TheaterMovie value)
        {
            _tms.AddTheaterMovieAsync(value);
            //return value;
        }
        // public void Post([FromBody] string value)
        // {
        // }

        // PUT api/<TheaterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TheaterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
