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
  public class ScheduleController : ControllerBase
  {
    private readonly ScheduleService _schedule;

    public ScheduleController(IScheduleService schedule)
    {
      _schedule = (ScheduleService)schedule;
    }

    // GET: api/<ScheduleController>
    [HttpGet]
    public List<Schedule> Get()
    {
      return new List<Schedule>() { };    // get all schedules (?)
    }

    // GET api/<ScheduleController>/5
    [HttpGet("{movieId}/{theaterId}")]
    public Schedule Get(string movieId, int theaterId)
    {
      return _schedule.SelectMovieSchedule(movieId, theaterId);
    }

    // POST api/<ScheduleController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ScheduleController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ScheduleController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
