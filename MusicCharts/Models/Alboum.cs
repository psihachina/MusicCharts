using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCharts.Models
{
    public class Alboum
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }

        [NotMapped]
        public virtual ICollection<AlboumTrack> AlboumTrack { get; set; } = new List<AlboumTrack>();
        [NotMapped]
        public virtual IEnumerable<Track> Tracks { get { return AlboumTrack.Select((x) => x.Track); } }
    }
}
