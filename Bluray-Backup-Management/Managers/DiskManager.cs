using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluray_Backup_Management.Entities;

namespace Bluray_Backup_Management.Managers
{
    public class DiskManager : Singleton<DiskManager>
    {
        #region Properties
        public Dictionary<char, List<BluerayDisk>> disks;
        #endregion

        #region Inteface Properties

        #endregion

        #region Events
        public delegate void DiskAddedDelegate(BluerayDisk disk);
        public event DiskAddedDelegate diskAdded;

        public delegate void ItemAddedDelegate();
        public event ItemAddedDelegate itemAdded;
        #endregion

        #region Methods
        public DiskManager()
        {
            disks = new Dictionary<char, List<BluerayDisk>>();
        }

        public void AddDisk(BluerayDisk disk)
        {
            if (!disks.ContainsKey(disk.Name[0]))
            {
                disks.Add(disk.Name[0], new List<BluerayDisk>());
            }
            if (!disks[disk.Name[0]].Contains(disk))
            {
                disks[disk.Name[0]].Add(disk);
                OnDiskAdded(disk);
            }
        }

        public void AddDisks(params BluerayDisk[] disksList)
        {
            foreach(BluerayDisk disk in disksList){
                AddDisk(disk);
            }
        }

        public void OnApplicationExit(object sender, EventArgs e)
        {
            _ApplicationQuitting = true;
            disks.Clear();
        }
        #endregion

        #region Interface Methods

        #endregion

        #region Event Functions
        public void OnDiskAdded(BluerayDisk disk)
        {
            if(diskAdded != null){
                diskAdded(disk);
                OnItemAdded();
            }
        }

        public void OnItemAdded()
        {
            if(itemAdded != null){
                itemAdded();
            }
        }
        #endregion
    }
}
