using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class MappingContext
    {
        internal List<KeyValuePair<Object, Object>> MappedObjectPair { get; private set; }
        internal Int32 CallStackCount { get; set; }
        public Boolean DictionaryKeyIgnoreCase { get; set; }

        public MappingContext(Boolean dictionaryKeyIgnoreCase)
        {
            this.DictionaryKeyIgnoreCase = dictionaryKeyIgnoreCase;
            this.MappedObjectPair = new List<KeyValuePair<Object, Object>>();
        }
    }
}
