﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCharts.Models
{
    public class Singer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateEnd { get; set; }

        public virtual ICollection<SingerTrack> SingerTrack { get; set; } = new HashSet<SingerTrack>();
        [NotMapped]
        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>(); 
    }
}
