using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class DictionaryKeyMappingRule : DictionaryMappingRule
    {
        private List<KeyValuePair<String, String>> _MapKeys = new List<KeyValuePair<string, string>>();

        public DictionaryKeyMappingRule(DictionaryMappingDirection direction, Type type, TypeFilterCondition typeFilterCondition)
            : base(direction, type, typeFilterCondition)
        {
        }
        public void AddMap(String propertyName, String dictionaryKey)
        {
            var kv = new KeyValuePair<string, string>(propertyName, dictionaryKey);
            if (_MapKeys.Contains(kv)) { return; }
            _MapKeys.Add(kv);
        }
        public override string[] GetIndexedKeys(string propertyName)
        {
            return _MapKeys.Where(el => el.Key == propertyName).Select(el => el.Value).ToArray();
        }
    }
}
