using HigLabo.Core;
using HigLabo.DbSharp.MetaData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public static class OracleDbTypeExtensions
    {
        public static Oracle.ManagedDataAccess.Client.OracleDbType GetOracleDbType(this HigLabo.DbSharp.MetaData.OracleDbType type)
        {
            return type.ToStringFromEnum().ToEnum<Oracle.ManagedDataAccess.Client.OracleDbType>().Value;
        }
    }
}
