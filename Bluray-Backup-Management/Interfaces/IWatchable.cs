using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluray_Backup_Management.Entities
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
