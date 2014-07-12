using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlurayBackupManagement_WPF.Entities
{
    public class Movie
    {
        #region Properties
        private bool _watched;

        private string _name;
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        private BluerayDisk _disk;
        public BluerayDisk Disk
        {
            get { return _disk; }
            private set { _disk = value; }
        }
        #endregion

        #region Inteface Properties
        public bool Watched
        {
            get { return _watched; }
            private set { _watched = value; }
        }
        #endregion

        #region Methods
        public Movie(string name, bool watched,BluerayDisk disk)
        {
            _name = name;
            _watched = watched;
            _disk = disk;
        }
        #endregion

        #region Interface Methods
        public void MarkAsWatched()
        {
            _watched = true;
        }
        #endregion
    }
}
