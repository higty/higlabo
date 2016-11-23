using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class MappingContext
    {
        private List<KeyValuePair<Object, Object>> _MappedObjectPair = new List<KeyValuePair<object, object>>();

        internal Int32 CallStackCount { get; set; }
        public StringComparer DictionaryKeyStringComparer { get; set; }

        public MappingContext(StringComparer stringComparer)
        {
            this.DictionaryKeyStringComparer = stringComparer;
        }
        public Boolean Exists(KeyValuePair<Object, Object> value)
        {
            if (_MappedObjectPair.Contains(value) == true) { return true; }
            _MappedObjectPair.Add(value);
            return false;
        }
    }
}
