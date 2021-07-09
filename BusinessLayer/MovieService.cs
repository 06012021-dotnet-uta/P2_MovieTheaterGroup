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
    public class MovieService : IMovieService
    {
        // first define the context 
        private readonly P2Context _context;


        // create a constructor
        /// <summary>
        /// create constructor to make the dependency injection
        /// </summary>
        /// <param name="context"></param>
        public MovieService(P2Context context) { this._context = context; }

        // user should see a movie details
        // MovieList
        public async Task<List<Movie>> MovieListAsync()
        {
            List<Movie> ps = null;
            try
            {
                ps = await _context.Movies.ToListAsync();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"There was a problem gettign the players list => {ex.InnerException}"); //or {ex.Message}
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was a problem gettign the players list => {ex}");
            }
            return ps;
        }

    }
}
