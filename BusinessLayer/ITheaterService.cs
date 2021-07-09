using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
  public interface ITheaterService
  {
    Task<bool> CreateTheaterAsync(Theater theater);
    Task<bool> DeleteTheaterAsync(int theaterId);
    Task<bool> UpdateTheaterAsync(int theaterId, string theaterLoc = "", string theaterName = "");
    List<Theater> SelectTheaters();
    Theater SelectTheater(int theaterId);
    // ^^^ Passed ^^^
    // ^^^ Failed ^^^
    // ^^^ Untested ^^^
  }
}
