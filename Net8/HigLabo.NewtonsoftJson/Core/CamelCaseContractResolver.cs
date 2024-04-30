using Newtonsoft.Json.Serialization;

namespace HigLabo.Core
{
    public class CamelCaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToCamelCase();
        }
    }
}
