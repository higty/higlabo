using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HigLabo.Core;

namespace HigLabo.Newtonsoft;

public class NullToEmptyStringResolver : DefaultContractResolver
{
    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    {
        return type.GetProperties()
                .Select(p => {
                    var jp = base.CreateProperty(p, memberSerialization);
                    if (p.PropertyType == typeof(String))
                    {
                        jp.ValueProvider = new NullToEmptyStringValueProvider(p);
                    }
                    return jp;
                }).ToList();
    }
}

public class NullToEmptyStringValueProvider : IValueProvider
{
    private PropertyInfo _MemberInfo;

    public NullToEmptyStringValueProvider(PropertyInfo memberInfo)
    {
        _MemberInfo = memberInfo;
    }
    public object? GetValue(object target)
    {
        var result = _MemberInfo.GetValue(target);
        if (result == null) { return ""; }
        if (_MemberInfo.PropertyType == typeof(string) && result == null) { result = ""; }
        else if (_MemberInfo.PropertyType == typeof(DateTime?) && result == null) { result = null; }
        return result;
    }
    public void SetValue(object target, object? value)
    {
        _MemberInfo.SetValue(target, value);
    }
}
