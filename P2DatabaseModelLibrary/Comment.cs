﻿using System;
using System.Collections.Generic;

#nullable disable

namespace P2DatabaseModelLibrary
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string MovieId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime DateMade { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
