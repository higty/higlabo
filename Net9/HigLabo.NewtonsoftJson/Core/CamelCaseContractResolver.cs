using Newtonsoft.Json.Serialization;
using HigLabo.Core;

namespace HigLabo.Newtonsoft;

public class CamelCaseContractResolver : DefaultContractResolver
{
    protected override string ResolvePropertyName(string propertyName)
    {
        return propertyName.ToCamelCase();
    }
}
