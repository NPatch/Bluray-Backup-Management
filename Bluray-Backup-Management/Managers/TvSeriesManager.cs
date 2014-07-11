using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluray_Backup_Management.Entities;

namespace Bluray_Backup_Management.Managers
{
    public class TvSeriesManager : Singleton<TvSeriesManager>
    {
        #region Properties
        Dictionary<char, List<TvSeries>> shows;
        #endregion

        #region Inteface Properties

        #endregion

        #region Event Handlers
        public void OnNewDisk(BluerayDisk disk)
        {
            AddShows(disk.tvSeriesContents.ToArray());
        }
        #endregion

        #region Methods
        public TvSeriesManager()
        {
            shows = new Dictionary<char, List<TvSeries>>();
            DiskManager.Instance.diskAdded += this.OnNewDisk;
        }

        public void AddShow(TvSeries show)
        {
            if ((from s in shows[show.Name[0]] where s.Name == show.Name select s).ToList<TvSeries>().Count == 0)
            {
                char initial = show.Name[0];
                if (shows[initial] == null)
                {
                    shows[initial] = new List<TvSeries>();
                }
                shows[initial].Add(show);
            }
        }

        public void AddShows(params TvSeries[] showsList)
        {
            foreach (TvSeries show in showsList)
            {
                AddShow(show);
            }
        }

        public void OnApplicationExit(object sender, EventArgs e)
        {
            _ApplicationQuitting = true;
            shows.Clear();
        }
        #endregion

        #region Interface Methods

        #endregion
    }
}
