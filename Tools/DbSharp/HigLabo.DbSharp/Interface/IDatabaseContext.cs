using HigLabo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public interface IDatabaseContext
    {
        String DatabaseKey { get; set; }
        String TransactionKey { get; set; }
    }

    public static class IDatabaseContextExtensions
    {
        public static Database GetDatabase(this IDatabaseContext context)
        {
            Database db = null;
            var dc = DatabaseContext.GetDatabaseContext(context.TransactionKey);
            if (dc == null)
            {
                if (context.TransactionKey == "")
                {
                    db = DatabaseFactory.Current.CreateDatabase(context.DatabaseKey);
                }
                else
                {
                    throw new TransactionKeyNotFoundException();
                }
            }
            else
            {
                return dc.Database;
            }
            return db;
        }
    }
}
