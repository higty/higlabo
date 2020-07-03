using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HigLabo.Core
{
    public class DefaultPropertyMappingRule : PropertyMappingRule
    {
        public override Boolean Match(PropertyInfo sourceProperty, PropertyInfo targetProperty)
        {
            if (sourceProperty.GetIndexParameters().Length > 0 || targetProperty.GetIndexParameters().Length > 0) { return false; }
            return String.Equals(sourceProperty.Name.Replace("_", ""), targetProperty.Name.Replace("_", ""), StringComparison.OrdinalIgnoreCase);
        }
    }
}
