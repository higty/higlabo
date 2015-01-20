using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HigLabo.Core
{
    public class TypeConverter
    {
        public NumberStyles IntergerNumberStyle { get; set; }
        public NumberStyles SingleNumberStyle { get; set; }
        public NumberStyles DoubleNumberStyle { get; set; }
        public NumberStyles DecimalNumberStyle { get; set; }
        public DateTimeStyles DateTimeStyle { get; set; }

        public TypeConverter()
        {
            this.IntergerNumberStyle = NumberStyles.Integer;

            this.SingleNumberStyle = NumberStyles.Float | NumberStyles.AllowThousands;
            this.DoubleNumberStyle = NumberStyles.Float | NumberStyles.AllowThousands;
            this.DecimalNumberStyle = NumberStyles.Float | NumberStyles.AllowThousands;
            this.DateTimeStyle = DateTimeStyles.AllowWhiteSpaces;
        }

        public virtual String ToString(Object value)
        {
            if (value == null) return null;
            return value.ToString();
        }
        public virtual Boolean? ToBoolean(Object value)
        {
            Boolean x;

            if (value == null) return null;
            var tp = value.GetType();
            if (tp == typeof(Boolean)) return (Boolean)value;
            if (tp == typeof(String) && Boolean.TryParse((String)value, out x))
            {
                return x;
            }
            return null;
        }
#if _Net_3_5
        public virtual Guid? ToGuid(Object value)
        {
            if (value == null) return null;

            var tp = value.GetType();
            if (tp == typeof(Guid)) return (Guid)value;
            if (tp == typeof(String))
            {
                try
                {
                    return new Guid((String)value);
                }
                catch { }
            }
            return null;
        }
#else
        public virtual Guid? ToGuid(Object value)
        {
            if (value == null) return null;

            Guid g;
            var tp = value.GetType();
            if (tp == typeof(Guid)) return (Guid)value;
            if (tp == typeof(String) && Guid.TryParse((String)value, out g))
            {
                return g;
            }
            return null;
        }
#endif
        public virtual SByte? ToSByte(Object value)
        {
            return ToSByte(value, this.IntergerNumberStyle, null);
        }
        public virtual SByte? ToSByte(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            SByte x;

            if (value == null) return null;
            var tp = value.GetType();
#if !NETFX_CORE && !PCL
            if (tp.IsValueType == true)
#endif
            {
                if (tp == typeof(SByte)) return (SByte)value;
                if (tp == typeof(Int16))
                {
                    var xx = (Int16)value;
                    if (SByte.MinValue <= xx && xx <= SByte.MaxValue)
                    {
                        return (SByte)xx;
                    }
                }
                if (tp == typeof(Int32))
                {
                    var xx = (Int32)value;
                    if (SByte.MinValue <= xx && xx <= SByte.MaxValue)
                    {
                        return (SByte)xx;
                    }
                }
                if (tp == typeof(Int64))
                {
                    var xx = (Int64)value;
                    if (SByte.MinValue <= xx && xx <= SByte.MaxValue)
                    {
                        return (SByte)xx;
                    }
                }
                if (tp == typeof(Byte))
                {
                    var xx = (Byte)value;
                    if (xx <= SByte.MaxValue)
                    {
                        return (SByte)xx;
                    }
                }
                if (tp == typeof(UInt16))
                {
                    var xx = (UInt16)value;
                    if (xx <= SByte.MaxValue)
                    {
                        return (SByte)xx;
                    }
                }
                if (tp == typeof(UInt32))
                {
                    var xx = (UInt32)value;
                    if (xx <= SByte.MaxValue)
                    {
                        return (SByte)xx;
                    }
                }
                if (tp == typeof(UInt64))
                {
                    var xx = (UInt64)value;
                    if (xx <= 127)//Operator long <= SByte.MaxValue does not defined
                    {
                        return (SByte)xx;
                    }
                }
            }
            if (tp == typeof(String) && SByte.TryParse((String)value, numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        public virtual Int16? ToInt16(Object value)
        {
            return ToInt16(value, this.IntergerNumberStyle, null);
        }
        public virtual Int16? ToInt16(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            Int16 x;

            if (value == null) return null;
            var tp = value.GetType();
#if !NETFX_CORE && !PCL
            if (tp.IsValueType == true)
#endif
            {
                if (tp == typeof(SByte)) return (Int16)(SByte)value;
                if (tp == typeof(Int16)) return (Int16)value;
                if (tp == typeof(Int32))
                {
                    var xx = (Int32)value;
                    if (Int16.MinValue <= xx && xx <= Int16.MaxValue)
                    {
                        return (Int16)xx;
                    }
                }
                if (tp == typeof(Int64))
                {
                    var xx = (Int64)value;
                    if (Int16.MinValue <= xx && xx <= Int16.MaxValue)
                    {
                        return (Int16)xx;
                    }
                }
                if (tp == typeof(Byte)) return (Int16)(Byte)value;
                if (tp == typeof(UInt16))
                {
                    var xx = (UInt16)value;
                    if (xx <= Int16.MaxValue)
                    {
                        return (Int16)xx;
                    }
                }
                if (tp == typeof(UInt32))
                {
                    var xx = (UInt32)value;
                    if (xx <= Int16.MaxValue)
                    {
                        return (Int16)xx;
                    }
                }
                if (tp == typeof(UInt64))
                {
                    var xx = (UInt64)value;
                    if (xx <= 32767)//Operator long <= Int16.MaxValue does not defined
                    {
                        return (Int16)xx;
                    }
                }
            }
            if (tp == typeof(String) && Int16.TryParse((String)value, numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        public virtual Int32? ToInt32(Object value)
        {
            return ToInt32(value, this.IntergerNumberStyle, null);
        }
        public virtual Int32? ToInt32(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            Int32 x;

            if (value == null) return null;
            var tp = value.GetType();
#if !NETFX_CORE && !PCL
            if (tp.IsValueType == true)
#endif
            {
                if (tp == typeof(SByte)) return (Int32)(SByte)value;
                if (tp == typeof(Int16)) return (Int32)(Int16)value;
                if (tp == typeof(Int32)) return (Int32)value;
                if (tp == typeof(Int64))
                {
                    var xx = (Int64)value;
                    if (Int32.MinValue <= xx && xx <= Int32.MaxValue)
                    {
                        return (Int32)xx;
                    }
                }
                if (tp == typeof(Byte)) return (Int32)(Byte)value;
                if (tp == typeof(UInt16)) return (Int32)(UInt16)value;
                if (tp == typeof(UInt32))
                {
                    var xx = (UInt32)value;
                    if (xx <= Int32.MaxValue)
                    {
                        return (Int32)xx;
                    }
                }
                if (tp == typeof(UInt64))
                {
                    var xx = (UInt64)value;
                    if (xx <= Int32.MaxValue)
                    {
                        return (Int32)xx;
                    }
                }
            }
            if (tp == typeof(String) && Int32.TryParse((String)value, numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        public virtual Int64? ToInt64(Object value)
        {
            return ToInt64(value, this.IntergerNumberStyle, null);
        }
        public virtual Int64? ToInt64(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            Int64 x;

            if (value == null) return null;
            var tp = value.GetType();
#if !NETFX_CORE && !PCL
            if (tp.IsValueType == true)
#endif
            {
                if (tp == typeof(SByte)) return (Int64)(SByte)value;
                if (tp == typeof(Int16)) return (Int64)(Int16)value;
                if (tp == typeof(Int32)) return (Int64)(Int32)value;
                if (tp == typeof(Int64)) return (Int64)value;
                if (tp == typeof(Byte)) return (Int64)(Byte)value;
                if (tp == typeof(UInt16)) return (Int64)(UInt16)value;
                if (tp == typeof(UInt32)) return (Int64)(UInt32)value;
                if (tp == typeof(UInt64))
                {
                    var xx = (UInt64)value;
                    if (xx <= Int64.MaxValue)
                    {
                        return (Int64)xx;
                    }
                }
            }
            if (tp == typeof(String) && Int64.TryParse((String)value, numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        public virtual Byte? ToByte(Object value)
        {
            return ToByte(value, this.IntergerNumberStyle, null);
        }
        public virtual Byte? ToByte(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            Byte x;

            if (value == null) return null;
            var tp = value.GetType();
#if !NETFX_CORE && !PCL
            if (tp.IsValueType == true)
#endif
            {
                if (tp == typeof(SByte))
                {
                    var xx = (SByte)value;
                    if (Byte.MinValue <= xx)
                    {
                        return (Byte)xx;
                    }
                }
                if (tp == typeof(Int16))
                {
                    var xx = (Int16)value;
                    if (Byte.MinValue <= xx && xx <= Byte.MaxValue)
                    {
                        return (Byte)xx;
                    }
                }
                if (tp == typeof(Int32))
                {
                    var xx = (Int32)value;
                    if (Byte.MinValue <= xx && xx <= Byte.MaxValue)
                    {
                        return (Byte)xx;
                    }
                }
                if (tp == typeof(Int64))
                {
                    var xx = (Int64)value;
                    if (Byte.MinValue <= xx && xx <= Byte.MaxValue)
                    {
                        return (Byte)xx;
                    }
                }
                if (tp == typeof(Byte)) return (Byte)value;
                if (tp == typeof(UInt16))
                {
                    var xx = (UInt16)value;
                    if (Byte.MinValue <= xx && xx <= Byte.MaxValue)
                    {
                        return (Byte)xx;
                    }
                }
                if (tp == typeof(UInt32))
                {
                    var xx = (UInt32)value;
                    if (Byte.MinValue <= xx && xx <= Byte.MaxValue)
                    {
                        return (Byte)xx;
                    }
                }
                if (tp == typeof(UInt64))
                {
                    var xx = (UInt64)value;
                    if (Byte.MinValue <= xx && xx <= Byte.MaxValue)
                    {
                        return (Byte)xx;
                    }
                }
            }
            if (tp == typeof(String) && Byte.TryParse((String)value, numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        public virtual UInt16? ToUInt16(Object value)
        {
            return ToUInt16(value, this.IntergerNumberStyle, null);
        }
        public virtual UInt16? ToUInt16(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            UInt16 x;

            if (value == null) return null;
            var tp = value.GetType();
#if !NETFX_CORE && !PCL
            if (tp.IsValueType == true)
#endif
            {
                if (tp == typeof(SByte))
                {
                    var xx = (SByte)value;
                    if (UInt16.MinValue <= xx)
                    {
                        return (UInt16)xx;
                    }
                }
                if (tp == typeof(Int16))
                {
                    var xx = (Int16)value;
                    if (UInt16.MinValue <= xx)
                    {
                        return (UInt16)xx;
                    }
                }
                if (tp == typeof(Int32))
                {
                    var xx = (Int32)value;
                    if (UInt16.MinValue <= xx && xx <= UInt16.MaxValue)
                    {
                        return (UInt16)xx;
                    }
                }
                if (tp == typeof(Int64))
                {
                    var xx = (Int64)value;
                    if (UInt16.MinValue <= xx && xx <= UInt16.MaxValue)
                    {
                        return (UInt16)xx;
                    }
                }
                if (tp == typeof(Byte)) return (UInt16)(Byte)value;
                if (tp == typeof(UInt16)) return (UInt16)value;
                if (tp == typeof(UInt32))
                {
                    var xx = (UInt32)value;
                    if (UInt16.MinValue <= xx && xx <= UInt16.MaxValue)
                    {
                        return (UInt16)xx;
                    }
                }
                if (tp == typeof(UInt64))
                {
                    var xx = (UInt64)value;
                    if (UInt16.MinValue <= xx && xx <= UInt16.MaxValue)
                    {
                        return (UInt16)xx;
                    }
                }
            }
            if (tp == typeof(String) && UInt16.TryParse((String)value, numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        public virtual UInt32? ToUInt32(Object value)
        {
            return ToUInt32(value, this.IntergerNumberStyle, null);
        }
        public virtual UInt32? ToUInt32(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            UInt32 x;

            if (value == null) return null;
            var tp = value.GetType();
#if !NETFX_CORE && !PCL
            if (tp.IsValueType == true)
#endif
            {
                if (tp == typeof(SByte))
                {
                    var xx = (SByte)value;
                    if (UInt32.MinValue <= xx)
                    {
                        return (UInt32)xx;
                    }
                }
                if (tp == typeof(Int16))
                {
                    var xx = (Int16)value;
                    if (UInt32.MinValue <= xx)
                    {
                        return (UInt32)xx;
                    }
                }
                if (tp == typeof(Int32))
                {
                    var xx = (Int32)value;
                    if (UInt32.MinValue <= xx)
                    {
                        return (UInt32)xx;
                    }
                }
                if (tp == typeof(Int64))
                {
                    var xx = (Int64)value;
                    if (UInt32.MinValue <= xx && xx <= UInt32.MaxValue)
                    {
                        return (UInt32)xx;
                    }
                }
                if (tp == typeof(Byte)) return (UInt32)(Byte)value;
                if (tp == typeof(UInt16)) return (UInt32)(UInt16)value;
                if (tp == typeof(UInt32)) return (UInt32)value;
                if (tp == typeof(UInt64))
                {
                    var xx = (UInt64)value;
                    if (UInt32.MinValue <= xx && xx <= UInt32.MaxValue)
                    {
                        return (UInt32)xx;
                    }
                }
            }
            if (tp == typeof(String) && UInt32.TryParse((String)value, numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        public virtual UInt64? ToUInt64(Object value)
        {
            return ToUInt64(value, this.IntergerNumberStyle, null);
        }
        public virtual UInt64? ToUInt64(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            UInt64 x;

            if (value == null) return null;
            var tp = value.GetType();
#if !NETFX_CORE && !PCL
            if (tp.IsValueType == true)
#endif
            {
                if (tp == typeof(SByte))
                {
                    var xx = (SByte)value;
                    if (xx >= 0)
                    {
                        return (UInt64)xx;
                    }
                }
                if (tp == typeof(Int16))
                {
                    var xx = (Int16)value;
                    if (xx >= 0)
                    {
                        return (UInt64)xx;
                    }
                }
                if (tp == typeof(Int32))
                {
                    var xx = (Int32)value;
                    if (xx >= 0)
                    {
                        return (UInt64)xx;
                    }
                }
                if (tp == typeof(Int64))
                {
                    var xx = (Int64)value;
                    if (xx >= 0)
                    {
                        return (UInt64)xx;
                    }
                }
                if (tp == typeof(Byte)) return (UInt64)(Byte)value;
                if (tp == typeof(UInt16)) return (UInt64)(UInt16)value;
                if (tp == typeof(UInt32)) return (UInt64)(UInt32)value;
                if (tp == typeof(UInt64)) return (UInt64)value;
            }
            if (tp == typeof(String) && UInt64.TryParse((String)value, numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        public virtual Single? ToSingle(Object value)
        {
            return ToSingle(value, this.SingleNumberStyle, null);
        }
        public virtual Single? ToSingle(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            Single x;

            if (value == null) return null;
            var tp = value.GetType();
#if !NETFX_CORE && !PCL
            if (tp.IsValueType == true)
#endif
            {
                if (tp == typeof(Single)) return (Single)value;
                if (tp == typeof(SByte)) return (Single)(SByte)value;
                if (tp == typeof(Int16)) return (Single)(Int16)value;
                if (tp == typeof(Int32)) return (Single)(Int32)value;
                if (tp == typeof(Int64)) return (Single)(Int64)value;
                if (tp == typeof(Byte)) return (Single)(Byte)value;
                if (tp == typeof(UInt16)) return (Single)(UInt16)value;
                if (tp == typeof(UInt32)) return (Single)(UInt32)value;
                if (tp == typeof(UInt64)) return (Single)(UInt64)value;
                if (tp == typeof(Double) && Single.TryParse(((Double)value).ToString("G99"), numberStyle, formatProvider, out x))
                {
                    return x;
                }
                if (tp == typeof(Decimal) && Single.TryParse(((Decimal)value).ToString("G99"), numberStyle, formatProvider, out x))
                {
                    return x;
                }
            }
            if (tp == typeof(String) && Single.TryParse((String)value, numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        public virtual Double? ToDouble(Object value)
        {
            return ToDouble(value, this.DoubleNumberStyle, null);
        }
        public virtual Double? ToDouble(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            Double x;

            if (value == null) return null;
            var tp = value.GetType();
#if !NETFX_CORE && !PCL
            if (tp.IsValueType == true)
#endif
            {
                if (tp == typeof(Double)) return (Double)value;
                if (tp == typeof(SByte)) return (Double)(SByte)value;
                if (tp == typeof(Int16)) return (Double)(Int16)value;
                if (tp == typeof(Int32)) return (Double)(Int32)value;
                if (tp == typeof(Int64)) return (Double)(Int64)value;
                if (tp == typeof(Byte)) return (Double)(Byte)value;
                if (tp == typeof(UInt16)) return (Double)(UInt16)value;
                if (tp == typeof(UInt32)) return (Double)(UInt32)value;
                if (tp == typeof(UInt64)) return (Double)(UInt64)value;
                if (tp == typeof(Single) && Double.TryParse(((Single)value).ToString("G99"), numberStyle, formatProvider, out x))
                {
                    return x;
                }
                if (tp == typeof(Decimal) && Double.TryParse(((Decimal)value).ToString("G99"), numberStyle, formatProvider, out x))
                {
                    return x;
                }
            }
            if (tp == typeof(String) && Double.TryParse((String)value, numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        public virtual Decimal? ToDecimal(Object value)
        {
            return ToDecimal(value, this.DecimalNumberStyle, null);
        }
        public virtual Decimal? ToDecimal(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            Decimal x;

            if (value == null) return null;
            var tp = value.GetType();
#if !NETFX_CORE && !PCL
            if (tp.IsValueType == true)
#endif
            {
                if (tp == typeof(Decimal)) return (Decimal)value;
                if (tp == typeof(SByte)) return (Decimal)(SByte)value;
                if (tp == typeof(Int16)) return (Decimal)(Int16)value;
                if (tp == typeof(Int32)) return (Decimal)(Int32)value;
                if (tp == typeof(Int64)) return (Decimal)(Int64)value;
                if (tp == typeof(Byte)) return (Decimal)(Byte)value;
                if (tp == typeof(UInt16)) return (Decimal)(UInt16)value;
                if (tp == typeof(UInt32)) return (Decimal)(UInt32)value;
                if (tp == typeof(UInt64)) return (Decimal)(UInt64)value;
                if (tp == typeof(Single) && Decimal.TryParse(((Single)value).ToString("G99"), numberStyle, formatProvider, out x))
                {
                    return x;
                }
                if (tp == typeof(Double) && Decimal.TryParse(((Double)value).ToString("G99"), numberStyle, formatProvider, out x))
                {
                    return x;
                }
            }
            if (tp == typeof(String) && Decimal.TryParse((String)value, numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        public virtual TimeSpan? ToTimeSpan(Object value)
        {
            TimeSpan x;

            if (value == null) return null;
            var tp = value.GetType();
            if (tp == typeof(TimeSpan)) return (TimeSpan)value;
            if (tp == typeof(String) && TimeSpan.TryParse((String)value, out x))
            {
                return x;
            }
            return null;
        }
        public virtual DateTime? ToDateTime(Object value)
        {
            return ToDateTime(value, this.DateTimeStyle, null);
        }
        public virtual DateTime? ToDateTime(Object value, DateTimeStyles dateTimeStyle, IFormatProvider formatProvider)
        {
            DateTime x;

            if (value == null) return null;
            var tp = value.GetType();
            if (tp == typeof(DateTime)) return (DateTime)value;
            if (tp == typeof(String) && DateTime.TryParse((String)value, formatProvider, dateTimeStyle, out x))
            {
                return x;
            }
            return null;
        }
        public virtual DateTime? ToDateTimeExact(Object value)
        {
            return ToDateTimeExact(value, this.DateTimeStyle, null, null);
        }
        public virtual DateTime? ToDateTimeExact(Object value, DateTimeStyles dateTimeStyle, IFormatProvider formatProvider, String[] format)
        {
            DateTime x;

            if (value == null) return null;
            var tp = value.GetType();
            if (tp == typeof(DateTime)) return (DateTime)value;
            if (tp == typeof(String) && DateTime.TryParseExact((String)value, format, formatProvider, dateTimeStyle, out x))
            {
                return x;
            }
            return null;
        }
        public virtual DateTimeOffset? ToDateTimeOffset(Object value)
        {
            return ToDateTimeOffset(value, this.DateTimeStyle, null);
        }
        public virtual DateTimeOffset? ToDateTimeOffset(Object value, DateTimeStyles dateTimeStyle, IFormatProvider formatProvider)
        {
            DateTimeOffset x;

            if (value == null) return null;
            var tp = value.GetType();
            if (tp == typeof(DateTimeOffset)) return (DateTimeOffset)value;
            if (tp == typeof(String) && DateTimeOffset.TryParse((String)value, formatProvider, dateTimeStyle, out x))
            {
                return x;
            }
            return null;
        }
        public virtual DateTimeOffset? ToDateTimeOffsetExact(Object value)
        {
            return ToDateTimeOffsetExact(value, this.DateTimeStyle, null, null);
        }
        public virtual DateTimeOffset? ToDateTimeOffsetExact(Object value, DateTimeStyles dateTimeStyle, IFormatProvider formatProvider, String[] format)
        {
            DateTimeOffset x;

            if (value == null) return null;
            var tp = value.GetType();
            if (tp == typeof(DateTimeOffset)) return (DateTimeOffset)value;
            if (tp == typeof(String) && DateTimeOffset.TryParseExact((String)value, format, formatProvider, dateTimeStyle, out x))
            {
                return x;
            }
            return null;
        }
        public virtual T? ToEnum<T>(Object value) where T : struct
        {
            return ToEnum<T>(value, true);
        }
#if _Net_3_5
        public virtual T? ToEnum<T>(Object value, Boolean ignoreCase) where T : struct
        {
            if (value == null) return null;
            var tp = value.GetType();
            if (tp == typeof(T)) return (T)value;
            if (tp == typeof(String))
            {
                try
                {
                    return (T)Enum.Parse(typeof(T), (String)value, ignoreCase);
                }
                catch { }
            }
            return null;
        }
#elif NETFX_CORE || Pcl
        public virtual T? ToEnum<T>(Object value, Boolean ignoreCase) where T : struct
        {
            if (value == null) return null;
            var tp = value.GetType();
            T result;
            if (tp == typeof(T)) return (T)value;
            if (tp == typeof(String) && Enum.TryParse((String)value, ignoreCase, out result))
            {
                return result;
            }
            return null;
        }
#else
        public virtual T? ToEnum<T>(Object value, Boolean ignoreCase) where T : struct
        {
            if (value == null) return null;
            var TP = typeof(T);
            if (TP.IsEnum == false) throw new ArgumentException("T must be Enum type");
            T result;
            var tp = value.GetType();
            if (tp == TP) return (T)value;
            if (tp == typeof(String) && Enum.TryParse((String)value, ignoreCase, out result))
            {
                return result;
            }
            if (tp.IsValueType == true)
            {
                var enumUnderlyingType = TP.GetEnumUnderlyingType();
                if (enumUnderlyingType == typeof(SByte) && (tp == typeof(SByte))) return (T)value;
                if (enumUnderlyingType == typeof(Int16) && (tp == typeof(SByte) || tp == typeof(Int16))) return (T)value;
                if (enumUnderlyingType == typeof(Int32) && (tp == typeof(SByte) || tp == typeof(Int16) || tp == typeof(Int32))) return (T)value;
                if (enumUnderlyingType == typeof(Int64) && (tp == typeof(SByte) || tp == typeof(Int16) || tp == typeof(Int32) || tp == typeof(Int64))) return (T)value;
                if (enumUnderlyingType == typeof(Byte) && (tp == typeof(Byte))) return (T)value;
                if (enumUnderlyingType == typeof(UInt16) && (tp == typeof(Byte) || tp == typeof(UInt16))) return (T)value;
                if (enumUnderlyingType == typeof(UInt32) && (tp == typeof(Byte) || tp == typeof(UInt16) || tp == typeof(UInt32))) return (T)value;
                if (enumUnderlyingType == typeof(UInt64) && (tp == typeof(Byte) || tp == typeof(UInt16) || tp == typeof(UInt32) || tp == typeof(UInt64))) return (T)value;
            }
            return null;
        }
#endif
    }
}
