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
        public StringComparer DictionaryKeyStringComparer { get; set; }
        public NullPropertyMapMode NullPropertyMapMode { get; set; }
        public CollectionElementMapMode CollectionElementMapMode { get; set; }

        public MappingContext(StringComparer stringComparer, NullPropertyMapMode nullPropertyMapMode, CollectionElementMapMode collectionElementMapMode)
        {
            this.DictionaryKeyStringComparer = stringComparer;
            this.NullPropertyMapMode = nullPropertyMapMode;
            this.CollectionElementMapMode = collectionElementMapMode;
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
