using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class PropertyNameMappingRule : PropertyMappingRule
    {
        private List<KeyValuePair<String, String>> _PropertyNameMaps = new List<KeyValuePair<string, string>>();

        public PropertyNameMappingRule()
        {
        }
        public void AddPropertyNameMap(String sourcePropertyName, String targetPropertyName)
        {
            var kv = new KeyValuePair<String, String>(sourcePropertyName, targetPropertyName);
            if (_PropertyNameMaps.Contains(kv)) { return; }
            _PropertyNameMaps.Add(kv);
        }
        public override Boolean Match(PropertyInfo sourceProperty, PropertyInfo targetProperty)
        {
            var l = _PropertyNameMaps;
            for (int i = 0; i < l.Count; i++)
            {
                var item = l[i];
                if (item.Key == sourceProperty.Name)
                {
                    if (this.Match(item.Value, targetProperty.Name) == true) { return true; }
                }
            }
            return false;
        }
    }
}
