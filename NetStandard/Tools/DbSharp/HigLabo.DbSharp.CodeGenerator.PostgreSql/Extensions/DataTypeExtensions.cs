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
    public static class NpgsqlDbTypeExtensions
    {
        public static NpgsqlTypes.NpgsqlDbType GetNpgsqlDbType(this HigLabo.DbSharp.MetaData.NpgsqlDbType type)
        {
            return type.ToStringFromEnum().ToEnum<NpgsqlTypes.NpgsqlDbType>().Value;
        }
    }
}
