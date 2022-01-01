//Generated at 2022/01/01 11:52:05 by DbSharpApplication.
//https://github.com/higty/higlabo/tree/master/Net6/Tools/DbSharp
using System;
using System.Data;
using System.Text;
using HigLabo.DbSharp;

namespace HigLabo.DbSharpSample.MySql
{
    public partial class identitytable
    {
        public interface IRecord
        {
            Int32 IntColumn { get; set; }
            DateTime TimestampColumn { get; set; }
            String NVarCharColumn { get; set; }
        }
    }
}
