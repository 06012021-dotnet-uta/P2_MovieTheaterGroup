using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
  public interface IScheduleService
  {
    List<Schedule> SelectMovieSchedules(string movieId, int theaterId);
    Task<bool> CreateScheduleAsync(Schedule schedule);
    Task<bool> DeleteScheduleAsync(int scheduleId);
    // ^^^ Passed ^^^
    // ^^^ Failed ^^^
    // ^^^ Untested ^^^
  }
}
