using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    internal class ObjectMapTypeInfo
    {
        public Type Source { get; set; }
        public Type Target { get; set; }
        public ObjectMapTypeInfo(Type source, Type target)
        {
            this.Source = source;
            this.Target = target;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is ObjectMapTypeInfo)
            {
                var o = obj as ObjectMapTypeInfo;
                return this.Source.Equals(o.Source) && this.Target.Equals(o.Target);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.Source.GetHashCode() ^ this.Target.GetHashCode();
        }
    }
}
