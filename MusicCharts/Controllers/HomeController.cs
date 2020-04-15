using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicCharts.DAL;
using Microsoft.EntityFrameworkCore;
using System.IO;

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
                              .Include(x => x.GenreTracks)
                              .ThenInclude(x => x.Genre)
                              .Include(x => x.SingerTracks)
                              .ThenInclude(x => x.Singer)
                              .ToList()
                              .SelectMany(x => x.GenreTracks)
                              .Select(x => x.Genre)
                              .Distinct()
                              .ToList();


                //Чистка папки audio
                DirectoryInfo dirInfo = new DirectoryInfo("D:\\Projects\\MusicCharts\\MusicCharts\\wwwroot\\audio");
                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    file.Delete();
                }


                return View(model);
            }
        }
    }
}