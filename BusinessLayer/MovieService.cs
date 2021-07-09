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

        // admin should schedule a movie 
        // user should see a movie details 

    }
}
