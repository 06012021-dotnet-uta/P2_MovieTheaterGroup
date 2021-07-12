using System;
using System.ComponentModel.DataAnnotations;

namespace MapperClasses
{
    public class CommentMapWithUser
    {
        public int CommentId { get; set; }

        [Required]
        [MaxLength(30)]
        public string MovieId { get; set; }

        [Required]
        [MaxLength(30)]
        public int UserId { get; set; }

        [Required]
        [MaxLength(210)]
        public string Content { get; set; }
        public DateTime DateMade { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
    }

}
