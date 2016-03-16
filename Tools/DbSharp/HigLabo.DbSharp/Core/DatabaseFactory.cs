using System;
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
        private Dictionary<String, Func<Database>> _CreateDatabaseMethodList = new Dictionary<string, Func<Database>>();

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
            Func<Database> func = null;

            if (_CreateDatabaseMethodList.TryGetValue(databaseKey, out func) == true)
            {
                return func();
            }
            throw new InvalidOperationException("You must set up DatabaseFactory class."
            + "Please call SetCreateDatabaseMethod method of HigLabo.DbSharp.DatabaseFactory class." + Environment.NewLine
            + "DatabaseKey=" + databaseKey);
        }
        public DatabaseContext CreateDatabaseContext(String databaseKey)
        {
            return new DatabaseContext(CreateDatabase(databaseKey));
        }
        public DatabaseContext CreateDatabaseContext(String databaseKey, String transactionKey)
        {
            return new DatabaseContext(CreateDatabase(databaseKey), transactionKey);
        }
    }
}
