using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HigLabo.Data
{
    public class MySqlScriptErrorEventArgs : CommandErrorEventArgs
    {
        public MySqlScript MySqlScript { get; private set; }
        public MySqlScriptErrorEventArgs(String connectionString, Exception exception, MySqlScript script)
            : base(MethodName.ExecuteCommand, connectionString, exception)
        {
            this.MySqlScript = script;
        }
    }
}
