using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
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
  public class TheaterController : ControllerBase
  {
    private readonly TheaterService _theater;

    public TheaterController(ITheaterService theater)
    {
      _theater = (TheaterService)theater;
    }

    // GET: api/<TheaterController>
    [HttpGet]
    public List<Theater> Get()
    {
      return _theater.SelectTheaters();
    }

    // GET api/<TheaterController>/5
    [HttpGet("{id}")]
    public Theater Get(int id)
    {
      return _theater.SelectTheater(id);
    }

    // POST api/<TheaterController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

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
