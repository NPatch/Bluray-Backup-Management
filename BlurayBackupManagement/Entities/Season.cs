using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlurayBackupManagement.Entities
{
    public class Season
    {
        #region Properties
        private int _number;
        public int Number
        {
            get { return _number; }
            private set { _number = value; }
        }

        public List<Episode> episodes;

        public int EpisodeCount
        {
            get { return episodes.Count; }
        }
        #endregion

        #region Inteface Properties

        #endregion

        #region Methods
        public Season(int number)
        {
            _number = number;
            episodes = new List<Episode>();
        }

        public bool IsWatched()
        {
            return (from eps in episodes where !eps.Watched select eps).ToList<Episode>().Count == 0;
        }

        public void AddEpisode(Episode episode)
        {
            //If it's not in the episode list
            if((from eps in episodes where eps.Number == episode.Number select eps).ToList<Episode>().Count == 0){
                //Add it
                episodes.Add(episode);
            }
        }

        public void AddEpisodes(params Episode[] episodesList)
        {
            foreach (Episode episode in episodesList)
            {
                AddEpisode(episode);
            }
        }
        #endregion

        #region Interface Methods

        #endregion
    }
}
