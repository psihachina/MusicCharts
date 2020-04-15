using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicCharts.DAL;

namespace MusicCharts.Controllers
{
    public class AlboumsController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new Context())
            {
                var model = db.Track
                              .Include(x => x.AlboumTracks)
                              .ThenInclude(x => x.Alboum)
                              .Include(x => x.SingerTracks)
                              .ThenInclude(x => x.Singer)
                              .ToList()
                              .SelectMany(x => x.AlboumTracks)
                              .Select(x => x.Alboum)
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