using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlurayBackupManagement.Entities;

namespace BlurayBackupManagement.Managers
{
    public class MovieManager : Singleton<MovieManager>
    {
        #region Properties
        Dictionary<char, List<Movie>> movies;
        #endregion

        #region Inteface Properties

        #endregion

        #region Event Handlers
        public void OnNewDisk(BluerayDisk disk)
        {
            AddMovies(disk.movieContents.ToArray());
        }
        #endregion

        #region Methods
        public MovieManager()
        {
            movies = new Dictionary<char, List<Movie>>();
        }

        public void AddMovie(Movie movie)
        {
            if (!movies.Keys.Contains(movie.Name[0]))
            {
                movies.Add(movie.Name[0], new List<Movie>());
            }
            if ((from m in movies[movie.Name[0]] where m.Name == movie.Name select m).ToList<Movie>().Count == 0)
            {
                char initial = movie.Name[0];
                if (movies[initial] == null)
                {
                    movies[initial] = new List<Movie>();
                }
                movies[initial].Add(movie);
            }
        }

        public void AddMovies(params Movie[] moviesList)
        {
            foreach (Movie movie in moviesList)
            {
                AddMovie(movie);
            }
        }

        public void OnApplicationExit(object sender, EventArgs e)
        {
            _ApplicationQuitting = true;
            movies.Clear();
        }
        #endregion

        #region Interface Methods

        #endregion
    }
}
