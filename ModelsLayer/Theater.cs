using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ModelsLayer
{
    public  class Theater
    {
       

        [Key]
        public int TheaterId { get; set; }

        [Required]
        [MaxLength(25)]
        public string TheaterLoc { get; set; }

        [Required]
        [MaxLength(30)]
        public string TheaterName { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<TheaterMovie> TheaterMovies { get; set; }

        public Theater()
        {
            TheaterLoc = "3038 Holland Bronx, NY 10467";
            TheaterName = "AMC";
           // Schedules = new HashSet<Schedule>();
           //  TheaterMovies = new HashSet<TheaterMovie>();
        }
        public Theater(string theaterLoc, string theaterName)
        {
            this.TheaterLoc = theaterLoc;
            this.TheaterName = theaterName;
           
        }
    }
}
