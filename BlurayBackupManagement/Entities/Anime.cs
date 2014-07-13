using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlurayBackupManagement.Entities
{
    public class Anime
    {
        #region Properties
        private string _name;
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public List<Season> seasons;
        public List<Movie> movies;
        #endregion

        #region Methods
        public Anime(string name)
        {
            _name = name;
            seasons = new List<Season>();
            movies = new List<Movie>();
        }

        public bool IsWatched()
        {
            bool seasonsWatched = (from s in seasons where !s.IsWatched() select s).ToList<Season>().Count == 0;
            bool moviesWatched = (from m in movies where !m.Watched select m).ToList<Movie>().Count == 0;
            return (seasonsWatched && moviesWatched);
        }

        public void AddSeason(Season season)
        {
            //If it's not in the episode list
            if ((from s in seasons where s.Number == season.Number select s).ToList<Season>().Count == 0)
            {
                //Add it
                seasons.Add(season);
            }
        }

        public void AddSeasons(params Season[] seasonsList)
        {
            foreach (Season season in seasonsList)
            {
                AddSeason(season);
            }
        }

        public void AddMovie(Movie movie)
        {
            //If it's not in the episode list
            if ((from m in movies where m.Name == movie.Name select m).ToList<Movie>().Count == 0)
            {
                //Add it
                movies.Add(movie);
            }
        }

        public void AddMovies(params Movie[] moviesList)
        {
            foreach (Movie movie in moviesList)
            {
                AddMovie(movie);
            }
        }
        #endregion
    }
}
