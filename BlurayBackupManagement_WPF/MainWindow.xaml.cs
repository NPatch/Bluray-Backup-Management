using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BlurayBackupManagement_WPF.Managers;
using BlurayBackupManagement_WPF.Entities;
using BlurayBackupManagement_WPF.TreeViewItems;

namespace BlurayBackupManagement_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
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
            App.Current.Exit += diskManager.OnApplicationExit;
            App.Current.Exit += animeManager.OnApplicationExit;
            App.Current.Exit += movieManager.OnApplicationExit;
            App.Current.Exit += showsManager.OnApplicationExit;
        }

        private void InitializeTreeViews()
        {
            // Clear the TreeView each time the method is called.
            treeView1.Items.Clear();

            // Add a root TreeNode for each letter. 
            foreach (char initial in diskManager.disks.Keys)
            {
                TreeViewItem newInitial = new TreeViewItem();
                newInitial.Name = initial.ToString();
                newInitial.Header = initial.ToString();
                treeView1.Items.Add(newInitial);
                // Add a child treenode for each disk under each letter. 
                foreach(BluerayDisk disk in diskManager.disks[initial])
                {
                    DiskTreeViewItem newDisk = new DiskTreeViewItem(disk);
                    newInitial.Items.Add(newDisk);
                }
            }

            diskManager.itemAdded += this.treeView1_AddedItem;
        }

        public MainWindow()
        {
            InitializeDataBase();
            BluerayDisk nikos = new BluerayDisk("Nikos");
            nikos.AddAnimes(new Anime("Nikos1"), new Anime("Nikos2"));
            BluerayDisk jenny = new BluerayDisk("Jenny");
            jenny.AddShows(new TvSeries("Jenny1"), new TvSeries("Jenny2"));
            BluerayDisk daphne = new BluerayDisk("Daphne");
            daphne.AddMovies(new Movie("Daphne1", true, daphne), new Movie("Daphne2", true, daphne));
            this.diskManager.AddDisks(nikos, jenny);
            InitializeComponent();
            InitializeTreeViews();
            this.diskManager.AddDisk(daphne);
        }

        #region Event Handlers
        #region TreeView
        private void treeView1_AddedItem()
        {
            foreach (char initial in diskManager.disks.Keys)
            {
                TreeViewItem itemInitial;
                Dictionary<char, TreeViewItem> items = (from TreeViewItem item in treeView1.Items select item).ToDictionary<TreeViewItem, char>(k => k.Name[0]);
                if(!items.Keys.Contains(initial)){
                    itemInitial = new TreeViewItem();
                    itemInitial.Name = initial.ToString();
                    itemInitial.Header = initial.ToString();
                    treeView1.Items.Add(itemInitial);
                }
                else
                {
                    itemInitial = items[initial];
                }

                // Add a child treenode for each disk under each letter. 
                foreach (BluerayDisk disk in diskManager.disks[initial])
                {
                    DiskTreeViewItem itemDisk;
                    Dictionary<string, DiskTreeViewItem> itemDisks = (from DiskTreeViewItem itemdisk in itemInitial.Items
                                                                  select itemdisk
    ).ToDictionary<DiskTreeViewItem,string>(k => k.Name);

                    if (!itemDisks.Keys.Contains(disk.Name))
                    {
                        itemDisk = new DiskTreeViewItem(disk);
                        itemInitial.Items.Add(itemDisk);
                    }
                    else
                    {
                        itemDisk = itemDisks[disk.Name];
                    }
                }
            }
        }
        #endregion
        #endregion
    }
}
