using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core
{
    public abstract class Serializer
    {
        public abstract String Serialize(Object obj);
        public abstract T Deserialize<T>(String text);
    }
}
