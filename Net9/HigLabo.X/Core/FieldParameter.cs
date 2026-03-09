using HigLabo.Core;
using System.Text;

namespace HigLabo.X;

public static class FieldParameter
{
    public static string Create<TEnum>(IEnumerable<TEnum> fields)
        where TEnum : struct, Enum
    {
        var sb = new StringBuilder();
        foreach (var field in fields)
        {
            if (sb.Length > 0)
            {
                sb.Append(",");
            }
            sb.Append(field.ToStringFromEnum().ToSnakeCase().ToLower());
        }
        return sb.ToString();
    }
}
