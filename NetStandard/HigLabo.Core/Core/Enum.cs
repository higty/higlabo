using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class Enum<T>
            where T : struct
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Parse(string value)
        {
            return Enum<T>.Parse(value, true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T Parse(string value, bool ignoreCase)
        {
            var tp = CheckEnumType();
            return (T)Enum.Parse(tp, value, ignoreCase);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="returnedValue"></param>
        /// <returns></returns>
        public static bool TryParse(string value, out T returnedValue)
        {
            return Enum<T>.TryParse(value, true, out returnedValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="returnedValue"></param>
        /// <returns></returns>
        public static bool TryParse(string value, bool ignoreCase, out T returnedValue)
        {
            var tp = CheckEnumType();
            try
            {
                returnedValue = (T)Enum.Parse(tp, value, ignoreCase);
                return true;
            }
            catch
            {
                returnedValue = default(T);
                return false;
            }
        }
#if !SILVERLIGHT
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static T[] GetValues()
        {
            var tp = CheckEnumType();
            return (T[])Enum.GetValues(tp);
        }
        public static String[] GetStringValues()
        {
            var tp = CheckEnumType();
            var tt = (T[])Enum.GetValues(tp);
            var ss = new String[tt.Length];
            for (int i = 0; i < tt.Length; i++)
            {
                ss[i] = tt[i].ToStringFromEnum();
            }
            return ss;
        }
#endif
        private static Type CheckEnumType()
        {
            Type tp = typeof(T);
#if !NETFX_CORE && !PCL
            if (tp.IsEnum == false) { throw new ArgumentException("T must be Enum type."); }
#endif
            return tp;
        }
    }
}
