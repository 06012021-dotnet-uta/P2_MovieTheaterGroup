using System;
using System.ComponentModel.DataAnnotations;

namespace MapperClasses
{
    public class CommentMapBasic
    {
        [Required]
        [MaxLength(30)]
        public string MovieId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(210)]
        public string Content { get; set; }
        public DateTime DateMade { get; set; }
    }

}
