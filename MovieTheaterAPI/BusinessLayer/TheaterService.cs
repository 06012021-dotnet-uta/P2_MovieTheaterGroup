using Microsoft.EntityFrameworkCore;
using ModelsLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TheaterService : ITheaterService
    {
        private readonly P2Context _context;

        /// <summary>
        /// Initializes an instance of the database models.
        /// </summary>
        /// <param name="context">A DbContext object</param>
        public TheaterService(P2Context context)
        {
            this._context = context;
        }

        /// <summary>
        /// Inserts a theater into the database
        /// </summary>
        /// <param name="theater">The theater object to insert into the database</param>
        public async Task<bool> CreateTheaterAsync(Theater theater)
        {
            _context.Theaters.Add(theater);
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException exc)
            {
                // instead of WriteLine use Logging for exception
                Console.WriteLine($"There was a problem updating the Db => {exc.InnerException}");
                return false;
            }
            catch (DbUpdateException exc)
            {
                Console.WriteLine($"There was a problem updating the Db => {exc.InnerException}");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Removes a theater from the database
        /// </summary>
        /// <param name="theaterId">The ID of the theater to remove</param>
        public async Task<bool> DeleteTheaterAsync(int theaterId)
        {
            var theaterToDelete = _context.Theaters.Where(th => th.TheaterId == theaterId).FirstOrDefault();
            _context.Theaters.Remove(theaterToDelete);
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException exc)
            {
                // instead of WriteLine use Logging for exception
                Console.WriteLine($"There was a problem updating the Db => {exc.InnerException}");
                return false;
            }
            catch (DbUpdateException exc)
            {
                Console.WriteLine($"There was a problem updating the Db => {exc.InnerException}");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Updates some information about a specific theater
        /// </summary>
        /// <param name="theaterId">The ID of the theater to update</param>
        /// <param name="theaterLoc">[optional] The potential change in location of the theater</param>
        /// <param name="theaterName">[optional] The ptential change in name of the theater</param>
        public async Task<bool> UpdateTheaterAsync(int theaterId, string theaterLoc = "", string theaterName = "")
        {
            if (theaterLoc == "" && theaterName == "") return false;
            var theaterToUpdate = _context.Theaters.Where(th => th.TheaterId == theaterId).FirstOrDefault();
            if (theaterLoc != "") theaterToUpdate.TheaterLoc = theaterLoc;
            if (theaterName != "") theaterToUpdate.TheaterName = theaterName;
            _context.Theaters.Update(theaterToUpdate);
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException exc)
            {
                // instead of WriteLine use Logging for exception
                Console.WriteLine($"There was a problem updating the Db => {exc.InnerException}");
                return false;
            }
            catch (DbUpdateException exc)
            {
                Console.WriteLine($"There was a problem updating the Db => {exc.InnerException}");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selects all of the theaters from the theaters table
        /// </summary>
        /// <returns>A list of Theater objects representing the theaters in the table</returns>
        public List<Theater> SelectTheaters()
        {
            var TheatersTable = _context.Theaters;
            List<Theater> Theaters = new();
            foreach (var th in TheatersTable)
            {
                Theater theater = new()
                {
                    TheaterId = th.TheaterId,
                    TheaterLoc = th.TheaterLoc,
                    TheaterName = th.TheaterName,
                    TheaterMovies = th.TheaterMovies
                };
                Theaters.Add(theater);
            }
            return Theaters;
        }

        /// <summary>
        /// Selects a specific theater
        /// </summary>
        /// <param name="theaterId">The ID of the theater to select</param>
        /// <returns>A Theater object representing the specified theater</returns>
        public Theater SelectTheater(int theaterId)
        {
            var TheatersTable = _context.Theaters;
            var dbResults = TheatersTable.Where(th => th.TheaterId == theaterId).ToList();
            Theater theater = null;
            foreach (var th in TheatersTable)
            {
                theater = new()
                {
                    TheaterId = th.TheaterId,
                    TheaterLoc = th.TheaterLoc,
                    TheaterName = th.TheaterName,
                    TheaterMovies = th.TheaterMovies
                };
            }
            return theater;
        }

        public List<Movie> SelectTheaterMovies(int theaterId)
        {
            var TheatersTable = _context.Theaters;
            var MoviesTable = _context.Movies;
            var ThMoviesTable = _context.TheaterMovies;
            var dbResult = (from thm in ThMoviesTable
                            join th in TheatersTable on thm.TheaterId equals th.TheaterId
                            join m in MoviesTable on thm.MovieId equals m.MovieId
                            where thm.TheaterId == theaterId
                            select new 
                            {
                                m.MovieId,
                                m.MovieName,
                                m.MovieImage
                            }).ToList();
            List<Movie> Movies = new();
            foreach (var res in dbResult)
            {
                Movie movie = new()
                {
                    MovieId = res.MovieId,
                    MovieName = res.MovieName,
                    MovieImage = res.MovieImage
                };
                Movies.Add(movie);
            }
            return Movies;
        }
    }
}


