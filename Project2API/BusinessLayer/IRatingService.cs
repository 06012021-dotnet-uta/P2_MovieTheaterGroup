using System.Collections.Generic;
using ModelsLayer;

namespace BusinessLayer
{
    public interface IRatingService
    {
        void CreateRatingAsync(Rating rating);
        void DeleteRatingAsync(int ratingid);
        List<int> ReadCommentsForOneUser(int userid);
        int ReadRatingForOneMovieAndUser(string movieid, int userid);
        List<int> ReadRatingsForOneMovie(string movieid);
        void UpdateRatingAsync(int ratingid, int rating);
    }
}