using System;
using System.ComponentModel.DataAnnotations;

namespace MapperClasses
{
    public class CommentMapUpdate
    {
        public int CommentId { get; set; }

        [Required]
        [MaxLength(210)]
        public string Content { get; set; }

        public DateTime DateMade { get; set; }
    }

}
