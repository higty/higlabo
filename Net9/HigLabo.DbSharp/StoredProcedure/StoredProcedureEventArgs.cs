using HigLabo.Data;
using System.Data;

namespace HigLabo.DbSharp;
public class StoredProcedureEventArgs : EventArgs
{
    public Database Database { get; set; }
    public IDbCommand Command { get; set; }

    public StoredProcedureEventArgs(Database database, IDbCommand command)
    {
        Database = database;
        Command = command;
    }
}
