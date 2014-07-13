using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlurayBackupManagement.Entities
{
    interface IWatchable
    {
        bool Watched
        {
            get;
        }
        void MarkAsWatched();
    }
}
