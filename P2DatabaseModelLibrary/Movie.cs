using System;
using System.Collections.Generic;

#nullable disable

namespace P2DatabaseModelLibrary
{
    public partial class Movie
    {
        public Movie()
        {
            Comments = new HashSet<Comment>();
            Ratings = new HashSet<Rating>();
            Schedules = new HashSet<Schedule>();
            TheaterMovies = new HashSet<TheaterMovie>();
        }

        public string MovieId { get; set; }
        public string MovieName { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<TheaterMovie> TheaterMovies { get; set; }
    }
}
