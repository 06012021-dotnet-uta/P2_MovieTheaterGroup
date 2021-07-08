using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ModelsLayer
{
    public  class Movie
    {
        public Movie()
        {
            Comments = new HashSet<Comment>();
            Ratings = new HashSet<Rating>();
            Schedules = new HashSet<Schedule>();
            TheaterMovies = new HashSet<TheaterMovie>();
        }

        [Key]
        public string MovieId { get; set; }

        [Required]
        [MaxLength(50)]
        public string MovieName { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<TheaterMovie> TheaterMovies { get; set; }
    }
}
