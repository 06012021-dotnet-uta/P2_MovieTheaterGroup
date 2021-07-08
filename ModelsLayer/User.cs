using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Passwd { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "User Role")]
        public int RoleId { get; set; }
        public Role Role { get; set;}

        public User(string username, string passwd, string firstName, string lastName, int roleId){
            this.Username = username;
            this.Passwd = passwd;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.RoleId = roleId;

        }
    }
}
