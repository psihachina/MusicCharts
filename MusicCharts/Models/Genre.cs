using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCharts.Models
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<GenreTrack> GenreTrack { get; set; } = new HashSet<GenreTrack>();
        [NotMapped]
        public virtual IEnumerable<Track> Tracks { get { return GenreTrack.Select((x) => x.Track); } }
    }
}
