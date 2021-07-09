using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ModelsLayer
{
    public  class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MaxLength(20)]
        public string Passwd { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public User()
        {
            Username = "username";
            Passwd = "passwd";
            FirstName = "firstName";
            LastName = "lastName";
            RoleId = 0;
            //Comments = new HashSet<Comment>();
            //Ratings = new HashSet<Rating>();
        }
        public User( string username, string passwd, string firstName,string lastName, int roleId)
        {
            this.Username = username;
            this.Passwd = passwd;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.RoleId = roleId;
            //Comments = new HashSet<Comment>();
            //Ratings = new HashSet<Rating>();
        }
    }
}
