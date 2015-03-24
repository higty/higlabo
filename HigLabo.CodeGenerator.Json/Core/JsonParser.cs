using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HigLabo.Core;
using System.Text;
using System.Text.RegularExpressions;

namespace HigLabo.CodeGenerator.Json
{
    public partial class JsonParser
    {
        private static class RegexList
        {
            public static Regex ElementChars = new Regex("[a-z0-9_]", RegexOptions.IgnoreCase);
        }
        public Class Parse(String json, String className)
        {
            Class result = new Class(AccessModifier.Public, className);
            
            var oo = JsonConvert.DeserializeObject(json);
            var c = new ClassInfo(className);
            if (oo is JArray)
            {
                foreach (var jo in (JArray)oo)
                {
                    if (jo is JObject)
                    {
                        SetProperties(c, (JObject)jo);
                    }
                    else if (jo is JValue)
                    {
                        var pi = new PropertyInfo();
                        pi.Validate(jo);
                        return new Class(AccessModifier.Public, pi.GetCSharpTypeName());
                    }
                }
            }
            else if (oo is JObject)
            {
                SetProperties(c, (JObject)oo);
            }
            SetProperties(result, c);

            return result;
        }
        private void SetProperties(ClassInfo classInfo, JObject obj)
        {
            var c = classInfo;
            foreach (var p in obj.Properties())
            {
                PropertyInfo pi = c.Properties.Find(el => el.Name == p.Name);

                if (pi == null)
                {
                    pi = new PropertyInfo();
                    pi.MapName = p.Name;
                    pi.Name = GetPropertyName(p.Name);
                    c.Properties.Add(pi);
                }
                pi.Validate(p.Value);

                var childClassName = GetClassName(pi.Name);
                if (pi.TypeInfo == JsonTypeInfo.Object)
                {
                    var childClass = c.Classes.Find(el => el.Name == childClassName);
                    if (childClass == null)
                    {
                        childClass = new ClassInfo(childClassName);
                        c.Classes.Add(childClass);
                    }
                    pi.ClassInfo = childClass;

                    if (p.Value is JObject)
                    {
                        var jo = p.Value as JObject;
                        SetProperties(childClass, jo);
                    }
                }
                else if (pi.TypeInfo == JsonTypeInfo.Array)
                {
                    SetArrayTypeName(c, pi, childClassName, (JArray)p.Value, 1);
                }
                else
                {
                    this.SetClassInfo(pi, p.Value as JValue);
                }
            }

        }
        private String GetPropertyName(String name)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                var c = name[i];
                if (RegexList.ElementChars.IsMatch(c.ToString()) == true)
                {
                    sb.Append(c);
                }
                else
                {
                    sb.Append("_");
                }
            }
            var modifiedName = sb.ToString();
            modifiedName = modifiedName.Replace("__", "_");
            if (modifiedName[0] == '_')
            {
                modifiedName = modifiedName.Substring(1, modifiedName.Length - 1);
            }
            //2ndProperty --> forbidden. first char must not be digit.
            if (Char.IsDigit(modifiedName[0]) == true)
            {
                return "_" + modifiedName;
            }
            return modifiedName;
        }
        private String GetClassName(String name)
        {
            if (name == "indices") { name = "index"; }
            if (name.EndsWith("ies")) { name = name.Substring(0, name.Length - 3) + "y"; }
            if (name.EndsWith("es")) { name = name.Substring(0, name.Length - 1); }
            if (name.EndsWith("s")) { name = name.Substring(0, name.Length - 1); }
            var modifiedName = ClassInfo.ToPascalCase(name);
            //2ndProperty --> forbidden. first char must not be digit.
            if (Char.IsDigit(modifiedName[0]) == true)
            {
                return "_" + modifiedName;
            }
            return modifiedName;
        }
        private void SetArrayTypeName(ClassInfo classInfo, PropertyInfo propertyInfo, String propertyName, JArray array, Int32 arrayDimension)
        {
            var c = classInfo;
            var pi = propertyInfo;
            var pName = propertyName;

            pi.ArrayDimension = arrayDimension;

            foreach (var item in array)
            {
                if (item is JObject)
                {
                    pi.ArrayDimension = arrayDimension;

                    var childClass = c.Classes.Find(el => el.Name == pName);
                    if (childClass == null)
                    {
                        childClass = new ClassInfo(pName);
                        c.Classes.Add(childClass);
                    }
                    pi.ClassInfo = childClass;
                    SetProperties(childClass, item as JObject);
                }
                else if (item is JValue)
                {
                    pi.ArrayDimension = arrayDimension;
                    this.SetClassInfo(pi, item as JValue);
                }
                else if (item is JArray)
                {
                    SetArrayTypeName(c, pi, pName, (JArray)item, arrayDimension + 1);
                }
            }
        }
        private void SetClassInfo(PropertyInfo propertyInfo, JValue jValue)
        {
            var pi = propertyInfo;
            var tp = ClassInfo.GetJsonTypeInfo(jValue);
            switch (tp)
            {
                case JsonTypeInfo.Boolean:
                case JsonTypeInfo.Int32:
                case JsonTypeInfo.Int64:
                case JsonTypeInfo.Double:
                case JsonTypeInfo.DateTime:
                    {
                        pi.ClassInfo = new ClassInfo(tp.ToStringFromEnum() + "?");
                    }
                    break;
                case JsonTypeInfo.String:
                case JsonTypeInfo.Object:
                    {
                        pi.ClassInfo = new ClassInfo(tp.ToStringFromEnum());
                    }
                    break;
                case JsonTypeInfo.Unknown: break;
                case JsonTypeInfo.Array:
                default: throw new InvalidOperationException();
            }

        }
        private static void SetProperties(Class @class, ClassInfo classInfo)
        {
            var c = @class;
            var ci = classInfo;

            foreach (var item in ci.Properties)
            {
                if (item.ClassInfo == null)
                {
                    item.ClassInfo = new ClassInfo("Object");
                }
                if (item.Name == item.ClassInfo.Name)
                {
                    item.ClassInfo.Name = "Class_" + item.ClassInfo.Name;
                    item.ClassInfo.Name = item.ClassInfo.Name.Replace("__", "_");
                }
            }
            foreach (var item in ci.Classes)
            {
                //If parent class name equals to child class name 
                if (c.Name == item.Name)
                {
                    item.Name = "Class_" + item.Name;
                }
                var childClass = new Class(AccessModifier.Public, item.Name);
                SetProperties(childClass, item);
                c.Classes.Add(childClass);
            }
            foreach (var item in ci.Properties)
            {
                var p = new Property(item.GetCSharpTypeName(), item.Name);
                p.Get.IsAutomaticProperty = true;
                p.Set.IsAutomaticProperty = true;
                p.Attributes.Add(String.Format("[JsonProperty(\"{0}\")]", item.MapName));
                c.Properties.Add(p);
            }
        }
    }
}
