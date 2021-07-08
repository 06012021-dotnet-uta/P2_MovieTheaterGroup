using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ModelsLayer
{
    public  class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int RoleId { get; set; }

        [Required]
        [MaxLength(20)]
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
