using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ModelsLayer
{
  public class Theater
  {
    public Theater()
    {
      Schedules = new HashSet<Schedule>();
      TheaterMovies = new HashSet<TheaterMovie>();
    }

    [Key]
    public int TheaterId { get; set; }

    [Required]
    [MaxLength(25)]
    public string TheaterLoc { get; set; }

    [Required]
    [MaxLength(30)]
    public string TheaterName { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; }
    public virtual ICollection<TheaterMovie> TheaterMovies { get; set; }

    public override bool Equals(object obj)
    {
      if (obj is Theater)
      {
        var that = obj as Theater;
        return (this.TheaterId == that.TheaterId &&
          this.TheaterLoc == that.TheaterLoc &&
          this.TheaterName == that.TheaterName);
      }
      return false;
    }
  }
}
