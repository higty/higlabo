using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using HigLabo.Core;

namespace HigLabo.CodeGenerator.Json
{
    public partial class JsonParser
    {
        private class PropertyInfo
        {
            public String MapName { get; set; }
            public String Name { get; set; }
            public JsonTypeInfo TypeInfo { get; set; }
            public ClassInfo ClassInfo { get; set; }
            public String TypeName
            {
                get
                {
                    if (this.ClassInfo == null) { return ""; }
                    return this.ClassInfo.Name;
                }
            }
            public Int32 ArrayDimension { get; set; }
            public Boolean Nullable { get; set; }

            public PropertyInfo()
            {
                this.TypeInfo = JsonTypeInfo.Unknown;
                this.ArrayDimension = 0;
            }
            public void Validate(JToken token)
            {
                var tp = ClassInfo.GetJsonTypeInfo(token);
                if (token is JValue)
                {
                    var jv = token as JValue;
                    if (jv.Value == null)
                    {
                        this.Nullable = true;
                    }
                    else
                    {
                        tp = ClassInfo.GetJsonTypeInfo(jv);
                    }
                }
                else
                {
                    tp = ClassInfo.GetJsonTypeInfo(token);
                }
                if (tp != JsonTypeInfo.Unknown &&
                    tp != this.TypeInfo)
                {
                    this.TypeInfo = tp;
                }

            }
            public override string ToString()
            {
                if (this.TypeInfo == JsonTypeInfo.Array)
                {
                    return String.Format("{0}: {1}[]", this.Name, this.TypeName);
                }
                if (String.IsNullOrEmpty(this.TypeName) == true)
                {
                    return String.Format("{0}: {1}", this.Name, this.TypeInfo.ToStringFromEnum());
                }
                return String.Format("{0}: {1}", this.Name, this.TypeName);
            }
            public String GetCSharpTypeName()
            {
                if (this.TypeInfo == JsonTypeInfo.Unknown) { return "String"; }
                if (this.TypeInfo == JsonTypeInfo.Array)
                {
                    var array = "";
                    for (int i = 0; i < this.ArrayDimension; i++)
                    {
                        array += "[]";
                    }
                    if (String.IsNullOrEmpty(this.TypeName) == true)
                    {
                        return "String" + array;
                    }
                    return this.TypeName + array;
                }
                if (String.IsNullOrEmpty(this.TypeName) == true)
                {
                    if (this.TypeInfo == JsonTypeInfo.String ||
                        this.TypeInfo == JsonTypeInfo.Object)
                    {
                        return this.TypeInfo.ToStringFromEnum();
                    }
                    else if (this.Nullable == true)
                    {
                        return this.TypeInfo.ToStringFromEnum() + "?";
                    }
                    return this.TypeInfo.ToStringFromEnum();

                }
                return this.TypeName;
            }
        }
    }
}
