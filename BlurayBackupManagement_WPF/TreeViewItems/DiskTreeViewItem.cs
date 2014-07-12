using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using BlurayBackupManagement.Entities;

namespace BlurayBackupManagement_WPF.TreeViewItems
{
    public class DiskTreeViewItem : TreeViewItem
    {
        #region Properties
        TreeView diskContents;
        BluerayDisk diskPointer;
        #endregion

        #region Constructor

        public DiskTreeViewItem(BluerayDisk disk)
        {
            CreateTreeViewItemTemplate(disk);
        }

        #endregion

        #region Private Methods
        private void DiskContents_AddedItem()
        {
            /*foreach (char initial in diskManager.disks.Keys)
            {
                TreeViewItem itemInitial;
                Dictionary<char, TreeViewItem> items = (from TreeViewItem item in treeView1.Items select item).ToDictionary<TreeViewItem, char>(k => k.Name[0]);
                if (!items.Keys.Contains(initial))
                {
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
    ).ToDictionary<DiskTreeViewItem, string>(k => k.Name);

                    if (!itemDisks.Keys.Contains(disk.Name))
                    {
                        itemDisk = new DiskTreeViewItem(disk.Name);
                        itemInitial.Items.Add(itemDisk);
                    }
                    else
                    {
                        itemDisk = itemDisks[disk.Name];
                    }
                }
            }*/
        }

        private void DiskContents_InitialPopulate()
        {
            TreeViewItem animeItems = new TreeViewItem();
                    animeItems.Name = diskPointer.Name+"_animeItems";
                    animeItems.Header = "Anime";
                    diskContents.Items.Add(animeItems);

            TreeViewItem moviesItems = new TreeViewItem();
                    moviesItems.Name = diskPointer.Name+"_moviesItems";
                    moviesItems.Header = "Movies";
                    diskContents.Items.Add(moviesItems);

            TreeViewItem showsItems = new TreeViewItem();
                    showsItems.Name = diskPointer.Name+"_showsItems";
                    showsItems.Header = "Tv Series";
                    diskContents.Items.Add(showsItems);


            foreach (Anime ani in diskPointer.animeContents)
            {
                
                TreeViewItem anime = new TreeViewItem();
                    anime.Name = ani.Name;
                    anime.Header = ani.Name;
                    animeItems.Items.Add(anime);
            }

            foreach (Movie mov in diskPointer.movieContents)
            {
                TreeViewItem movie = new TreeViewItem();
                    movie.Name = mov.Name;
                    movie.Header = mov.Name;
                    moviesItems.Items.Add(movie);
            }

            foreach (TvSeries shw in diskPointer.tvSeriesContents)
            {
                TreeViewItem show = new TreeViewItem();
                    show.Name = shw.Name;
                    show.Header = shw.Name;
                    showsItems.Items.Add(show);
            }
        }

        private void CreateTreeViewItemTemplate(BluerayDisk disk)
        {
            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;

            stack.Name = disk.Name;

            Label text = new Label();
            text.Content = disk.Name;

            stack.Children.Add(text);

            diskContents = new TreeView();

            stack.Children.Add(diskContents);

            Header = stack;
            Name = disk.Name;

            diskPointer = disk;
            DiskContents_InitialPopulate();
            //Hook up an update function for the representation of the internal TreeView to the itemAdded event of the disk
        }

        #endregion
    }
}
