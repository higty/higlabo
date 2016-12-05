using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class MappingContext
    {
        private List<KeyValuePair<Object, Object>> _MappedObjectPair = new List<KeyValuePair<Object, Object>>();

        internal Int32 CallStackCount { get; set; }

        public MappingContext()
        {
        }
        public Boolean Exists(Object source, Object target)
        {
            var kv = new KeyValuePair<object, object>(source, target);
            if (_MappedObjectPair.Contains(kv) == true) { return true; }
            _MappedObjectPair.Add(kv);
            return false;
        }
    }
}
