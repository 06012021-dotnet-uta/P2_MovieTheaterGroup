using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ITheaterMovieService
    {
        Task<List<TheaterMovie>> TheaterMovieListAsync(); // TheaterMovieList
        Task<bool> AddTheaterMovieAsync(TheaterMovie p); // add TheaterMovie
    }
}
