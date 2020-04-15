using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicCharts.Models
{
    public class Track
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public TimeSpan? Time { get; set; }
        [MaxLength(200)]
        public string Path { get; set; }
        public virtual ICollection<GenreTrack> GenreTracks { get; set; } = new HashSet<GenreTrack>();
        [NotMapped]
        public IEnumerable<Genre> Genres => GenreTracks.Select(x => x.Genre);

        public virtual ICollection<SingerTrack> SingerTracks { get; set; } = new HashSet<SingerTrack>();
        [NotMapped]
        public IEnumerable<Singer> Singers => SingerTracks.Select(x => x.Singer);

        public virtual ICollection<ChartTrack> ChartTracks { get; set; } = new HashSet<ChartTrack>();
        [NotMapped]
        public IEnumerable<Chart> Charts => ChartTracks.Select(x => x.Chart);

        public virtual ICollection<AlboumTrack> AlboumTracks { get; set; } = new HashSet<AlboumTrack>();
        [NotMapped]
        public IEnumerable<Alboum> Alboums => AlboumTracks.Select(x => x.Alboum);
    }
}
