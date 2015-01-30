using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public static class DbParameterExtensions
    {
        public static void SetTypeName(this DbParameter parameter, String typeName)
        {
            {
                var p = parameter as SqlParameter;
                if (p != null)
                {
                    p.TypeName = typeName;
                }
            }
        }
        public static void SetUdtTypeName(this DbParameter parameter, String udtTypeName)
        {
            {
                var p = parameter as SqlParameter;
                if (p != null)
                {
                    p.UdtTypeName = udtTypeName;
                }
            }
        }
    }
}
