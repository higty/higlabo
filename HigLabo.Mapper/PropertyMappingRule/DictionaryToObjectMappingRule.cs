using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class DictionaryToObjectMappingRule : PropertyMappingRule
    {
        public override Boolean Match(PropertyInfo sourceProperty, PropertyInfo targetProperty)
        {
            if (sourceProperty.Name == "Item")
            {
                var pp = sourceProperty.GetIndexParameters();
                //source["key1"]
                if (pp.Length == 1 && pp[0].ParameterType == typeof(String))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
