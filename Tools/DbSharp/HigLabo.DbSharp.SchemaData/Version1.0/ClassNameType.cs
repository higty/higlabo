using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.MetaData
{
    public enum ClassNameType
    {
        /// <summary>
        /// 
        /// </summary>
        Object,
        /// <summary>
        /// 
        /// </summary>
        Boolean,
        /// <summary>
        /// 
        /// </summary>
        String,
        /// <summary>
        /// 
        /// </summary>
        ByteArray,
        /// <summary>
        /// 
        /// </summary>
        SByte,
        /// <summary>
        /// 
        /// </summary>
        Int16,
        /// <summary>
        /// 
        /// </summary>
        Int32,
        /// <summary>
        /// 
        /// </summary>
        Int64,
        /// <summary>
        /// 
        /// </summary>
        Byte,
        /// <summary>
        /// 
        /// </summary>
        UInt16,
        /// <summary>
        /// 
        /// </summary>
        UInt32,
        /// <summary>
        /// 
        /// </summary>
        UInt64,
        /// <summary>
        /// 
        /// </summary>
        Single,
        /// <summary>
        /// 
        /// </summary>
        Double,
        /// <summary>
        /// 
        /// </summary>
        Decimal,
        /// <summary>
        /// 
        /// </summary>
        Guid,
        /// <summary>
        /// 
        /// </summary>
        TimeSpan,
        /// <summary>
        /// 
        /// </summary>
        DateTime,
        /// <summary>
        /// 
        /// </summary>
        DateTimeOffset,
        /// <summary>
        /// 
        /// </summary>
        UserDefinedTableType,
        /// <summary>
        /// 
        /// </summary>
        Geometry,
        /// <summary>
        /// 
        /// </summary>
        Geography,
        /// <summary>
        /// 
        /// </summary>
        HierarchyId,
        /// <summary>
        /// 
        /// </summary>
        MySqlGeometry,
    }
    /// <summary>
    /// 
    /// </summary>
    public static class ClassNameTypeExtensions
    {
        public static Type ToType(this ClassNameType classNameType)
        {
            switch (classNameType)
            {
                case ClassNameType.Object: return typeof(Object);
                case ClassNameType.Boolean: return typeof(Boolean);
                case ClassNameType.ByteArray: return typeof(Byte[]);
                case ClassNameType.String: return typeof(String);
                case ClassNameType.SByte: return typeof(SByte);
                case ClassNameType.Int16: return typeof(Int16);
                case ClassNameType.Int32: return typeof(Int32);
                case ClassNameType.Int64: return typeof(Int64);
                case ClassNameType.Byte: return typeof(Byte);
                case ClassNameType.UInt16: return typeof(UInt16);
                case ClassNameType.UInt32: return typeof(UInt32);
                case ClassNameType.UInt64: return typeof(UInt64);
                case ClassNameType.Single: return typeof(Single);
                case ClassNameType.Double: return typeof(Double);
                case ClassNameType.Decimal: return typeof(Decimal);
                case ClassNameType.Guid: return typeof(Guid);
                case ClassNameType.TimeSpan: return typeof(TimeSpan);
                case ClassNameType.DateTime: return typeof(DateTime);
                case ClassNameType.DateTimeOffset: return typeof(DateTimeOffset);
                case ClassNameType.MySqlGeometry: return Type.GetType("global::MySql.Data.Types.MySqlGeometry");
                case ClassNameType.Geometry: return Type.GetType("global::Microsoft.SqlServer.Types.SqlGeometry");
                case ClassNameType.Geography: return Type.GetType("global::Microsoft.SqlServer.Types.SqlGeography");
                case ClassNameType.HierarchyId: return Type.GetType("global::Microsoft.SqlServer.Types.SqlHierarchyId");
                default: throw new ArgumentException();
            }
        }
        public static string ToClassNameString(this ClassNameType classNameType)
        {
            switch (classNameType)
            {
                case ClassNameType.Object: return "Object";
                case ClassNameType.Boolean: return "Boolean";
                case ClassNameType.ByteArray: return "Byte[]";
                case ClassNameType.String: return "String";
                case ClassNameType.SByte: return "SByte";
                case ClassNameType.Int16: return "Int16";
                case ClassNameType.Int32: return "Int32";
                case ClassNameType.Int64: return "Int64";
                case ClassNameType.Byte: return "Byte";
                case ClassNameType.UInt16: return "UInt16";
                case ClassNameType.UInt32: return "UInt32";
                case ClassNameType.UInt64: return "UInt64";
                case ClassNameType.Single: return "Single";
                case ClassNameType.Double: return "Double";
                case ClassNameType.Decimal: return "Decimal";
                case ClassNameType.Guid: return "Guid";
                case ClassNameType.TimeSpan: return "TimeSpan";
                case ClassNameType.DateTime: return "DateTime";
                case ClassNameType.DateTimeOffset: return "DateTimeOffset";
                case ClassNameType.MySqlGeometry: return "global::MySql.Data.Types.MySqlGeometry";
                case ClassNameType.Geometry: return "global::Microsoft.SqlServer.Types.SqlGeometry";
                case ClassNameType.Geography: return "global::Microsoft.SqlServer.Types.SqlGeography";
                case ClassNameType.HierarchyId: return "global::Microsoft.SqlServer.Types.SqlHierarchyId";
                default: throw new ArgumentException();
            }
        }
        public static Boolean IsStructure(this ClassNameType classNameType)
        {
            switch (classNameType)
            {
                case ClassNameType.Object: return false;
                case ClassNameType.Boolean: return true;
                case ClassNameType.ByteArray: return false;
                case ClassNameType.String: return false;
                case ClassNameType.SByte: return true;
                case ClassNameType.Int16: return true;
                case ClassNameType.Int32: return true;
                case ClassNameType.Int64: return true;
                case ClassNameType.Byte: return true;
                case ClassNameType.UInt16: return true;
                case ClassNameType.UInt32: return true;
                case ClassNameType.UInt64: return true;
                case ClassNameType.Single: return true;
                case ClassNameType.Double: return true;
                case ClassNameType.Decimal: return true;
                case ClassNameType.Guid: return true;
                case ClassNameType.TimeSpan:return true;
                case ClassNameType.DateTime: return true;
                case ClassNameType.DateTimeOffset: return true;
                case ClassNameType.UserDefinedTableType: return false;
                case ClassNameType.MySqlGeometry: return true;
                case ClassNameType.Geometry: return false;
                case ClassNameType.Geography: return false;
                case ClassNameType.HierarchyId: return true;
                default: throw new ArgumentException();
            }
        }
    }
}
