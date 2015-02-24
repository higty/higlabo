using System;
using System.Data;
using System.Text;
using HigLabo.DbSharp;

namespace HigLabo.DbSharpSample.SqlServer
{
    public partial class RowGuidColTable
    {
        public interface IRecord
        {
            Guid RowGuidColumn { get; set; }
            String NVarCharColumn { get; set; }
        }
    }
}
