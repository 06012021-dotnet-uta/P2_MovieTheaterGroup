using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ModelsLayer
{
    public  class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }

        [Required]
        [ForeignKey("TheaterId")]
        public int TheaterId { get; set; }

        [Required]
        [ForeignKey("MovieId")]
        public string MovieId { get; set; }
        public DateTime ShowingTime { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Theater Theater { get; set; }
    }
}
