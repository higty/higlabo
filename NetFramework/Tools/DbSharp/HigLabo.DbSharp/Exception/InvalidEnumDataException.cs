using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public class InvalidEnumDataException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public Type Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Object Value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public InvalidEnumDataException()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        public InvalidEnumDataException(Type type, Object value)
        {
            Type = type;
            Value = value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Type={0}{3}Value={1}{3}{2}", this.Type.FullName, this.Value, base.ToString()
                , Environment.NewLine);
        }
    }
}
