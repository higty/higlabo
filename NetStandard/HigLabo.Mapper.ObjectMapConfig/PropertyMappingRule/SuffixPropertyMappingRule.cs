using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class SuffixPropertyMappingRule : PropertyMappingRule
    {
        public String Suffix { get; set; }

        public SuffixPropertyMappingRule(String suffix)
            : base()
        {
            this.Suffix = suffix;
        }
        public override Boolean Match(PropertyInfo sourceProperty, PropertyInfo targetProperty)
        {
            return base.Match(sourceProperty.Name, targetProperty.Name + this.Suffix) ||
                base.Match(sourceProperty.Name + this.Suffix, targetProperty.Name);
        }
    }
}
