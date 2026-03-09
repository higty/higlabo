using HigLabo.Core;

namespace HigLabo.X;

internal static class QueryParameterBuilder
{
    public static void Add(Dictionary<string, string> values, string key, string? value)
    {
        if (value.HasValue())
        {
            values[key] = value!;
        }
    }
    public static void AddValue<T>(Dictionary<string, string> values, string key, T? value) where T : struct
    {
        if (value.HasValue)
        {
            values[key] = value.Value.ToString()!;
        }
    }
    public static void AddField<TEnum>(Dictionary<string, string> values, string key, List<TEnum> fieldList, string fieldText)
        where TEnum : struct, Enum
    {
        if (fieldList.Count > 0)
        {
            Add(values, key, FieldParameter.Create(fieldList));
        }
        else
        {
            Add(values, key, fieldText);
        }
    }
}
