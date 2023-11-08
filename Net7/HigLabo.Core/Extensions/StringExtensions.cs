using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core
{
    public static partial class StringExtensions
    {
        public static String? UnifyLineFeed(this String text)
        {
            if (text == null) { return text; }

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
        public static Boolean IsNullOrEmpty(this String? text)
        {
            if (text == null) { return true; }
            return String.IsNullOrEmpty(text);
        }

        /// <summary>
        /// PascalCaseFirstLetterOfEveryWordIsUpper
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String ToPascalCase(this String value)
        {
            if (value == null) { return ""; }

            var sb = new StringBuilder(value.Length);

            var previousIsUnderscore = false;
            for (var i = 0; i < value.Length; i++)
            {
                if (i == 0)
                {
                    sb.Append(value[i].ToString().ToUpper());
                }
                else
                {
                    if (previousIsUnderscore)
                    {
                        sb.Append(value[i].ToString().ToUpper());
                    }
                    else
                    {
                        sb.Append(value[i]);
                    }
                }
                if (value[i] == '_')
                {
                    previousIsUnderscore = true;
                }
                else
                {
                    previousIsUnderscore = false;
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// camelCaseFirstLetterIsLowerAndFirstLetterOfEveryWordIsUpper
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String ToCamelCase(this String value)
        {
            if (value == null) { return ""; }

            var sb = new StringBuilder(value.Length);

            for (var i = 0; i < value.Length; i++)
            {
                if (i == 0)
                {
                    sb.Append(value[i].ToString().ToLower());
                }
                else
                {
                    sb.Append(value[i]);
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// snake_case_is_lower_case_and_underscore
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String ToSnakeCase(this String value)
        {
            if (value == null) { return ""; }

            var sb = new StringBuilder(value.Length + 4);

            for (var i = 0; i < value.Length; i++)
            {
                if (i > 0 && Char.IsUpper(value[i]))
                {
                    sb.Append("_");
                }
                sb.Append(value[i]);
            }
            return sb.ToString();
        }
        /// <summary>
        /// Train-Case-is-Upper-Case-And-Hyphen
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String ToTrainCase(this String value)
        {
            if (value == null) { return ""; }

            var sb = new StringBuilder(value.Length + 4);

            for (var i = 0; i < value.Length; i++)
            {
                if (i > 0 && Char.IsUpper(value[i]))
                {
                    sb.Append("-");
                }
                sb.Append(value[i]);
            }
            return sb.ToString();
        }
        /// <summary>
        /// kebab-case-is-lower-case-and-hyphen
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String ToKebabCase(this String value)
        {
            if (value == null) { return ""; }

            var sb = new StringBuilder(value.Length + 4);
            var previousCharIsUpperCase = false;

            for (var i = 0; i < value.Length; i++)
            {
                if (i > 0 && Char.IsUpper(value[i]) && previousCharIsUpperCase == false)
                {
                    previousCharIsUpperCase = true;
                    sb.Append("-");
                }
                else
                {
                    previousCharIsUpperCase = false;
                }
                sb.Append(value[i].ToString().ToLower());
            }
            return sb.ToString();
        }
        /// <summary>
        /// lisp-case-is-lower-case-and-hyphen
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String ToLispCase(this String value)
        {
            return ToKebabCase(value);
        }

        public static Boolean? ToBoolean(this String value)
        {
            return TypeConverter.Current.ToBoolean(value);
        }
        public static Guid? ToGuid(this String value)
        {
            return TypeConverter.Current.ToGuid(value);
        }
        public static SByte? ToSByte(this String value)
        {
            return TypeConverter.Current.ToSByte(value);
        }
        public static Int16? ToInt16(this String value)
        {
            return TypeConverter.Current.ToInt16(value);
        }
        public static Int32? ToInt32(this String value)
        {
            return TypeConverter.Current.ToInt32(value);
        }
        public static Int64? ToInt64(this String value)
        {
            return TypeConverter.Current.ToInt64(value);
        }
        public static Byte? ToByte(this String value)
        {
            return TypeConverter.Current.ToByte(value);
        }
        public static UInt16? ToUInt16(this String value)
        {
            return TypeConverter.Current.ToUInt16(value);
        }
        public static UInt32? ToUInt32(this String value)
        {
            return TypeConverter.Current.ToUInt32(value);
        }
        public static UInt64? ToUInt64(this String value)
        {
            return TypeConverter.Current.ToUInt64(value);
        }
        public static Single? ToSingle(this String value)
        {
            return TypeConverter.Current.ToSingle(value);
        }
        public static Double? ToDouble(this String value)
        {
            return TypeConverter.Current.ToDouble(value);
        }
        public static Decimal? ToDecimal(this String value)
        {
            return TypeConverter.Current.ToDecimal(value);
        }
        public static TimeOnly? ToTimeOnly(this String value)
        {
            return TypeConverter.Current.ToTimeOnly(value);
        }
        public static DateOnly? ToDateOnly(this String value)
        {
            return TypeConverter.Current.ToDateOnly(value);
        }
        public static TimeSpan? ToTimeSpan(this String value)
        {
            return TypeConverter.Current.ToTimeSpan(value);
        }
        public static DateTime? ToDateTime(this String value)
        {
            return TypeConverter.Current.ToDateTime(value);
        }
        public static DateTimeOffset? ToDateTimeOffset(this String value)
        {
            return TypeConverter.Current.ToDateTimeOffset(value);
        }
        public static T? ToEnum<T>(this String value) where T : struct
        {
            return TypeConverter.Current.ToEnum<T>(value, true);
        }
        public static T? ToEnum<T>(this String value, Boolean ignoreCase) where T : struct
        {
            return TypeConverter.Current.ToEnum<T>(value, ignoreCase);
        }
    }
}
