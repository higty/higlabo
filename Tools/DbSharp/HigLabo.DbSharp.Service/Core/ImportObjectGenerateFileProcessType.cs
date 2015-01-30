using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.Service
{
    public enum ImportObjectGenerateFileProcessType
    {
        ImportTable,
        ImportStoredProcedure,
        ImportUserDefinedTable,
        DeleteObject,
        GenerateCSharpFile,
        GenerateDataConvertFile,
        Completed,
    }
}
