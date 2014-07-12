using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlurayBackupManagement.Entities
{
    public class Episode : IWatchable
    {
        #region Properties
        private bool _watched;

        private int _number;
        public int Number
        {
            get { return _number; }
            private set { _number = value; }
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
        public Episode(int number, bool watched,BluerayDisk disk)
        {
            _number = number;
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
