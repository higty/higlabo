using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth
{
    public class IgnorePropertyResolver : DefaultContractResolver
    {
        private readonly HashSet<string> _PropertyNameList;

        public IgnorePropertyResolver(string propertyName)
            : this(new string[] { propertyName })
        {
        }
        public IgnorePropertyResolver(IEnumerable<string> propertyNameList)
        {
            this._PropertyNameList = new HashSet<string>(propertyNameList, StringComparer.OrdinalIgnoreCase);
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
        protected override JsonProperty CreateProperty(MemberInfo methodInfo, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(methodInfo, memberSerialization);
            if (this._PropertyNameList.Contains(property.PropertyName) == true)
            {
                property.ShouldSerialize = _ => false;
            }
            return property;
        }
    }
}
