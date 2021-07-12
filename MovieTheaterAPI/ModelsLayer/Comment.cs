using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ModelsLayer
{
    public  class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [ForeignKey("MovieId")]
        [Required]
        [MaxLength(30)]
        public string MovieId { get; set; }

        [ForeignKey("UserId")]
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(210)]
        public string Content { get; set; }
        public DateTime DateMade { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
