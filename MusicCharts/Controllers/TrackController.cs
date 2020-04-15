﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicCharts.DAL;
using FileIO = System.IO.File;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MusicCharts.Controllers
{
    public class TrackController : Controller
    {
        private readonly ILogger<TrackController> _logger;
        private readonly IWebHostEnvironment _env;
        private const string musicDir = @"D:\Projects\MusicCharts\Music";

        public TrackController(IWebHostEnvironment env, ILogger<TrackController> logger)
        {
            _env = env;
            _logger = logger;
        }
        public IActionResult LoadMusic(int Id)
        {
            using (var db = new Context())
            {
                var track = db.Track.Include(x => x.SingerTracks)
                                    .ThenInclude(x => x.Singer)
                                    .Include(x => x.GenreTracks)
                                    .ThenInclude(x => x.Genre)
                                    .FirstOrDefault(x => x.ID == Id);

                if (track == null)
                {
                    var ex = new Exception($"Track is not found by ID = {Id}");
                    _logger.LogWarning(ex, "", null);
                    throw ex;
                }
                if (string.IsNullOrEmpty(track.Path))
                {
                    var ex = new Exception($"Track path is empty by ID = {Id}");
                    _logger.LogWarning(ex, "", null);
                    throw ex;
                }

                var buf = FileIO.ReadAllBytes(Path.Combine(musicDir, track.Path));
                var webPath1 = Path.Combine("audio", $"{track.ID}{Path.GetExtension(track.Path)}");
                var webPath2 = Path.Combine("..\\..\\..\\","audio", $"{track.ID}{Path.GetExtension(track.Path)}");
                var path = Path.Combine(_env.WebRootPath, webPath1);
                var fl = FileIO.Exists(path);
                if(!fl)
                FileIO.WriteAllBytes(path, buf);
                return Json(webPath2);
            }
        }
    }
}