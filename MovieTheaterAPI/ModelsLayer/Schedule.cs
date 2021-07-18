using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ModelsLayer
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class Schedule
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
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

        public override bool Equals(object obj)
        {
            if (obj is Schedule)
            {
                var that = obj as Schedule;
                return (this.ScheduleId == that.ScheduleId &&
                  this.MovieId == that.MovieId &&
                  this.TheaterId == that.TheaterId &&
                  this.ShowingTime == that.ShowingTime);
            }
            return false;
        }
    }
}
