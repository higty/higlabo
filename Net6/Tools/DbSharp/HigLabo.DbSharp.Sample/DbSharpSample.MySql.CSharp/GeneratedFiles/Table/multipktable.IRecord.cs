//Generated at 2022/01/01 11:52:05 by DbSharpApplication.
//https://github.com/higty/higlabo/tree/master/Net6/Tools/DbSharp
using System;
using System.Data;
using System.Text;
using HigLabo.DbSharp;

namespace HigLabo.DbSharpSample.MySql
{
    public partial class multipktable
    {
        public interface IRecord
        {
            Int64 BigIntColumn { get; set; }
            Int32 IntColumn { get; set; }
            Single FloatColumn { get; set; }
            Byte[] BinaryColumn { get; set; }
            DateTime TimestampColumn { get; set; }
            Byte[] VarBinaryColumn { get; set; }
            Boolean? BitColumn { get; set; }
            String NCharColumn { get; set; }
            String NVarCharColumn { get; set; }
        }
    }
}
