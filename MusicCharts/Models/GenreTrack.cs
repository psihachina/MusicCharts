using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCharts.Models
{
    public class GenreTrack
    {
        public int ID { get; set; }
        public int IDTrack { get; set; }
        public int IDGenre { get; set; }
        [ForeignKey(nameof(GenreTrack.IDTrack))]
        public Track Track { get; set; }
        [ForeignKey(nameof(GenreTrack.IDGenre))]
        public Genre Genre { get; set; }
    }
}
