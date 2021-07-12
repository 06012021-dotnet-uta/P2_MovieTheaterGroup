using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using MapperClasses;

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

        // POST api/<RatingController>
        [HttpPost]
        public async Task PostARatingAsync([FromBody] RatingMapBasic value)
        {
                await _rating.CreateRatingAsync(value);
        }

        // GET: api/<RatingController>/5
        [HttpGet("[action]/{movieid}")]
        public List<RatingMapWithUser> GetAllRaingsForMovie(string movieid)
        {
            return _rating.ReadRatingsForOneMovie(movieid);
        }

        // GET api/<RatingController>/5
        [HttpGet("[action]/{userid}")]
        public List<RatingMapWithMovie> GetAllRatingsForUser(int userid)
        {
            return _rating.ReadRatingsForOneUser(userid);
        }

        // PUT api/<RatingController>
        [HttpPut]
        public async Task PutARatingAsync([FromBody] RatingMapUpdate value)
        {
            await _rating.UpdateRatingAsync(value);
        }

        // DELETE api/<RatingController>/5
        [HttpDelete("{ratingid}")]
        public async Task DeleteARatingAsync(int ratingid)
        {
            await _rating.DeleteRatingAsync(ratingid);
        }
    }
}
