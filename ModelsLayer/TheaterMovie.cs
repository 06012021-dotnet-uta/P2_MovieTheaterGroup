﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ModelsLayer
{
    public  class TheaterMovie
    {
        [Required]
        [MaxLength(30)]
        [ForeignKey("MovieId")]
        public string MovieId { get; set; }

        //[Required]
        [ForeignKey("TheaterId")]
        public int TheaterId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Theater Theater { get; set; }
    }
}
