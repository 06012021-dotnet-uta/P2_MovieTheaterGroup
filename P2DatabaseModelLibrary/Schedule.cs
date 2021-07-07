using System;
using System.Collections.Generic;

#nullable disable

namespace P2DatabaseModelLibrary
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public int TheaterId { get; set; }
        public string MovieId { get; set; }
        public DateTime ShowingTime { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Theater Theater { get; set; }
    }
}
