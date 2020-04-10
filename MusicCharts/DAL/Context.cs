using Microsoft.EntityFrameworkCore;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<GenreTrack>()
            //    .HasKey(t => new { t.StudentId, t.CourseId });

            modelBuilder.Entity<GenreTrack>()
                .HasOne(sc => sc.Track)
                .WithMany(s => s.GenreTrack)
                .HasForeignKey(sc => sc.IDTrack);

            modelBuilder.Entity<GenreTrack>()
                .HasOne(sc => sc.Genre)
                .WithMany(c => c.GenreTrack)
                .HasForeignKey(sc => sc.IDGenre);

            modelBuilder.Entity<SingerTrack>()
                .HasOne(sc => sc.Track)
                .WithMany(s => s.SingerTrack)
                .HasForeignKey(sc => sc.IDTrack);

            modelBuilder.Entity<SingerTrack>()
                .HasOne(sc => sc.Singer)
                .WithMany(s => s.SingerTrack)
                .HasForeignKey(sc => sc.IDTrack);

        }
        public Context()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-CDNKH0P\SQLEXPRESS;Database=mispisit5;Trusted_Connection=True;");
        }
    }
}
