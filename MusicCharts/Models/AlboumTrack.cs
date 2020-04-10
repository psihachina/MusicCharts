using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCharts.Models
{
    public class AlboumTrack
    {
        public int ID { get; set; }
        public int IDTrack { get; set; }
        public int IDAlboum { get; set; }
        [ForeignKey("IDTrack")]
        public virtual Track Track { get; set; }
        [ForeignKey("IDAlboum")]
        public virtual Alboum Alboum { get; set; }

        //[NotMapped]
        //public virtual ICollection<AlboumTrack> AlboumTrack { get; set; } = new List<AlboumTrack>();
        //[NotMapped]
        //public virtual IEnumerable<Track> Tracks { get { return AlboumTrack.Select((x) => x.Track); } }
    }
}
