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
    public List<Schedule> SelectMovieSchedules(string movieId, int theaterId)
    {
      var ScheduleTables = _context.Schedules;
      var dbResults = ScheduleTables.Where(sch => sch.MovieId == movieId && sch.TheaterId == theaterId).ToList();
      List<Schedule> Schedules = new();
      foreach (var res in dbResults)
      {
        Schedule schedule = new()
        {
          ScheduleId = res.ScheduleId,
          MovieId = res.MovieId,
          Movie = res.Movie,
          TheaterId = res.TheaterId,
          Theater = res.Theater,
          ShowingTime = res.ShowingTime
        };
        Schedules.Add(schedule);
      }
      return Schedules;
    }

    public async Task<bool> CreateScheduleAsync(Schedule schedule)
    {
      await _context.Schedules.AddAsync(schedule);
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

    public async Task<bool> DeleteScheduleAsync(int scheduleId)
    {
      var scheduleToDelete = _context.Schedules.Where(th => th.ScheduleId == scheduleId).FirstOrDefault();
      _context.Schedules.Remove(scheduleToDelete);
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
  }
}
