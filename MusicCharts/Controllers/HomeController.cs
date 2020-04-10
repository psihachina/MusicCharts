using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicCharts.DAL;
using Microsoft.EntityFrameworkCore;

namespace MusicCharts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using (var db = new Context())
            {
                var model = db.Track
                              .Include(x => x.SingerTrack)
                              .ThenInclude(x => x.Singer)
                              .Include(x => x.GenreTrack)
                              .ThenInclude(x => x.Genre)
                              .ToList()
                              .SelectMany(x => x.GenreTrack)
                              .Select(x => x.Genre)
                              .Distinct()
                              .ToList();
                return View(model);
            }
        }
    }
}