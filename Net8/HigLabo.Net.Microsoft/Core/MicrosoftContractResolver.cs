using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;

namespace HigLabo.Net.Microsoft;

public class MicrosoftContractResolver : CamelCasePropertyNamesContractResolver
{
    public MicrosoftContractResolver()
    {
    }
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        JsonProperty property = base.CreateProperty(member, memberSerialization);
        if (string.Equals(property.PropertyName, "ApiPathSetting", StringComparison.OrdinalIgnoreCase))
        {
            property.ShouldSerialize = _ => false;
        }
        if (string.Equals(property.PropertyName, "ODataContext", StringComparison.OrdinalIgnoreCase))
        {
            property.PropertyName = "@odata.context";
        }
        if (string.Equals(property.PropertyName, "ODataNextLink", StringComparison.OrdinalIgnoreCase))
        {
            property.PropertyName = "@odata.nextLink";
        }
        return property; 
    }
}
