using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class IgnoreUnderscorePropertyMappingRule : PropertyMappingRule
    {
        public IgnoreUnderscorePropertyMappingRule()
            : base()
        {
        }
        public override Boolean Match(PropertyInfo sourceProperty, PropertyInfo targetProperty)
        {
            return base.Match(sourceProperty.Name.Replace("_", ""), targetProperty.Name.Replace("_", ""));
        }
    }
}
