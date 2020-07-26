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
    }

    public static class IDatabaseContextExtensions
    {
        public static Database GetDatabase(this IDatabaseContext context)
        {
            return DatabaseFactory.Current.CreateDatabase(context.DatabaseKey);
        }
    }
}
