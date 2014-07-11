using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluray_Backup_Management.Entities
{
    class TvSeries
    {
        #region Properties
        private string _name;
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public List<Season> seasons;
        #endregion

        #region Inteface Properties

        #endregion

        #region Methods
        public TvSeries(string name)
        {
            _name = name;
            seasons = new List<Season>();
        }

        public bool IsWatched()
        {
            return (from s in seasons where !s.IsWatched() select s).ToList<Season>().Count == 0;
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
        #endregion

        #region Interface Methods

        #endregion
    }
}
