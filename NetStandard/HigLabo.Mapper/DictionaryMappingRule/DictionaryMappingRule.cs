using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class DictionaryMappingRule
    {
        public DictionaryMappingDirection Direction { get; set; }
        public TypeMatchCondition Condition { get; set; }

        public DictionaryMappingRule(DictionaryMappingDirection direction, Type type, TypeFilterCondition typeFilterCondition)
        {
            this.Direction = direction;
            this.Condition = new TypeMatchCondition();
            this.Condition.Type = type;
            this.Condition.TypeFilterCondition = typeFilterCondition;
        }
        public virtual String[] GetIndexedKeys(String propertyName)
        {
            return new[] { propertyName };
        }
    }
}
