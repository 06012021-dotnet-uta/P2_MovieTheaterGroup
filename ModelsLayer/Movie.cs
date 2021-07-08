using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    class Movie
    {
        [Key]
        public string MovieId { get; set; }

        [Required]
        public string MovieName { get; set; }
        public Movie( string movieName)
        {
            this.MovieName = movieName;
        }

        //     Comments = new HashSet<Comment>();
        //     Ratings = new HashSet<Rating>();
        //     Schedules = new HashSet<Schedule>();
        //     TheaterMovies = new HashSet<TheaterMovie>();

        // public virtual ICollection<Comment> Comments { get; set; }
        // public virtual ICollection<Rating> Ratings { get; set; }
        // public virtual ICollection<Schedule> Schedules { get; set; }
        // public virtual ICollection<TheaterMovie> TheaterMovies { get; set; }
    }
}
