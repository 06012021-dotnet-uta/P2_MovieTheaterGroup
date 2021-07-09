using System;
using RepositoryLayer;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessLayer
{
    /// <summary>
    /// Contains methods for interacting with the Ratings table in the database.
    /// </summary>
    public class RatingService : IRatingService
    {
        // private readonly P2Context _context;

        // /// <summary>
        // /// Initializes an instance of the database models.
        // /// </summary>
        // /// <param name="context"></param>
        // public RatingService(P2Context context)
        // {
        //     _context = context;
        // }
        // DateTime current = DateTime.Now;

        // /// <summary>
        // /// Creates a rating in the database.
        // /// </summary>
        // /// <param name="userid"></param>
        // /// <param name="movieid"></param>
        // /// <param name="rating"></param>
        // public async void CreateRatingAsync(int userid, string movieid, int rating)
        // {
        //     var dbrating = _context.Ratings.Where(x => (x.UserId == userid) && (x.MovieId == movieid)).FirstOrDefault();
        //     dbrating.Content = rating;
        //     dbrating.UserId = userid;
        //     dbrating.MovieId = movieid;
        //     dbrating.DateMade = current;
        //     _context.Add(dbrating);
        //     await _context.SaveChangesAsync();
        // }

        // /// <summary>
        // /// Deletes a rating from the database.
        // /// </summary>
        // /// <param name="ratingid"></param>
        // public async void DeleteRatingAsync(int ratingid)
        // {
        //     var rating = _context.Ratings.Where(x => x.RatingId == ratingid).FirstOrDefault();
        //     _context.Ratings.Remove(rating);
        //     await _context.SaveChangesAsync();
        // }

        // /// <summary>
        // /// Updates a rating from the database.
        // /// </summary>
        // /// <param name="ratingid"></param>
        // /// <param name="rating"></param>
        // public async void UpdateRatingAsync(int ratingid, int rating)
        // {
        //     var dbrating = _context.Ratings.Where(x => x.RatingId == ratingid).FirstOrDefault();
        //     dbrating.Content = rating;
        //     dbrating.DateMade = current;
        //     _context.Update(dbrating);
        //     await _context.SaveChangesAsync();
        // }

        // /// <summary>
        // /// Gets a rating for a certain user and movie from the database.
        // /// </summary>
        // /// <param name="movieid"></param>
        // /// <param name="userid"></param>
        // /// <returns>Returns an int.</returns>
        // public int ReadRatingForOneMovieAndUser(string movieid, int userid)
        // {
        //     var rating = _context.Ratings.Where(x => (x.MovieId == movieid) && (x.UserId == userid)).Select(x => x.Content).FirstOrDefault();
        //     return rating;
        // }

        // /// <summary>
        // /// Gets all ratings for one movie from the database.
        // /// </summary>
        // /// <param name="movieid"></param>
        // /// <returns>Returns a list of ints.</returns>
        // public List<int> ReadRatingsForOneMovie(string movieid)
        // {
        //     var ratings = _context.Ratings.Where(x => x.MovieId == movieid).Select(x => x.Content).ToList();
        //     return ratings;
        // }

        // /// <summary>
        // /// Gets all ratings for one user from the database.
        // /// </summary>
        // /// <param name="userid"></param>
        // /// <returns>Returns a list of ints.</returns>
        // public List<int> ReadCommentsForOneUser(int userid)
        // {
        //     var ratings = _context.Ratings.Where(x => x.UserId == userid).Select(x => x.Content).ToList();
        //     return ratings;
        // }
    }
}