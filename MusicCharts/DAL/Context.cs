using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MusicCharts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCharts.DAL
{
    public class Context : DbContext
    {
        public DbSet<Track> Track { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Singer> Singer { get; set; }
        public DbSet<GenreTrack> GenreTrack { get; set; }
        public DbSet<SingerTrack> SingerTrack { get; set; }
        public DbSet<ChartTrack> ChartTrack { get; set; }
        public DbSet<AlboumTrack> AlboumTrack { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-CDNKH0P\SQLEXPRESS;Database=mispisit5;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<GenreTrack>()
                .HasOne(x => x.Genre)
                .WithMany(x => x.GenreTracks)
                .HasForeignKey(x => x.IDGenre);

            modelBuilder
                .Entity<GenreTrack>()
                .HasOne(x => x.Track)
                .WithMany(x => x.GenreTracks)
                .HasForeignKey(x => x.IDTrack);

            modelBuilder
                .Entity<SingerTrack>()
                .HasOne(x => x.Singer)
                .WithMany(x => x.SingerTracks)
                .HasForeignKey(x => x.IDSinger);

            modelBuilder
                .Entity<SingerTrack>()
                .HasOne(x => x.Track)
                .WithMany(x => x.SingerTracks)
                .HasForeignKey(x => x.IDTrack);

            modelBuilder
                .Entity<ChartTrack>()
                .HasOne(x => x.Chart)
                .WithMany(x => x.ChartTracks)
                .HasForeignKey(x => x.IDChart);

            modelBuilder
                .Entity<ChartTrack>()
                .HasOne(x => x.Track)
                .WithMany(x => x.ChartTracks)
                .HasForeignKey(x => x.IDTrack);

            modelBuilder
                .Entity<AlboumTrack>()
                .HasOne(x => x.Alboum)
                .WithMany(x => x.AlboumTracks)
                .HasForeignKey(x => x.IDAlboum);

            modelBuilder
                .Entity<AlboumTrack>()
                .HasOne(x => x.Track)
                .WithMany(x => x.AlboumTracks)
                .HasForeignKey(x => x.IDTrack);
        }
    }
}






