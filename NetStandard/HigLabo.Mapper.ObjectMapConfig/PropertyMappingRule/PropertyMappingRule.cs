using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class PropertyMappingRule
    {
        public MappingCondition Condition { get; private set; }

        public PropertyMappingRule()
        {
            this.Condition = new MappingCondition();
        }
        public virtual Boolean Match(PropertyInfo sourceProperty, PropertyInfo targetProperty)
        {
            return this.Match(sourceProperty.Name, targetProperty.Name);
        }
        protected Boolean Match(String sourcePropertyName, String targetPropertyName)
        {
            return String.Equals(sourcePropertyName, targetPropertyName, StringComparison.Ordinal);
        }
    }
}
