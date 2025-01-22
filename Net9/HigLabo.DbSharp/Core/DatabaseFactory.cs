using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Data;

namespace HigLabo.DbSharp;

public class DatabaseFactory
{
    private Hashtable _CreateDatabaseMethodList = new ();

    public void SetCreateDatabaseMethod(String databaseKey, Func<Database> func)
    {
        _CreateDatabaseMethodList[databaseKey] = func;
    }
    public virtual Database CreateDatabase(String databaseKey)
    {
        var f = _CreateDatabaseMethodList[databaseKey] as Func<Database>;

        if (f != null)
        {
            return f();
        }
        throw new InvalidOperationException("You must set up DatabaseFactory."
        + "Please call HigLabo.DbSharp..StoredProcedure.DatabaseFactory.SetCreateDatabaseMethod static method." + Environment.NewLine
        + "DatabaseKey=" + databaseKey);
    }
}
