using System;
using RepositoryLayer;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MapperClasses;
using ModelsLayer;

namespace BusinessLayer
{
    /// <summary>
    /// Contains methods for interacting with the Ratings table in the database.
    /// </summary>
    public class RatingService : IRatingService
    {
        private readonly P2Context _context;

        /// <summary>
        /// Initializes an instance of the database models.
        /// </summary>
        /// <param name="context"></param>
        public RatingService(P2Context context)
        {
            _context = context;
        }
        DateTime current = DateTime.Now;

        /// <summary>
        /// Creates a rating in the database.
        /// </summary>
        /// <param name="rating"></param>
        public async Task CreateRatingAsync(RatingMapBasic rating)
        {
            Rating _rating = new();
            _rating.Content = rating.Content;
            _rating.MovieId = rating.MovieId;
            _rating.UserId = rating.UserId;
            _rating.DateMade = rating.DateMade;
            _context.Ratings.Add(_rating);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a rating for a certain user and movie from the database.
        /// </summary>
        /// <param name="movieid"></param>
        /// <param name="userid"></param>
        /// <returns>Returns an int.</returns>
        public int ReadRatingForOneMovieAndUser(string movieid, int userid)
        {
            var rating = _context.Ratings.Where(x => (x.MovieId == movieid) && (x.UserId == userid)).Select(x => x.Content).FirstOrDefault();
            return rating;
        }

        /// <summary>
        /// Gets all ratings for one movie from the database.
        /// </summary>
        /// <param name="movieid"></param>
        /// <returns>Returns a list of a custom data transmission object.</returns>
        public List<RatingMapWithUser> ReadRatingsForOneMovie(string movieid)
        {
            var ratings = _context.Ratings.Join(_context.Users, rating => rating.UserId, user => user.UserId, (rating, user) => new
            {
                RatingId = rating.RatingId,
                UserId = rating.UserId,
                DateMade = rating.DateMade,
                Content = rating.Content,
                MovieId = rating.MovieId,
                Username = user.Username
            }).Where(x => x.MovieId == movieid).ToList();
            List<RatingMapWithUser> ratinglist = new();
            foreach (var result in ratings)
            {
                RatingMapWithUser currentrating = new()
                {
                    RatingId = result.RatingId,
                    UserId = result.UserId,
                    Username = result.Username,
                    DateMade = result.DateMade,
                    Content = result.Content,
                    MovieId = result.MovieId
                };
                ratinglist.Add(currentrating);
            }
            return ratinglist;
        }

        /// <summary>
        /// Gets all ratings for one user from the database.
        /// </summary>
        /// <param name="userid"></param>
        /// <returns>Returns a list of a custom data transmission object.</returns>
        public List<RatingMapWithMovie> ReadRatingsForOneUser(int userid)
        {
            var ratings = _context.Ratings.Join(_context.Movies, rating => rating.MovieId, movie => movie.MovieId, (rating, movie) => new
            {
                RatingId = rating.RatingId,
                UserId = rating.UserId,
                DateMade = rating.DateMade,
                Content = rating.Content,
                MovieId = rating.MovieId,
                MovieName = movie.MovieName
            }).Where(x => x.UserId == userid).ToList();
            List<RatingMapWithMovie> ratinglist = new();
            foreach (var result in ratings)
            {
                RatingMapWithMovie currentresult = new();
                currentresult.RatingId = result.RatingId;
                currentresult.UserId = result.UserId;
                currentresult.DateMade = result.DateMade;
                currentresult.Content = result.Content;
                currentresult.MovieId = result.MovieId;
                currentresult.MovieName = result.MovieName;
                ratinglist.Add(currentresult);
            }
            return ratinglist;
        }

        /// <summary>
        /// Updates a rating from the database.
        /// </summary>
        /// <param name="newrating"></param>
        public async Task UpdateRatingAsync(RatingMapUpdate newrating)
        {
            var dbrating = _context.Ratings.Where(x => x.RatingId == newrating.RatingId).FirstOrDefault();
            dbrating.Content = newrating.Content;
            dbrating.DateMade = newrating.DateMade;
            _context.Update(dbrating);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a rating from the database.
        /// </summary>
        /// <param name="ratingid"></param>
        public async Task DeleteRatingAsync(int ratingid)
        {
            var rating = _context.Ratings.Where(x => x.RatingId == ratingid).FirstOrDefault();
            _context.Ratings.Remove(rating);
            await _context.SaveChangesAsync();
        }
    }
}