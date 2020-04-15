using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCharts.Models
{
    public class Singer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateEnd { get; set; }

        public virtual ICollection<SingerTrack> SingerTracks { get; set; } = new HashSet<SingerTrack>();
        [NotMapped]
        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();
    }
}