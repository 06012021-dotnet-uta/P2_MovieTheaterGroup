using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ModelsLayer
{
    public  class Movie
    {
       
        [Key]
        public string MovieId { get; set; }

        [Required]
        [MaxLength(50)]
        public string MovieName { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<TheaterMovie> TheaterMovies { get; set; }

        public Movie()
        {
            MovieName = "movieName";
            // Comments = new HashSet<Comment>();
            // Ratings = new HashSet<Rating>();
            // Schedules = new HashSet<Schedule>();
            // TheaterMovies = new HashSet<TheaterMovie>();
        }
        public Movie(string moviename)
        {
            this.MovieName = "movieName";
           
        }
    }
}
