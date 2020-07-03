using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HigLabo.Data
{
    public class MySqlScriptExecutingEventArgs : CommandExecutingEventArgs
    {
        public MySqlScript MySqlScript { get; private set; }
        public MySqlScriptExecutingEventArgs(String connectionString, MySqlScript script)
            : base(MethodName.ExecuteCommand, connectionString)
        {
            this.MySqlScript = script;
        }
    }
}
