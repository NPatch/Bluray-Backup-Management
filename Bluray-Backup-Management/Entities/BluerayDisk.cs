using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluray_Backup_Management.Entities
{
    class BluerayDisk
    {
        #region Properties
        private string _name;
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public List<Anime> animeContents;
        public List<Movie> movieContents;
        public List<TvSeries> tvSeriesContents;
        #endregion

        #region Methods
        public BluerayDisk(string name)
        {
            _name = name;
            animeContents = new List<Anime>();
            movieContents = new List<Movie>();
            tvSeriesContents = new List<TvSeries>();
        }

        public bool IsWatched()
        {
            bool animesWatched = (from a in animeContents where !a.IsWatched() select a).ToList<Anime>().Count == 0;
            bool moviesWatched = (from m in movieContents where !m.Watched select m).ToList<Movie>().Count == 0;
            bool showsWatched = (from s in tvSeriesContents where !s.IsWatched() select s).ToList<TvSeries>().Count == 0;
            return (animesWatched && moviesWatched && showsWatched);
        }

        public void AddAnime(Anime anime)
        {
            //If it's not in the episode list
            if ((from a in animeContents where a.Name == anime.Name select a).ToList<Anime>().Count == 0)
            {
                //Add it
                animeContents.Add(anime);
            }
        }

        public void AddAnimes(params Anime[] animesList)
        {
            foreach (Anime anime in animesList)
            {
                AddAnime(anime);
            }
        }

        public void AddMovie(Movie movie)
        {
            //If it's not in the episode list
            if ((from m in movieContents where m.Name == movie.Name select m).ToList<Movie>().Count == 0)
            {
                //Add it
                movieContents.Add(movie);
            }
        }

        public void AddMovies(params Movie[] moviesList)
        {
            foreach (Movie movie in moviesList)
            {
                AddMovie(movie);
            }
        }

        public void AddShow(TvSeries show)
        {
            //If it's not in the episode list
            if ((from s in tvSeriesContents where s.Name == show.Name select s).ToList<TvSeries>().Count == 0)
            {
                //Add it
                tvSeriesContents.Add(show);
            }
        }

        public void AddShows(params TvSeries[] showsList)
        {
            foreach (TvSeries show in showsList)
            {
                AddShow(show);
            }
        }
        #endregion
    }
}
