using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace HigLabo.CodeGenerator.Json
{
    public partial class JsonParser
    {
        private class ClassInfo
        {
            public String Name { get; set; }
            public List<ClassInfo> Classes { get; private set; }
            public List<PropertyInfo> Properties { get; private set; }

            public ClassInfo(String name)
            {
                this.Name = name;
                this.Classes = new List<ClassInfo>();
                this.Properties = new List<PropertyInfo>();
            }
            public static JsonTypeInfo GetJsonTypeInfo(JToken token)
            {
                var type = token.Type;
                if (type == JTokenType.Integer)
                {
                    //if ((long)((JValue)token).Value < Int.MaxValue) return JsonTypeInfo.Int32;
                    return JsonTypeInfo.Int64;
                }
                switch (type)
                {
                    case JTokenType.Array: return JsonTypeInfo.Array;
                    case JTokenType.Boolean: return JsonTypeInfo.Boolean;
                    case JTokenType.Float: return JsonTypeInfo.Double;
                    case JTokenType.Null: return JsonTypeInfo.Unknown;
                    case JTokenType.Undefined: return JsonTypeInfo.Unknown;
                    case JTokenType.String: return JsonTypeInfo.String;
                    case JTokenType.Date: return JsonTypeInfo.DateTime;
                    case JTokenType.Object: return JsonTypeInfo.Object;
                }
                return JsonTypeInfo.Unknown;
            }
            public override string ToString()
            {
                return this.Name;
            }
            public static String ToPascalCase(String value)
            {
                StringBuilder sb = new StringBuilder();
                var previousIsUnderscore = true;
                for (int i = 0; i < value.Length; i++)
                {
                    if (previousIsUnderscore == true)
                    {
                        sb.Append(value[i].ToString().ToUpper());
                    }
                    else
                    {
                        sb.Append(value[i]);
                    }
                    if (value[i] == '_')
                    {
                        previousIsUnderscore = true;
                    }
                    else
                    {
                        previousIsUnderscore = false;
                    }
                }
                return sb.ToString();
            }
        }
    }
}
