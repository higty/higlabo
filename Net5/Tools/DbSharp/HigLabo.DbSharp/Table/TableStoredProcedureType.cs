using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public enum TableStoredProcedureType
    {
        Insert,
        Update,
        Delete,
    }
    public enum TableStoredProcedureTypeWithResultSet
    {
        SelectAll,
        SelectByPrimaryKey,
    }
}
