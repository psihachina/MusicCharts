using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCharts.Models
{
    public class ChartTrack
    {
        public int ID { get; set; }
        public int IDTrack { get; set; }
        public int IDChart { get; set; }
        [ForeignKey("IDTrack")]
        public virtual Track Track { get; set; }
        [ForeignKey("IDChart")]
        public virtual Chart Chart { get; set; }
    }
}
