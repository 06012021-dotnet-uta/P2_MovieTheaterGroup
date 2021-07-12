using System;
using System.ComponentModel.DataAnnotations;

namespace MapperClasses
{
    public class RatingMapUpdate
    {
        public int RatingId { get; set; }

        [Required]
        public int Content { get; set; }

        public DateTime DateMade { get; set; }
    }

}
