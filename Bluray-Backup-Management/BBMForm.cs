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
using Bluray_Backup_Management.Entities;

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

        private void InitializeTreeViews()
        {
            // Display a wait cursor while the TreeNodes are being created.
            //Cursor.Current = new Cursor("MyWait.cur");

            // Suppress repainting the TreeView until all the objects have been created.
            treeView1.BeginUpdate();

            // Clear the TreeView each time the method is called.
            treeView1.Nodes.Clear();

            // Add a root TreeNode for each letter. 
            foreach (char initial in diskManager.disks.Keys)
            {
                treeView1.Nodes.Add(initial.ToString(),initial.ToString());
                // Add a child treenode for each disk under each letter. 
                foreach(BluerayDisk disk in diskManager.disks[initial])
                {
                    treeView1.Nodes[initial.ToString()].Nodes.Add(disk.Name, disk.Name);
                }
            }

            // Reset the cursor to the default for all controls.
            //Cursor.Current = Cursors.Default;

            // Begin repainting the TreeView.
            treeView1.EndUpdate();

            diskManager.itemAdded += this.treeView1_AddedItem;
        }

        public BBMForm()
        {
            InitializeDataBase();
            BluerayDisk nikos = new BluerayDisk("Nikos");
            nikos.AddAnimes(new Anime("Nikos1"),new Anime("Nikos2"));
            BluerayDisk jenny = new BluerayDisk("Jenny");
            jenny.AddShows(new TvSeries("Jenny1"),new TvSeries("Jenny2"));
            BluerayDisk daphne = new BluerayDisk("Daphne");
            daphne.AddMovies(new Movie("Daphne1"), new Movie("Daphne2"));
            this.diskManager.AddDisks(nikos,jenny);
            InitializeComponent();
            InitializeTreeViews();
            this.diskManager.AddDisk(daphne);
        }

        #region Event Handlers
        #region TreeView
        private void treeView1_AddedItem()
        {
            this.treeView1.BeginUpdate();

            foreach (char initial in diskManager.disks.Keys)
            {
                if (!treeView1.Nodes.ContainsKey(initial.ToString()))
                {
                    treeView1.Nodes.Add(initial.ToString(), initial.ToString());
                }
                // Add a child treenode for each disk under each letter. 
                foreach (BluerayDisk disk in diskManager.disks[initial])
                {
                    if (!treeView1.Nodes[initial.ToString()].Nodes.ContainsKey(disk.Name))
                    {
                        treeView1.Nodes[initial.ToString()].Nodes.Add(disk.Name,disk.Name);
                    }
                }
            }

            this.treeView1.EndUpdate();
        }
        #endregion
        #endregion
    }
}
