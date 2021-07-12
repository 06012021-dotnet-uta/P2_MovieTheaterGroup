using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ModelsLayer
{
    public  class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [ForeignKey("MovieId")]
        public string MovieId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        // [Required]
        // [MaxLength(210)]
        public int Content { get; set; }
        public DateTime DateMade { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
