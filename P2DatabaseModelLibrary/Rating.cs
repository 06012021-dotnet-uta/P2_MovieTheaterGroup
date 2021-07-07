using System;
using System.Collections.Generic;

#nullable disable

namespace P2DatabaseModelLibrary
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public string MovieId { get; set; }
        public int UserId { get; set; }
        public int Content { get; set; }
        public DateTime DateMade { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
