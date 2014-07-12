using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlurayBackupManagement_WPF.Entities;

namespace BlurayBackupManagement_WPF.Managers
{
    public class AnimeManager : Singleton<AnimeManager>
    {
        #region Properties
        Dictionary<char, List<Anime>> animes;
        #endregion

        #region Inteface Properties

        #endregion

        #region Event Handlers
        public void OnNewDisk(BluerayDisk disk)
        {
            AddAnimes(disk.animeContents.ToArray());
        }
        #endregion

        #region Methods
        public AnimeManager()
        {
            animes = new Dictionary<char, List<Anime>>();
        }

        public void AddAnime(Anime anime)
        {
            if (!animes.Keys.Contains(anime.Name[0]))
            {
                animes.Add(anime.Name[0],new List<Anime>());
            }
            if((from a in animes[anime.Name[0]] where a.Name == anime.Name select a).ToList<Anime>().Count == 0){
                char initial = anime.Name[0];
                if (animes[initial] == null)
                {
                    animes[initial] = new List<Anime>();
                }
                animes[initial].Add(anime);
            }
        }

        public void AddAnimes(params Anime[] animesList)
        {
            foreach(Anime anime in animesList){
                AddAnime(anime);
            }
        }

        public void OnApplicationExit(object sender, EventArgs e)
        {
            _ApplicationQuitting = true;
            animes.Clear();
        }
        #endregion

        #region Interface Methods

        #endregion
    }
}
