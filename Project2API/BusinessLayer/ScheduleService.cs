using ModelsLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
  public class ScheduleService : IScheduleService
  {
    private readonly P2Context _context;

    /// <summary>
    /// Initializes an instance of the database models.
    /// </summary>
    /// <param name="context">A DbContext object</param>
    public ScheduleService(P2Context context)
    {
      this._context = context;
    }

    /// <summary>
    /// Selects the specified movie schedule
    /// </summary>
    /// <param name="movieId">The ID of the movie whose schedule to retrieve</param>
    /// <param name="theaterId">The ID of the theater the move is playing at</param>
    /// <returns>A Schedule object representing the specified schedule from the database</returns>
    public Schedule SelectMovieSchedule(string movieId, int theaterId)
    {
      var ScheduleTables = _context.Schedules;
      var dbResults = ScheduleTables.Where(sch => sch.MovieId == movieId && sch.TheaterId == theaterId).ToList();
      Schedule schedule = new();
      foreach (var res in dbResults)
      {
        schedule = new()
        {
          ScheduleId = res.ScheduleId,
          MovieId = res.MovieId,
          Movie = res.Movie,
          TheaterId = res.TheaterId,
          Theater = res.Theater,
          ShowingTime = res.ShowingTime
        };
      }
      return schedule;
    }
  }
}
