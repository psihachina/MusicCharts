using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicCharts.DAL;

namespace MusicCharts.Controllers
{
    public class MusicController : Controller
    {
        private readonly ILogger<MusicController> _logger;

        public MusicController(ILogger<MusicController> logger)
        {
            _logger = logger;
        }

        public IActionResult Info(int id)
        {
            using (var db = new Context())
            {
                var model = db.Track.Include(x => x.SingerTracks)
                                    .ThenInclude(x => x.Singer)
                                    .Include(x => x.GenreTracks)
                                    .ThenInclude(x => x.Genre)
                                    .Where(x => x.SingerTracks.Any(y => y.IDTrack == id))
                                    .ToList()
                                    .FirstOrDefault();
                return View(model);
            }
        }
    }
}