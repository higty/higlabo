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
        public MySqlScriptErrorEventArgs(String connectionString, Exception exception, Object executionContext, MySqlScript script)
            : base(MethodName.ExecuteCommand, connectionString, exception, executionContext)
        {
            this.MySqlScript = script;
        }
    }
}
