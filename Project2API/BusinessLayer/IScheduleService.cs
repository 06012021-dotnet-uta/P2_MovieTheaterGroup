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
    // ^^^ Passed ^^^
    // ^^^ Failed ^^^
    Schedule SelectMovieSchedule(string movieId, int theaterId);
    // ^^^ Untested ^^^
  }
}
