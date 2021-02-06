using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core
{
    public enum SequentialGuidDatabase
    {
        SqlServer,
        Oracle,
        MySql,
        PostgreSql,
    }
    public static class SequentialGuidDatabaseExtensions
    {
        public static SequentialGuidType GetSequentialGuidType(this SequentialGuidDatabase database)
        {
            switch (database)
            {
                case SequentialGuidDatabase.SqlServer: return SequentialGuidType.AtEnd;
                case SequentialGuidDatabase.Oracle: return SequentialGuidType.Binary;
                case SequentialGuidDatabase.MySql: return SequentialGuidType.String;
                case SequentialGuidDatabase.PostgreSql: return SequentialGuidType.String;
                default: throw new InvalidOperationException();
            }
        }
    }
}
