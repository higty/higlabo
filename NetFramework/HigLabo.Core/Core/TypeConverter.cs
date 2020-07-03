using System;
using System.Globalization;
using System.Text;

namespace HigLabo.Core
{
    public partial class TypeConverter
    {
        public NumberStyles IntergerNumberStyle { get; set; }
        public NumberStyles SingleNumberStyle { get; set; }
        public NumberStyles DoubleNumberStyle { get; set; }
        public NumberStyles DecimalNumberStyle { get; set; }
        public DateTimeStyles DateTimeStyle { get; set; }
        public StringConverter StringConverter { get; set; }

        public TypeConverter()
        {
            this.IntergerNumberStyle = NumberStyles.Integer;

            this.SingleNumberStyle = NumberStyles.Float | NumberStyles.AllowThousands;
            this.DoubleNumberStyle = NumberStyles.Float | NumberStyles.AllowThousands;
            this.DecimalNumberStyle = NumberStyles.Float | NumberStyles.AllowThousands;
            this.DateTimeStyle = DateTimeStyles.AllowWhiteSpaces;

            this.StringConverter = new StringConverter();
            this.StringConverter.FullWidthAlphabet = true;
            this.StringConverter.FullWidthNumber = true;
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
            if (tp == typeof (String))
            {
                var s = (String)value;
                if (s != null)
                {
                    try
                    {
                        s = s.Replace("_", "/").Replace("-", "+");
                        byte[] buffer = Convert.FromBase64String(s + "==");
                        return new Guid(buffer);
                    }
                    catch { }
                }
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
            if (tp == typeof(String) && SByte.TryParse(this.ConvertFromFullWidthToHalfWidth((String)value), numberStyle, formatProvider, out x))
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
            if (tp == typeof(String) && Int16.TryParse(this.ConvertFromFullWidthToHalfWidth((String)value), numberStyle, formatProvider, out x))
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
            if (tp == typeof(String) && Int32.TryParse(this.ConvertFromFullWidthToHalfWidth((String)value), numberStyle, formatProvider, out x))
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
            if (tp == typeof(String) && Int64.TryParse(this.ConvertFromFullWidthToHalfWidth((String)value), numberStyle, formatProvider, out x))
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
            if (tp == typeof(String) && Byte.TryParse(this.ConvertFromFullWidthToHalfWidth((String)value), numberStyle, formatProvider, out x))
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
            if (tp == typeof(String) && UInt16.TryParse(this.ConvertFromFullWidthToHalfWidth((String)value), numberStyle, formatProvider, out x))
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
            if (tp == typeof(String) && UInt32.TryParse(this.ConvertFromFullWidthToHalfWidth((String)value), numberStyle, formatProvider, out x))
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
            if (tp == typeof(String) && UInt64.TryParse(this.ConvertFromFullWidthToHalfWidth((String)value), numberStyle, formatProvider, out x))
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
            if (tp == typeof(String) && Single.TryParse(this.ConvertFromFullWidthToHalfWidth((String)value), numberStyle, formatProvider, out x))
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
            if (tp == typeof(String) && Double.TryParse(this.ConvertFromFullWidthToHalfWidth((String)value), numberStyle, formatProvider, out x))
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
            if (tp == typeof(String) && Decimal.TryParse(this.ConvertFromFullWidthToHalfWidth((String)value), numberStyle, formatProvider, out x))
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
            if (tp == typeof(String) && TimeSpan.TryParse(this.ConvertFromFullWidthToHalfWidth((String)value), out x))
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
            if (tp == typeof(String) && 
                DateTime.TryParse(this.ConvertFromFullWidthToHalfWidth((String)value), formatProvider, dateTimeStyle, out x))
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
            if (tp == typeof(String) && DateTime.TryParseExact(this.ConvertFromFullWidthToHalfWidth((String)value), format, formatProvider, dateTimeStyle, out x))
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
            if (tp == typeof(String))
            {
                if (DateTimeOffset.TryParse(this.ConvertFromFullWidthToHalfWidth((String)value), formatProvider, dateTimeStyle, out x))
                {
                    return x;
                }
                else
                {
                    var xx = ToDateTimeOffsetWithTimeZone(this.ConvertFromFullWidthToHalfWidth((String)value));
                    if (xx.HasValue) { return xx; }
                }
            }
            return ToDateTime(value);
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
            if (tp == typeof(String) && DateTimeOffset.TryParseExact(this.ConvertFromFullWidthToHalfWidth((String)value), format, formatProvider, dateTimeStyle, out x))
            {
                return x;
            }
            return null;
        }
        private DateTimeOffset? ToDateTimeOffsetWithTimeZone(String value)
        {
            DateTimeOffset dtime = DateTimeOffset.Now;
            TimeSpan ts = TimeSpan.Zero;

            //Tue, 25 Oct 2011 20:44:24
            if (DateTimeOffset.TryParse(value, out dtime) == true) { return dtime; }

            var firstColonIndex = value.IndexOf(":", StringComparison.OrdinalIgnoreCase);
            if (firstColonIndex == -1) { return null; }
            var timezoneStartIndex = value.IndexOf(" ", firstColonIndex, StringComparison.OrdinalIgnoreCase);
            if (timezoneStartIndex == -1) { return null; }
            var dateTimePart = value.Substring(0, timezoneStartIndex);//Tue, 25 Oct 2011 20:44:24
            if (DateTimeOffset.TryParse(dateTimePart, out dtime) == false) { return null; }
            //(CST) or CST or +0600 (Three letter military timezone)
            var timeZonePart = value.Substring(timezoneStartIndex + 1).Trim();//+0600 or GMT (Three letter military timezone)

            //Thu, 10 Apr 2014 04:27:37 +0000 (GMT+00:00)
            var timezoneEndIndex = timeZonePart.IndexOf(" ", StringComparison.OrdinalIgnoreCase);
            if (timezoneEndIndex != -1)
                timeZonePart = timeZonePart.Substring(0, timezoneEndIndex);

            if (timeZonePart[0] == '+' || timeZonePart[0] == '-')
            {
                if (timeZonePart.Length < 5) { throw new FormatException(); }
                var hour = Convert.ToInt32(timeZonePart.Substring(1, 2));
                var minute = Convert.ToInt32(timeZonePart.Substring(3, 2));
                if (timeZonePart[0] == '-')
                {
                    hour = -hour;
                    minute = -minute;
                }
                return new DateTimeOffset(dtime.DateTime, new TimeSpan(hour, minute, 0));
            }
            if (timeZonePart[0] == '(')
            {
                timeZonePart = timeZonePart.TrimStart('(');
                timeZonePart = timeZonePart.TrimEnd(')');
            }
            switch (timeZonePart)
            {
                case "A": ts = new TimeSpan(1, 0, 0); break;
                case "B": ts = new TimeSpan(2, 0, 0); break;
                case "C": ts = new TimeSpan(3, 0, 0); break;
                case "D": ts = new TimeSpan(4, 0, 0); break;
                case "E": ts = new TimeSpan(5, 0, 0); break;
                case "F": ts = new TimeSpan(6, 0, 0); break;
                case "G": ts = new TimeSpan(7, 0, 0); break;
                case "H": ts = new TimeSpan(8, 0, 0); break;
                case "I": ts = new TimeSpan(9, 0, 0); break;
                case "K": ts = new TimeSpan(10, 0, 0); break;
                case "L": ts = new TimeSpan(11, 0, 0); break;
                case "M": ts = new TimeSpan(12, 0, 0); break;
                case "N": ts = new TimeSpan(-1, 0, 0); break;
                case "O": ts = new TimeSpan(-2, 0, 0); break;
                case "P": ts = new TimeSpan(-3, 0, 0); break;
                case "Q": ts = new TimeSpan(-4, 0, 0); break;
                case "R": ts = new TimeSpan(-5, 0, 0); break;
                case "S": ts = new TimeSpan(-6, 0, 0); break;
                case "T": ts = new TimeSpan(-7, 0, 0); break;
                case "U": ts = new TimeSpan(-8, 0, 0); break;
                case "V": ts = new TimeSpan(-9, 0, 0); break;
                case "W": ts = new TimeSpan(-10, 0, 0); break;
                case "X": ts = new TimeSpan(-11, 0, 0); break;
                case "Y": ts = new TimeSpan(-12, 0, 0); break;
                case "Z":
                case "UT":
                case "GMT": break;    // It's UTC
                case "EST": ts = new TimeSpan(5, 0, 0); break;
                case "EDT": ts = new TimeSpan(4, 0, 0); break;
                case "CST": ts = new TimeSpan(6, 0, 0); break;
                case "CDT": ts = new TimeSpan(5, 0, 0); break;
                case "MST": ts = new TimeSpan(7, 0, 0); break;
                case "MDT": ts = new TimeSpan(6, 0, 0); break;
                case "PST": ts = new TimeSpan(8, 0, 0); break;
                case "PDT": ts = new TimeSpan(7, 0, 0); break;
                case "JST": ts = new TimeSpan(9, 0, 0); break;
                default: return null;
            }
            return new DateTimeOffset(dtime.DateTime, ts);
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

#if !NETFX_CORE && !Pcl && !_Net_3_5
        public virtual Object ToEnum(Object value, Type type, StringComparison comparison)
        {
            if (value == null) return null;
            var TP = type;
            if (TP.IsEnum == false) throw new ArgumentException("T must be Enum type");
            var tp = value.GetType();
            if (tp == TP) return value;
            if (tp == typeof(String))
            {
                var s = (String)value;
                return s.ToEnum(type, comparison);
            }
            if (tp.IsValueType == true)
            {
                var enumUnderlyingType = TP.GetEnumUnderlyingType();
                if (enumUnderlyingType == typeof(SByte) && (tp == typeof(SByte))) return Enum.ToObject(type, value);
                if (enumUnderlyingType == typeof(Int16) && (tp == typeof(SByte) || tp == typeof(Int16))) return Enum.ToObject(type, value);
                if (enumUnderlyingType == typeof(Int32) && (tp == typeof(SByte) || tp == typeof(Int16) || tp == typeof(Int32))) return Enum.ToObject(type, value);
                if (enumUnderlyingType == typeof(Int64) && (tp == typeof(SByte) || tp == typeof(Int16) || tp == typeof(Int32) || tp == typeof(Int64))) return Enum.ToObject(type, value);
                if (enumUnderlyingType == typeof(Byte) && (tp == typeof(Byte))) return Enum.ToObject(type, value);
                if (enumUnderlyingType == typeof(UInt16) && (tp == typeof(Byte) || tp == typeof(UInt16))) return Enum.ToObject(type, value);
                if (enumUnderlyingType == typeof(UInt32) && (tp == typeof(Byte) || tp == typeof(UInt16) || tp == typeof(UInt32))) return Enum.ToObject(type, value);
                if (enumUnderlyingType == typeof(UInt64) && (tp == typeof(Byte) || tp == typeof(UInt16) || tp == typeof(UInt32) || tp == typeof(UInt64))) return Enum.ToObject(type, value);
            }
            return null;
        }
        public virtual Object Cast(Object value, Type type)
        {
            return Cast(value, type, StringComparison.OrdinalIgnoreCase);
        }
        public virtual Object Cast(Object value, Type type, StringComparison comparison)
        {
            var tp = type;
            Object o = null;

            if (tp == typeof(String)) { o = (String)value; }
            else if (tp == typeof(Boolean) || tp == typeof(Boolean?)) { o = this.ToBoolean(value); }
            else if (tp == typeof(Guid) || tp == typeof(Guid?)) { o = this.ToGuid(value); }
            else if (tp == typeof(Int16) || tp == typeof(Int16?)) { o = this.ToInt16(value); }
            else if (tp == typeof(Int32) || tp == typeof(Int32?)) { o = this.ToInt32(value); }
            else if (tp == typeof(Int64) || tp == typeof(Int64?)) { o = this.ToInt64(value); }
            else if (tp == typeof(UInt16) || tp == typeof(UInt16?)) { o = this.ToUInt16(value); }
            else if (tp == typeof(UInt32) || tp == typeof(UInt32?)) { o = this.ToUInt32(value); }
            else if (tp == typeof(UInt64) || tp == typeof(UInt64?)) { o = this.ToUInt64(value); }
            else if (tp == typeof(Byte) || tp == typeof(Byte?)) { o = this.ToByte(value); }
            else if (tp == typeof(SByte) || tp == typeof(SByte?)) { o = this.ToSByte(value); }
            else if (tp == typeof(Single) || tp == typeof(Single?)) { o = this.ToSingle(value); }
            else if (tp == typeof(Double) || tp == typeof(Double?)) { o = this.ToDouble(value); }
            else if (tp == typeof(Decimal) || tp == typeof(Decimal?)) { o = this.ToDecimal(value); }
            else if (tp == typeof(DateTime) || tp == typeof(DateTime?)) { o = this.ToDateTime(value); }
            else if (tp == typeof(DateTimeOffset) || tp == typeof(DateTimeOffset?)) { o = this.ToDateTimeOffset(value); }
            else if (tp.IsEnum) { o = this.ToEnum(value, tp, comparison); }
            else if (tp.IsPrimitive || tp.IsValueType)
            {
                try
                {
                    o = Convert.ChangeType(value, tp);
                }
                catch { }
            }
            return o;
        }
#endif
        public virtual Encoding ToEncoding(Object value)
        {
            try
            {
                var s = value as String;
                if (s != null)
                {
                    return Encoding.GetEncoding(s);
                }
            }
            catch
            {
            }
#if !Pcl
            try
            {
                if (value is Int32)
                {
                    return Encoding.GetEncoding((Int32)value);
                }
            }
            catch
            {
            }
#endif
            return null;
        }
        public String ConvertFromFullWidthToHalfWidth(String value)
        {
            if (this.StringConverter == null) { return value; }
            return this.StringConverter.ToHalfWidth(value);
        }
    }
}
