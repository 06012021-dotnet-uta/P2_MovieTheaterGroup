using System;
using System.Collections.Generic;

#nullable disable

namespace P2DatabaseModelLibrary
{
    public partial class Theater
    {
        public Theater()
        {
            Schedules = new HashSet<Schedule>();
            TheaterMovies = new HashSet<TheaterMovie>();
        }

        public int TheaterId { get; set; }
        public string TheaterLoc { get; set; }
        public string TheaterName { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<TheaterMovie> TheaterMovies { get; set; }
    }
}
