using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Data;

namespace HigLabo.DbSharp
{
    public class DatabaseFactory
    {
        private static readonly DatabaseFactory _Current = new DatabaseFactory();
        private Hashtable _CreateDatabaseMethodList = new ();

        public static DatabaseFactory Current
        {
            get { return _Current; }
        }

        public void SetCreateDatabaseMethod(String databaseKey, Func<Database> func)
        {
            _CreateDatabaseMethodList[databaseKey] = func;
        }
        public Database CreateDatabase(String databaseKey)
        {
            var f = _CreateDatabaseMethodList[databaseKey] as Func<Database>;

            if (f != null)
            {
                return f();
            }
            throw new InvalidOperationException("You must set up DatabaseFactory class."
            + "Please call SetCreateDatabaseMethod method of HigLabo.DbSharp.DatabaseFactory class." + Environment.NewLine
            + "DatabaseKey=" + databaseKey);
        }
    }
}
