using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bluray_Backup_Management.Managers;

namespace Bluray_Backup_Management
{
    public partial class BBMForm : Form
    {
        DiskManager diskManager;
        AnimeManager animeManager;
        MovieManager movieManager;
        TvSeriesManager showsManager;

        private void InitializeDataBase()
        {
            //Initialize Managers
            diskManager = DiskManager.Instance;
            animeManager = AnimeManager.Instance;
            movieManager = MovieManager.Instance;
            showsManager = TvSeriesManager.Instance;

            //Register Managers to New Disk event
            diskManager.diskAdded += animeManager.OnNewDisk;
            diskManager.diskAdded += movieManager.OnNewDisk;
            diskManager.diskAdded += showsManager.OnNewDisk;

            //Register Manager Handlers of ApplicationExit event
            Application.ApplicationExit += diskManager.OnApplicationExit;
            Application.ApplicationExit += animeManager.OnApplicationExit;
            Application.ApplicationExit += movieManager.OnApplicationExit;
            Application.ApplicationExit += showsManager.OnApplicationExit;
        }

        public BBMForm()
        {
            InitializeDataBase();
            InitializeComponent();
        }
    }
}
