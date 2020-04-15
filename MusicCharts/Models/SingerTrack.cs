﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCharts.Models
{
    public class SingerTrack
    {
        public int ID { get; set; }
        public int IDTrack { get; set; }
        public int IDSinger { get; set; }

        [ForeignKey(nameof(SingerTrack.IDTrack))]
        public Track Track { get; set; }

        [ForeignKey(nameof(SingerTrack.IDSinger))]
        public Singer Singer { get; set; }
    }
}