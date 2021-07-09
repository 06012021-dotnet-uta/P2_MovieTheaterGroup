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
    public class TheaterMovieService : ITheaterMovieService
    {
        // first define the context 
        private readonly P2Context _context;


        // create a constructor
        /// <summary>
        /// create constructor to make the dependency injection
        /// </summary>
        /// <param name="context"></param>
        public TheaterMovieService(P2Context context) { this._context = context; }

        // admin should add movie to theater 
        public async Task<bool> AddTheaterMovieAsync(TheaterMovie p)
        {
            //create a try/catch to save the player
            await _context.TheaterMovies.AddAsync(p);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine($"There was a problem updating the Db => {ex.InnerException}");
                return false;
            }
            catch (DbUpdateException ex)
            {       //change this to logging
                Console.WriteLine($"There was a problem updating the Db => {ex.InnerException}");
                return false;
            }
            return true;
        }

        // TheaterMovieList 
        public async Task<List<TheaterMovie>> TheaterMovieListAsync()
        {
            List<TheaterMovie> ps = null;
            try
            {
                ps = await _context.TheaterMovies.ToListAsync();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"There was a problem getting the players list => {ex.Message}");
            }
            return ps;
        }

    }
}
