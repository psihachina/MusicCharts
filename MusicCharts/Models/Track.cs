using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCharts.Models
{
    public class Track
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        public TimeSpan? Time { get; set; }
        public string Text { get; set; }
        public string Path { get; set; }


        public virtual ICollection<GenreTrack> GenreTrack { get; set; } = new HashSet<GenreTrack>();
        [NotMapped]
        public IEnumerable<Genre> Genres => GenreTrack.Select(x => x.Genre);


        [NotMapped]
        public virtual ICollection<AlboumTrack> AlboumTrack { get; set; } = new List<AlboumTrack>();
        [NotMapped]
        public virtual IEnumerable<Alboum> Alboums { get { return AlboumTrack.Select((x) => x.Alboum); } }


        [NotMapped]
        public virtual ICollection<ChartTrack> ChartTrack { get; set; } = new List<ChartTrack>();
        [NotMapped]
        public virtual IEnumerable<Chart> Charts { get { return ChartTrack.Select((x) => x.Chart); } }



        public virtual ICollection<SingerTrack> SingerTrack { get; set; } = new HashSet<SingerTrack>();
        [NotMapped]
        public IEnumerable<Singer> Singers => SingerTrack.Select(x => x.Singer);


        [NotMapped]
        public virtual ICollection<CharacterTrack> CharacterTrack { get; set; } = new List<CharacterTrack>();
        [NotMapped]
        public virtual IEnumerable<Character> Characters { get { return CharacterTrack.Select((x) => x.Character); } }
    }
}
