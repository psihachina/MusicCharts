using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicCharts.DAL;

namespace MusicCharts.Controllers
{
    public class GenreController : Controller
    {
        private readonly ILogger<GenreController> _logger;

        public GenreController(ILogger<GenreController> logger)
        {
            _logger = logger;
        }

        public IActionResult Info(int id)
        {
            using (var db = new Context())
            {
                var model = db.Track.Include(x => x.SingerTrack)
                                    .ThenInclude(x => x.Singer)
                                    .Include(x => x.GenreTrack)
                                    .ThenInclude(x => x.Genre)
                                    .Where(x => x.GenreTrack.Any(y => y.IDGenre == id))
                                    .ToList()
                                    .SelectMany(x => x.GenreTrack)
                                    .Select(x => x.Genre)
                                    .FirstOrDefault();

                return View(model);
            }
        }
    }
}