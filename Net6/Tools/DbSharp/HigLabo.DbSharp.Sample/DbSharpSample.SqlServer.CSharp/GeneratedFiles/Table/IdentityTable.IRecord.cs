//Generated at 2021/12/28 12:32:44 by DbSharpApplication.
//https://github.com/higty/higlabo/tree/master/Net6/Tools/DbSharp
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
