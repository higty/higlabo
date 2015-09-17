using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HigLabo.Data
{
    public class MySqlScriptExecutedEventArgs : CommandExecutedEventArgs
    {
        public MySqlScript MySqlScript { get; private set; }
        public MySqlScriptExecutedEventArgs(String connectionString, DateTimeOffset startTime, DateTimeOffset endTime, Object executionContext, MySqlScript script)
            : base(MethodName.ExecuteCommand, connectionString, startTime, endTime, executionContext)
        {
            this.MySqlScript = script;
        }
    }
}
