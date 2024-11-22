using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp;

public abstract class StoredProcedureResultSet : DatabaseRecord
{
    protected StoredProcedure? _StoredProcedureResultSet_StoredProcedure = null;

    public StoredProcedure? GetStoredProcedure()
    {
        return _StoredProcedureResultSet_StoredProcedure;
    }
    public string GetStoredProcedureName()
    {
        var sp = this.GetStoredProcedure();
        if (sp == null) { return ""; }
        return sp.GetStoredProcedureName();
    }
}
