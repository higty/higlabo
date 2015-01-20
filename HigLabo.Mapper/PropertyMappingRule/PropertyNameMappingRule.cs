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
        public PropertyNameMapList PropertyNameMaps { get; private set; }

        public PropertyNameMappingRule()
        {
            this.PropertyNameMaps = new PropertyNameMapList();
        }
        public override Boolean Match(PropertyInfo sourceProperty, PropertyInfo targetProperty)
        {
            var l = this.PropertyNameMaps;
            for (int i = 0; i < l.Count; i++)
            {
                var item = l[i];
                if (item.SourcePropertyName == sourceProperty.Name)
                {
                    if (this.Match(item.TargetPropertyName, targetProperty.Name) == true) { return true; }
                }
            }
            return false;
        }
    }
}
