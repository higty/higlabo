using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace HigLabo.Data
{
    public class ConnectionCreatedEventArgs : EventArgs
    {
        public DbConnection Connection { get; set; }
        public ConnectionCreatedEventArgs(DbConnection connection)
        {
            this.Connection = connection;
        }
    }
}
