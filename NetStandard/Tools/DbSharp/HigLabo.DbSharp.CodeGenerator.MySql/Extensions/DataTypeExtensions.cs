using HigLabo.Core;
using HigLabo.DbSharp.MetaData;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public static class MySqlDbTypeExtensions
    {
        public static MySql.Data.MySqlClient.MySqlDbType GetMySqlDbType(this HigLabo.DbSharp.MetaData.MySqlDbType type)
        {
            return type.ToStringFromEnum().ToEnum<MySql.Data.MySqlClient.MySqlDbType>().Value;
        }
    }
}
