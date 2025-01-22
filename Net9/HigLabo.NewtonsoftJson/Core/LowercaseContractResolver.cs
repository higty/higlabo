using Newtonsoft.Json.Serialization;
using HigLabo.Core;

namespace HigLabo.Newtonsoft;

public class LowercaseContractResolver : DefaultContractResolver
{
    protected override string ResolvePropertyName(string propertyName)
    {
        return propertyName.ToLower();
    }
}
