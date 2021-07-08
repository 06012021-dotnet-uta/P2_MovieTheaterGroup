using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace P2DatabaseModelLibrary
{
    public class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Ratings = new HashSet<Rating>();
        }

        public int UserId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }
        [Required]
        [MaxLength(20)]
        public string Passwd { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
