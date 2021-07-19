using BusinessLayer;
using IMDBRapidAPIFowardMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapperClasses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P2API.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;

        private readonly IMovieService _ms;

        private readonly IMDBForward _imdb;

        // create a constructor for businesslayer
        public MovieController(IMovieService ms, IIMDBForward imdb, ILogger<MovieController> logger)
        {
            this._ms = ms;
            this._logger = logger;
            _imdb = (IMDBForward)imdb;
        }

        // GET: api/<MovieController>
        [HttpGet("[action]/{title}")]
        public async Task<List<IMDBMapAdmin>> IMDBMovieList(string title)
        {
            return await _imdb.IMDBMovieTitleAsync(title);
        }

        // MovieList 
        [HttpGet("MovieList")]
        public async Task<IEnumerable<Movie>> MovieList()
        {
            List<Movie> movieList = await _ms.MovieListAsync();
            return movieList;
        }

        // GET api/<MovieController>/5
        [HttpGet("[action]/{id}")]
        public async Task<IMDBMapAdmin> IMDBMovie(string id)
        {
            return await _imdb.IMDBMovieIDAsync(id);
        }

        // POST api/<MovieController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
