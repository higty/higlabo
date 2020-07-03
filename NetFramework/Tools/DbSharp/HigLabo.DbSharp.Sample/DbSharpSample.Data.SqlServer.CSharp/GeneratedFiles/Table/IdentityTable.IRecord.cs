using System;
using System.Data;
using System.Text;
using HigLabo.DbSharp;

namespace HigLabo.DbSharpSample.SqlServer
{
    public partial class IdentityTable
    {
        public interface IRecord
        {
            Int32 IntColumn { get; set; }
            String NVarCharColumn { get; set; }
        }
    }
}
