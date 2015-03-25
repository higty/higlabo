using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core
{
    public static class StringExtensions
    {
        public static String UnifyLineFeed(this String text)
        {
            var nextChar = '\0';
            var sb = new StringBuilder(text.Length);

            for (var i = 0; i < text.Length; i++)
            {
                if (i < text.Length - 1)
                {
                    nextChar = text[i + 1];
                }
                if (text[i] == '\r')
                {
                    sb.Append("\r\n");
                    if (nextChar == '\n')
                    {
                        i++;
                    }
                }
                else if (text[i] == '\n')
                {
                    sb.Append("\r\n");
                }
                else
                {
                    sb.Append(text[i]);
                }
            }
            return sb.ToString();
        }
        public static String ExtractString(this String text, Char? startSeparator, Char? endSeparator)
        {
            var startIndex = 0;
            if (startSeparator.HasValue == true)
            {
                startIndex = text.IndexOf(startSeparator.Value) + 1;
            }
            if (startIndex < 0)
            {
                startIndex = 0;
            }
            if (endSeparator.HasValue == true)
            {
                var endIndex = text.IndexOf(endSeparator.Value, startIndex);
                if (endIndex < 0)
                {
                    endIndex = text.Length;
                }
                return text.Substring(startIndex, endIndex - startIndex);
            }
            return text.Substring(startIndex, text.Length - startIndex);
        }
        public static Boolean IsNullOrEmpty(this String text)
        {
            return String.IsNullOrEmpty(text);
        }
#if _Net_4_0 || _Net_4_5
        public static Boolean IsNullOrWhiteSpace(this String text)
        {
            return String.IsNullOrWhiteSpace(text);
        }
#endif

        public static Boolean? ToBoolean(this String value)
        {
            return AppEnvironment.Settings.TypeConverter.ToBoolean(value);
        }
        public static Guid? ToGuid(this String value)
        {
            return AppEnvironment.Settings.TypeConverter.ToGuid(value);
        }
        public static SByte? ToSByte(this String value)
        {
            return AppEnvironment.Settings.TypeConverter.ToSByte(value);
        }
        public static Int16? ToInt16(this String value)
        {
            return AppEnvironment.Settings.TypeConverter.ToInt16(value);
        }
        public static Int32? ToInt32(this String value)
        {
            return AppEnvironment.Settings.TypeConverter.ToInt32(value);
        }
        public static Int64? ToInt64(this String value)
        {
            return AppEnvironment.Settings.TypeConverter.ToInt64(value);
        }
        public static Byte? ToByte(this String value)
        {
            return AppEnvironment.Settings.TypeConverter.ToByte(value);
        }
        public static UInt16? ToUInt16(this String value)
        {
            return AppEnvironment.Settings.TypeConverter.ToUInt16(value);
        }
        public static UInt32? ToUInt32(this String value)
        {
            return AppEnvironment.Settings.TypeConverter.ToUInt32(value);
        }
        public static UInt64? ToUInt64(this String value)
        {
            return AppEnvironment.Settings.TypeConverter.ToUInt64(value);
        }
        public static Single? ToSingle(this String value)
        {
            return AppEnvironment.Settings.TypeConverter.ToSingle(value);
        }
        public static Double? ToDouble(this String value)
        {
            return AppEnvironment.Settings.TypeConverter.ToDouble(value);
        }
        public static Decimal? ToDecimal(this String value)
        {
            return AppEnvironment.Settings.TypeConverter.ToDecimal(value);
        }
        public static TimeSpan? ToTimeSpan(this String value)
        {
            return AppEnvironment.Settings.TypeConverter.ToTimeSpan(value);
        }
        public static DateTime? ToDateTime(this String value)
        {
            return AppEnvironment.Settings.TypeConverter.ToDateTime(value);
        }
        public static DateTimeOffset? ToDateTimeOffset(this String value)
        {
            return AppEnvironment.Settings.TypeConverter.ToDateTimeOffset(value);
        }
        public static T? ToEnum<T>(this String value) where T : struct
        {
            return AppEnvironment.Settings.TypeConverter.ToEnum<T>(value);
        }
    }
}
