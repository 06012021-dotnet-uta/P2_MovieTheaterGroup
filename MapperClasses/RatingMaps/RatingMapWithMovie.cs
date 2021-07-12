using System;
using System.ComponentModel.DataAnnotations;

namespace MapperClasses
{
    public class RatingMapWithMovie
    {
        public int RatingId { get; set; }

        [Required]
        [MaxLength(30)]
        public string MovieId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int Content { get; set; }
        public DateTime DateMade { get; set; }

        [Required]
        [MaxLength(50)]
        public string MovieName { get; set; }
    }

}
