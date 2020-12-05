using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.MetaData
{
    public enum StoredProcedureType
    {
        Custom,
        SelectAll,
        SelectByPrimaryKey,
        Insert,
        Update,
        Delete,
    }
}
