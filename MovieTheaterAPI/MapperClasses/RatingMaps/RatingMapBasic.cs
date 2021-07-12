using System;
using System.ComponentModel.DataAnnotations;

namespace MapperClasses
{
    public class RatingMapBasic
    {
        [Required]
        [MaxLength(30)]
        public string MovieId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int Content { get; set; }
        public DateTime DateMade { get; set; }
    }

}
