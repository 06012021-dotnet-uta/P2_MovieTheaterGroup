using ModelsLayer;

using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TheaterService : ITheaterService
  {
    // private readonly P2Context _context;

    // /// <summary>
    // /// Initializes an instance of the database models.
    // /// </summary>
    // /// <param name="context"></param>
    // public TheaterService(P2Context context)
    // {
    //   _context = context;
    // }

    // /// <summary>
    // /// Creates and inserts a theater into the database
    // /// </summary>
    // /// <param name="theaterLoc">The location name where the theater is</param>
    // /// <param name="theaterName">The name of the theater</param>
    // public async void CreateTheaterAsync(string theaterLoc, string theaterName)
    // {
    //   Theater newTheater = new() 
    //   {
    //     TheaterLoc = theaterLoc,
    //     TheaterName = theaterName
    //   };
    //   _context.Add(newTheater);
    //   await _context.SaveChangesAsync();
    // }

    // public async void DeleteTheaterAsync(int theaterId)
    // {
    //   var theaterToDelete = _context.Theaters.Where(th => th.TheaterId == theaterId).FirstOrDefault();
    //   _context.Theaters.Remove(theaterToDelete);
    //   await _context.SaveChangesAsync();
    // }

    // public async void UpdateTheaterAsync(int theaterId, string theaterLoc = "", string theaterName = "")
    // {
    //   if (theaterLoc == "" && theaterName == "") return;
    //   var theaterToUpdate = _context.Theaters.Where(th => th.TheaterId == theaterId).FirstOrDefault();
    //   if (theaterLoc != "") theaterToUpdate.TheaterLoc = theaterLoc;
    //   if (theaterName != "") theaterToUpdate.TheaterName = theaterName;
    //   _context.Theaters.Update(theaterToUpdate);
    //   await _context.SaveChangesAsync();
    // }

    //public 
  }
}
