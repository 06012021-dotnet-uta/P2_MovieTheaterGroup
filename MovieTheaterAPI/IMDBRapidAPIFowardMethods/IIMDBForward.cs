using System.Collections.Generic;
using System.Threading.Tasks;
using MapperClasses;

namespace IMDBRapidAPIFowardMethods
{
    public interface IIMDBForward
    {
        Task<List<IMDBMapAdmin>> IMDBMovieTitleAsync(string searchformovie);

        Task<IMDBMapAdmin> IMDBMovieIDAsync(string searchformovie);
    }
}