using System.Collections.Generic;
using System.Threading.Tasks;
using MapperClasses;

namespace BusinessLayer
{
    public interface IRatingService
    {
        Task CreateRatingAsync(RatingMapBasic rating);
        Task DeleteRatingAsync(int ratingid);
        List<RatingMapWithMovie> ReadRatingsForOneUser(int userid);
        int ReadRatingForOneMovieAndUser(string movieid, int userid);
        List<RatingMapWithUser> ReadRatingsForOneMovie(string movieid);
        Task UpdateRatingAsync(RatingMapUpdate newrating);
    }
}
