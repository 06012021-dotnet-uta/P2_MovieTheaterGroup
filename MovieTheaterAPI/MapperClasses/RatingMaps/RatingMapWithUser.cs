using System;
using System.ComponentModel.DataAnnotations;

namespace MapperClasses
{
    public class RatingMapWithUser
    {
        public int RatingId { get; set; }

        [Required]
        [MaxLength(30)]
        public string MovieId { get; set; }

        [Required]
        [MaxLength(30)]
        public int UserId { get; set; }

        [Required]
        public int Content { get; set; }
        public DateTime DateMade { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
    }

}
