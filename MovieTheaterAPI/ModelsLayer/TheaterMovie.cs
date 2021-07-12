using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ModelsLayer
{
    public  class TheaterMovie
    {
        [Key]
        public int TheaterMovieId { get; set; }



        //[Required]
        [MaxLength(30)]
        [ForeignKey("MovieId")]
        public string MovieId { get; set; }

        //[Required]
        [ForeignKey("TheaterId")]
        public int TheaterId { get; set; }

        public  Movie Movie { get; set; }
        public  Theater Theater { get; set; }

        public TheaterMovie()
        {
            MovieId = "A0";
            TheaterId = 0;
        }
        public TheaterMovie(string movieId, int theaterid)
        {
            this.MovieId = movieId;
            this.TheaterId = theaterid;
        }
    }
}
