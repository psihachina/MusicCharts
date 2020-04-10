using MusicCharts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCharts.DAL
{
    public class LocalStorage
    {
        static LocalStorage insatence;

        public static LocalStorage Insatence =>
            insatence ?? (insatence = new LocalStorage());
        
        private LocalStorage()
        {
            var singers = (List<Singer>)Singers;
            singers.Add(new Singer { Name = "Гражданская оборона" });
            singers.Add(new Singer { Name = "Кино" });
            singers.Add(new Singer { Name = "Би-2" });
            singers.Add(new Singer { Name = "Лолита" });
            singers.Add(new Singer { Name = "Лобода" });
            singers.Add(new Singer { Name = "Оксимирон" });
            singers.Add(new Singer { Name = "Linking PArk" });
            singers.Add(new Singer { Name = "Bring me the horizon" });

            var genres = (List<Genre>)Genres;
            genres.Add(new Genre { Name = "Рок" });
            genres.Add(new Genre { Name = "Алт. рок" });
            genres.Add(new Genre { Name = "Поп" });
            genres.Add(new Genre { Name = "Рэп" });


            var tracks = (List<Track>)Tracks;
            tracks.Add(new Track { Name = "Всё идет по плану" });
            tracks.Add(new Track { Name = "Моя оборона" });

            ((List<Track>)singers[0].Tracks).AddRange(tracks.Take(2));
            ((List<Track>)genres[0].Tracks).AddRange(tracks.Take(2));

            ((List<Singer>)tracks[0].Singers).Add(singers[0]);
            ((List<Genre>)tracks[0].Genres).Add(genres[0]);
            ((List<Singer>)tracks[1].Singers).Add(singers[0]);
            ((List<Genre>)tracks[1].Genres).Add(genres[0]);


            tracks.Add(new Track { Name = "Кукушка" });
            tracks.Add(new Track { Name = "Группа крови" });
            tracks.Add(new Track { Name = "Восмиклассница" });
            tracks.Add(new Track { Name = "Видили ночь" });
            tracks.Add(new Track { Name = "Звезда по имени Солнце" });
            tracks.Add(new Track { Name = "Перемен" });

            ((List<Track>)singers[0].Tracks).AddRange(tracks.Skip(2).Take(6));
            ((List<Track>)genres[0].Tracks).AddRange(tracks.Skip(2).Take(6));

            foreach (var item in tracks.Skip(2).Take(6))
            {
                ((List<Singer>)item.Singers).Add(singers[1]);
                ((List<Genre>)item.Genres).Add(genres[0]);
            }
        }

        public IEnumerable<Track> Tracks { get; } = new List<Track>();
        public IEnumerable<Singer> Singers { get; } = new List<Singer>();
        public IEnumerable<Genre> Genres { get; } = new List<Genre>();

    }
}
