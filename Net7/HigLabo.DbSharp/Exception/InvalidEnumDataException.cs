using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public class InvalidEnumDataException : Exception
    {
        public Type Type { get; set; }
        public Object Value { get; set; }

        public InvalidEnumDataException(Type type, Object value)
        {
            Type = type;
            Value = value;
        }
        public override string ToString()
        {
            return String.Format("Type={0}{3}Value={1}{3}{2}", this.Type.FullName, this.Value, base.ToString()
                , Environment.NewLine);
        }
    }
}
