using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class PrefixPropertyMappingRule : PropertyMappingRule
    {
        public String Prefix { get; set; }

        public PrefixPropertyMappingRule(String prefix)
            : base()
        {
            this.Prefix = prefix;
        }
        public override Boolean Match(PropertyInfo sourceProperty, PropertyInfo targetProperty)
        {
            return base.Match(sourceProperty.Name, this.Prefix + targetProperty.Name) ||
                base.Match(this.Prefix + sourceProperty.Name, targetProperty.Name);
        }
    }
}
