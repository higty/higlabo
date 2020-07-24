using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace HigLabo.Core
{
    public struct ActionKey : IEquatable<ActionKey>
    {
        public Type Source { get; private set; }
        public Type Destination { get; private set; }

        public ActionKey(Type source, Type destination)
        {
            this.Source = source;
            this.Destination = destination;
        }

        public bool Equals(ActionKey obj)
        {
            return Source == obj.Source && Destination == obj.Destination;
        }
        public override Boolean Equals(object obj)
        {
            if (!(obj is ActionKey))
                return false;
            return Equals((ActionKey)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var h1 = Source.GetHashCode();
                var h2 = Destination.GetHashCode();
                UInt32 rol5 = ((UInt32)h1 << 5) | ((UInt32)h1 >> 27);
                return ((Int32)rol5 + h1) ^ h2;
            }
        }
        public static bool operator ==(ActionKey left, ActionKey right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(ActionKey left, ActionKey right)
        {
            return !left.Equals(right);
        }
    }
    public class CompilerConfig
    {
        public ClassPropertyMapMode ClassPropertyMapMode { get; set; } = ClassPropertyMapMode.NewObject;
        public CollectionElementMapMode CollectionElementMapMode { get; set; } = CollectionElementMapMode.NewObject;
    }
    public class MapContext
    {
        public ObjectMapper Mapper { get; private set; }

        public MapContext(ObjectMapper mapper)
        {
            this.Mapper = mapper;
        }
    }
    public class ObjectMapper
    {
        private class MapperMethodAttribute : Attribute
        {
        }
        private class ParseMethodList
        {
            [MapperMethod]
            public static Boolean Boolean(String value, Boolean defaultValue)
            {
                if (System.Boolean.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static SByte SByte(String value, SByte defaultValue)
            {
                if (System.SByte.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static Int16 Int16(String value, Int16 defaultValue)
            {
                if (System.Int16.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static Int32 Int32(String value, Int32 defaultValue)
            {
                if (System.Int32.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static Int64 Int64(String value, Int64 defaultValue)
            {
                if (System.Int64.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static Byte Byte(String value, Byte defaultValue)
            {
                if (System.Byte.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static UInt16 UInt16(String value, UInt16 defaultValue)
            {
                if (System.UInt16.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static UInt32 UInt32(String value, UInt32 defaultValue)
            {
                if (System.UInt32.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static UInt64 UInt64(String value, UInt64 defaultValue)
            {
                if (System.UInt64.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static DateTime DateTime(String value, DateTime defaultValue)
            {
                if (System.DateTime.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static DateTimeOffset DateTimeOffset(String value, DateTimeOffset defaultValue)
            {
                if (System.DateTimeOffset.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static TimeSpan TimeSpan(String value, TimeSpan defaultValue)
            {
                if (System.TimeSpan.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static Decimal Decimal(String value, Decimal defaultValue)
            {
                if (System.Decimal.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static Single Single(String value, Single defaultValue)
            {
                if (System.Single.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static Double Double(String value, Double defaultValue)
            {
                if (System.Double.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static Guid Guid(String value, Guid defaultValue)
            {
                if (System.Guid.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }

            public static Boolean HasParseMethod(Type type)
            {
                return type == typeof(Boolean) ||
                    type == typeof(SByte) ||
                    type == typeof(Int16) ||
                    type == typeof(Int32) ||
                    type == typeof(Int64) ||
                    type == typeof(Byte) ||
                    type == typeof(UInt16) ||
                    type == typeof(UInt32) ||
                    type == typeof(UInt64) ||
                    type == typeof(DateTime) ||
                    type == typeof(DateTimeOffset) ||
                    type == typeof(TimeSpan) ||
                    type == typeof(Decimal) ||
                    type == typeof(Single) ||
                    type == typeof(Double) ||
                    type == typeof(Guid);
            }
        }
        private class ParseOrNullMethodList
        {
            [MapperMethod]
            public static Boolean? Boolean(String value, Boolean? defaultValue)
            {
                if (System.Boolean.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static SByte? SByte(String value, SByte? defaultValue)
            {
                if (System.SByte.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static Int16? Int16(String value, Int16? defaultValue)
            {
                if (System.Int16.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static Int32? Int32(String value, Int32? defaultValue)
            {
                if (System.Int32.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static Int64? Int64(String value, Int64? defaultValue)
            {
                if (System.Int64.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static Byte? Byte(String value, Byte? defaultValue)
            {
                if (System.Byte.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static UInt16? UInt16(String value, UInt16? defaultValue)
            {
                if (System.UInt16.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static UInt32? UInt32(String value, UInt32? defaultValue)
            {
                if (System.UInt32.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static UInt64? UInt64(String value, UInt64? defaultValue)
            {
                if (System.UInt64.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static DateTime? DateTime(String value, DateTime? defaultValue)
            {
                if (System.DateTime.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static DateTimeOffset? DateTimeOffset(String value, DateTimeOffset? defaultValue)
            {
                if (System.DateTimeOffset.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static TimeSpan? TimeSpan(String value, TimeSpan? defaultValue)
            {
                if (System.TimeSpan.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static Decimal? Decimal(String value, Decimal? defaultValue)
            {
                if (System.Decimal.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static Single? Single(String value, Single? defaultValue)
            {
                if (System.Single.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static Double? Double(String value, Double? defaultValue)
            {
                if (System.Double.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static Guid? Guid(String value, Guid? defaultValue)
            {
                if (System.Guid.TryParse(value, out var v)) { return v; }
                return defaultValue;
            }
            [MapperMethod]
            public static Encoding Encoding(String value, Encoding defaultValue)
            {
                try
                {
                    return System.Text.Encoding.GetEncoding(value);
                }
                catch { }
                return null;
            }

            public static Boolean HasParseOrNullMethod(Type type)
            {
                return type == typeof(Boolean) ||
                    type == typeof(SByte) ||
                    type == typeof(Int16) ||
                    type == typeof(Int32) ||
                    type == typeof(Int64) ||
                    type == typeof(Byte) ||
                    type == typeof(UInt16) ||
                    type == typeof(UInt32) ||
                    type == typeof(UInt64) ||
                    type == typeof(DateTime) ||
                    type == typeof(DateTimeOffset) ||
                    type == typeof(TimeSpan) ||
                    type == typeof(Decimal) ||
                    type == typeof(Single) ||
                    type == typeof(Double) ||
                    type == typeof(Guid) ||
                    type == typeof(Encoding);
            }
        }
        private class PropertyMap
        {
            public PropertyInfo Source { get; set; }
            public PropertyInfo Target { get; set; }
        }
        private class MapParameterList
        {
            public ParameterExpression Source { get; set; }
            public ParameterExpression Target { get; set; }
            public ParameterExpression Context { get; set; }
        }

        private static readonly Dictionary<String, MethodInfo> _ParseMethodList = new Dictionary<string, MethodInfo>();
        private static readonly Dictionary<String, MethodInfo> _ParseOrNullMethodList = new Dictionary<string, MethodInfo>();
        private static readonly Dictionary<ActionKey, Boolean> _CanConvertList = new Dictionary<ActionKey, bool>();

        public static ObjectMapper Default { get; private set; } = new ObjectMapper();

        private MapContext _MapContext;
        private Dictionary<ActionKey, Delegate> _MapActionList = new Dictionary<ActionKey, Delegate>();

        public CompilerConfig CompilerConfig { get; private set; } = new CompilerConfig();

        static ObjectMapper()
        {
            InitializeParseMethodList();
            InitializeCanConvertList();
        }
        public ObjectMapper()
        {
            _MapContext = new MapContext(this);
        }

        private static void InitializeParseMethodList()
        {
            foreach (var item in typeof(ObjectMapper.ParseMethodList).GetMethods()
                .Where(el => el.GetCustomAttributes().Any(attr => attr is MapperMethodAttribute)))
            {
                _ParseMethodList.Add(item.Name, item);
            }
            foreach (var item in typeof(ObjectMapper.ParseOrNullMethodList).GetMethods()
                .Where(el => el.GetCustomAttributes().Any(attr => attr is MapperMethodAttribute)))
            {
                _ParseOrNullMethodList.Add(item.Name, item);
            }
        }
        private static void InitializeCanConvertList()
        {
            var d = _CanConvertList;
            d.Add(new ActionKey(typeof(SByte), typeof(Int16)), true);
            d.Add(new ActionKey(typeof(SByte), typeof(Int32)), true);
            d.Add(new ActionKey(typeof(SByte), typeof(Int64)), true);
            d.Add(new ActionKey(typeof(SByte), typeof(Single)), true);
            d.Add(new ActionKey(typeof(SByte), typeof(Double)), true);
            d.Add(new ActionKey(typeof(SByte), typeof(Decimal)), true);

            d.Add(new ActionKey(typeof(Int16), typeof(Int32)), true);
            d.Add(new ActionKey(typeof(Int16), typeof(Int64)), true);
            d.Add(new ActionKey(typeof(Int16), typeof(Single)), true);
            d.Add(new ActionKey(typeof(Int16), typeof(Double)), true);
            d.Add(new ActionKey(typeof(Int16), typeof(Decimal)), true);

            d.Add(new ActionKey(typeof(Int32), typeof(Int64)), true);
            d.Add(new ActionKey(typeof(Int32), typeof(Single)), true);
            d.Add(new ActionKey(typeof(Int32), typeof(Double)), true);
            d.Add(new ActionKey(typeof(Int32), typeof(Decimal)), true);

            d.Add(new ActionKey(typeof(Int64), typeof(Single)), true);
            d.Add(new ActionKey(typeof(Int64), typeof(Double)), true);
            d.Add(new ActionKey(typeof(Int64), typeof(Decimal)), true);

            d.Add(new ActionKey(typeof(Single), typeof(Double)), true);
            d.Add(new ActionKey(typeof(Single), typeof(Decimal)), true);

            d.Add(new ActionKey(typeof(Double), typeof(Decimal)), true);

            d.Add(new ActionKey(typeof(Byte), typeof(UInt16)), true);
            d.Add(new ActionKey(typeof(Byte), typeof(UInt32)), true);
            d.Add(new ActionKey(typeof(Byte), typeof(UInt64)), true);
            d.Add(new ActionKey(typeof(Byte), typeof(Int16)), true);
            d.Add(new ActionKey(typeof(Byte), typeof(Int32)), true);
            d.Add(new ActionKey(typeof(Byte), typeof(Int64)), true);
            d.Add(new ActionKey(typeof(Byte), typeof(Single)), true);
            d.Add(new ActionKey(typeof(Byte), typeof(Double)), true);
            d.Add(new ActionKey(typeof(Byte), typeof(Decimal)), true);

            d.Add(new ActionKey(typeof(UInt16), typeof(UInt32)), true);
            d.Add(new ActionKey(typeof(UInt16), typeof(UInt64)), true);
            d.Add(new ActionKey(typeof(UInt16), typeof(Int32)), true);
            d.Add(new ActionKey(typeof(UInt16), typeof(Int64)), true);
            d.Add(new ActionKey(typeof(UInt16), typeof(Single)), true);
            d.Add(new ActionKey(typeof(UInt16), typeof(Double)), true);
            d.Add(new ActionKey(typeof(UInt16), typeof(Decimal)), true);

            d.Add(new ActionKey(typeof(UInt32), typeof(UInt64)), true);
            d.Add(new ActionKey(typeof(UInt32), typeof(Int64)), true);
            d.Add(new ActionKey(typeof(UInt32), typeof(Single)), true);
            d.Add(new ActionKey(typeof(UInt32), typeof(Double)), true);
            d.Add(new ActionKey(typeof(UInt32), typeof(Decimal)), true);

            d.Add(new ActionKey(typeof(UInt64), typeof(Single)), true);
            d.Add(new ActionKey(typeof(UInt64), typeof(Double)), true);
            d.Add(new ActionKey(typeof(UInt64), typeof(Decimal)), true);

        }

        public TTarget Map<TSource, TTarget>(TSource source, TTarget target)
        {
            return this.Map(source, target, _MapContext);
        }
        public Dictionary<String, Object> Map<TSource>(TSource source, Dictionary<String, Object> target)
        {
            return this.Map(source, target, _MapContext);
        }
        public TTarget MapOrNull<TSource, TTarget>(TSource source, Func<TTarget> func)
            where TTarget : class
        {
            if (source == null) { return null; }
            return Map(source, func(), _MapContext);
        }
        public TTarget MapOrNull<TSource, TTarget>(TSource source, TTarget target)
            where TTarget: class
        {
            if (source == null) { return null; }
            return Map(source, target, _MapContext);
        }
        private TTarget Map<TSource, TTarget>(TSource source, TTarget target, MapContext context)
        {
            return this.Map<TSource, TTarget>(new ActionKey(typeof(TSource), typeof(TTarget)), source, target, context);
        }
        private TTarget Map<TSource, TTarget>(TSource source, MapContext context)
            where TTarget: new()
        {
            var target = new TTarget();
            this.Map<TSource, TTarget>(new ActionKey(typeof(TSource), typeof(TTarget)), source, target, context);
            return target;
        }

        private TTarget Map<TSource, TTarget>(ActionKey key, TSource source, TTarget target, MapContext context)
        {
            if (_MapActionList.TryGetValue(key, out var func) == false)
            {
                func = CreateMapMethod(source, target, context);
                _MapActionList.Add(key, func);
            }
            return ((Func<TSource, TTarget, MapContext, TTarget>)func)(source, target, context);
        }
        private Dictionary<String, Object> MapToDictionary<TSource>(ActionKey key, TSource source, Dictionary<String, Object> target, MapContext context)
        {
            if (_MapActionList.TryGetValue(key, out var func) == false)
            {
                func = CreateMapMethod(source, target, context);
                _MapActionList.Add(key, func);
            }
            return ((Func<TSource, Dictionary<String, Object>, MapContext, Dictionary<String, Object>>)func)(source, target, context);
        }

        private Delegate CreateMapMethod<TSource, TTarget>(TSource source, TTarget target, MapContext context)
        {
            var lambda = CreateFunctionExpression(typeof(TSource), typeof(TTarget), context);
            Delegate action = (Func<TSource, TTarget, MapContext, TTarget>)lambda.Compile();
            return action;
        }

        private List<(PropertyInfo source, PropertyInfo target)> CreatePropertyMapping(Type sourceType, Type targetType)
        {
            var pp = new List<(PropertyInfo, PropertyInfo)>();

            var sourceTypes = new List<Type>();
            sourceTypes.Add(sourceType);
            sourceTypes.AddRange(sourceType.GetBaseClasses());
            sourceTypes.AddRange(sourceType.GetInterfaces());
            var targetTypes = new List<Type>();
            targetTypes.Add(targetType);
            targetTypes.AddRange(targetType.GetBaseClasses());
            targetTypes.AddRange(targetType.GetInterfaces());

            var sourcePropertyList = new List<PropertyInfo>();
            var targetPropertyList = new List<PropertyInfo>();
  
            foreach (var item in sourceTypes)
            {
                if (item == typeof(Object)) { continue; }

                foreach (var p in item.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(el => el.GetIndexParameters().Length == 0))
                {
                    if (p.GetGetMethod() == null) { continue; }
                    if (p.Name == "SyncRoot" && p.PropertyType == typeof(Object)) { continue; }
                    if (p.PropertyType.Name != nameof(String))
                    {
                        if (p.PropertyType.IsArray || p.PropertyType.IsIEnumerableT()) { continue; }
                    }
                    if (sourcePropertyList.Exists(el => el.Name == p.Name)) { continue; }
 
                    //Add to list when this property declared on this class.
                    //Not Add when this property declared on parent class because it will added on declared class.
                    if (p.DeclaringType == item)
                    {
                        sourcePropertyList.Add(p);
                    }
                }
            }
            foreach (var item in targetTypes)
            {
                if (item == typeof(Object)) { continue; }

                foreach (var p in item.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    if (p.Name == "SyncRoot" && p.PropertyType == typeof(Object)) { continue; }
                    if (targetPropertyList.Exists(el => el.Name == p.Name)) { continue; }
                    if (p.PropertyType.Name != nameof(String))
                    {
                        if (p.PropertyType.IsArray || p.PropertyType.IsICollectionT()) { continue; }
                    }

                    //Add to list when this property declared on this class.
                    //Not Add when this property declared on parent class because it will added on declared class.
                    if (p.DeclaringType == item)
                    {
                        targetPropertyList.Add(p);
                    }
                }
            }

            foreach (var targetProperty in targetPropertyList)
            {
                var sourceProperty = sourcePropertyList.Find(el => el.Name == targetProperty.Name);
                if (sourceProperty == null) { continue; }

                var isMap = false;
                if (sourceProperty.PropertyType.IsInheritanceFrom(targetProperty.PropertyType))
                {
                    isMap = true;
                }
                else if (ParseMethodList.HasParseMethod(targetProperty.PropertyType))
                {
                    isMap = true;
                }
                else if (sourceProperty.PropertyType.IsClass && targetProperty.PropertyType.IsClass)
                {
                    isMap = true;
                }

                if (isMap == true)
                {
                    pp.Add((sourceProperty, targetProperty));
                }
            }
            return pp;
        }
        private List<(PropertyInfo source, PropertyInfo target)> CreateCollectionPropertyMapping(Type sourceType, Type targetType)
        {
            var pp = new List<(PropertyInfo, PropertyInfo)>();

            var sourceTypes = new List<Type>();
            sourceTypes.Add(sourceType);
            sourceTypes.AddRange(sourceType.GetBaseClasses());
            sourceTypes.AddRange(sourceType.GetInterfaces());
            var targetTypes = new List<Type>();
            targetTypes.Add(targetType);
            targetTypes.AddRange(targetType.GetBaseClasses());
            targetTypes.AddRange(targetType.GetInterfaces());

            var sourcePropertyList = new List<PropertyInfo>();
            var targetPropertyList = new List<PropertyInfo>();

            foreach (var item in sourceTypes)
            {
                if (item == typeof(Object)) { continue; }

                foreach (var p in item.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    if (p.GetGetMethod() == null) { continue; }
                    if (p.PropertyType.Name == nameof(String)) { continue; }
                    if (p.Name == "SyncRoot" && p.PropertyType == typeof(Object)) { continue; }
                    if (sourcePropertyList.Exists(el => el.Name == p.Name)) { continue; }

                    //Check source is IEnumerable
                    if (p.PropertyType.IsArray == false && p.PropertyType.IsIEnumerableT() == false) { continue; }

                    sourcePropertyList.Add(p);
                }
            }
            foreach (var item in targetTypes)
            {
                if (item == typeof(Object)) { continue; }

                foreach (var p in item.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    if (p.Name == "SyncRoot" && p.PropertyType == typeof(Object)) { continue; }
                    if (p.PropertyType.Name == nameof(String)) { continue; }
                    if (targetPropertyList.Exists(el => el.Name == p.Name)) { continue; }
                    //Check source is ICollection
                    if (p.PropertyType.IsArray == false && p.PropertyType.IsICollectionT() == false) { continue; }

                    //Add to list when this property declared on this class.
                    //Not Add when this property declared on parent class because it will added on declared class.
                    if (p.DeclaringType == item)
                    {
                        targetPropertyList.Add(p);
                    }
                }
            }
            foreach (var targetProperty in targetPropertyList)
            {
                var sourceProperty = sourcePropertyList.Find(el => el.Name == targetProperty.Name);
                if (sourceProperty == null) { continue; }

                pp.Add((sourceProperty, targetProperty));
            }
            return pp;
        }
        private List<(PropertyInfo source, PropertyInfo target)> CreatePropertyToDictionaryMapping(Type sourceType)
        {
            var targetType = typeof(Dictionary<String, Object>);
            var pp = new List<(PropertyInfo, PropertyInfo)>();

            var sourceTypes = new List<Type>();
            sourceTypes.Add(sourceType);
            sourceTypes.AddRange(sourceType.GetBaseClasses());
            sourceTypes.AddRange(sourceType.GetInterfaces());

            var sourcePropertyList = new List<PropertyInfo>();

            foreach (var item in sourceTypes)
            {
                if (item == typeof(Object)) { continue; }

                foreach (var p in item.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    if (p.GetGetMethod() == null) { continue; }
                    if (p.Name == "SyncRoot" && p.PropertyType == typeof(Object)) { continue; }
                    if (sourcePropertyList.Exists(el => el.Name == p.Name)) { continue; }

                    //Add to list when this property declared on this class.
                    //Not Add when this property declared on parent class because it will added on declared class.
                    if (p.DeclaringType == item)
                    {
                        sourcePropertyList.Add(p);
                    }
                }
            }
            var targetProperty = targetType.GetProperty("Item");

            foreach (var sourceProperty in sourcePropertyList)
            {
                pp.Add((sourceProperty, targetProperty));
            }
            return pp;
        }
        private List<(PropertyInfo source, PropertyInfo target)> CreatePropertyFromDictionaryMapping(Type targetType)
        {
            var sourceType = typeof(Dictionary<String, Object>);
            var pp = new List<(PropertyInfo, PropertyInfo)>();
       
            var targetTypes = new List<Type>();
            targetTypes.Add(targetType);
            targetTypes.AddRange(targetType.GetBaseClasses());
            targetTypes.AddRange(targetType.GetInterfaces());

            var targetPropertyList = new List<PropertyInfo>();

            foreach (var item in targetTypes)
            {
                if (item == typeof(Object)) { continue; }

                foreach (var p in item.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    if (p.Name == "SyncRoot" && p.PropertyType == typeof(Object)) { continue; }
                    if (targetPropertyList.Exists(el => el.Name == p.Name)) { continue; }

                    //Add to list when this property declared on this class.
                    //Not Add when this property declared on parent class because it will added on declared class.
                    if (p.DeclaringType == item)
                    {
                        targetPropertyList.Add(p);
                    }
                }
            }
            var sourceProperty = sourceType.GetProperty("Item");

            foreach (var targetProperty in targetPropertyList)
            {
                pp.Add((sourceProperty, targetProperty));
            }
            return pp;
        }

        private LambdaExpression CreateFunctionExpression(Type sourceType, Type targetType, MapContext context)
        {
            var p = new MapParameterList();
            p.Source = Expression.Parameter(sourceType, "source");
            p.Target = Expression.Parameter(targetType, "target");
            p.Context = Expression.Parameter(typeof(MapContext), "mapContext");

            var ee = new List<Expression>();
            if (sourceType == typeof(Dictionary<String, String>))
            {
                foreach (var item in CreateMapFromDictionaryExpression(targetType, p))
                {
                    ee.Add(item);
                }
            }
            if (targetType == typeof(Dictionary<String, Object>))
            {
                foreach (var item in CreateMapToDictionaryExpression(sourceType, p))
                {
                    ee.Add(item);
                }
            }
            else
            {
                foreach (var item in CreateMapExpression(sourceType, targetType, p))
                {
                    ee.Add(item);
                }
                if (this.CompilerConfig.CollectionElementMapMode != CollectionElementMapMode.None)
                {
                    foreach (var item in CreateMapCollectionExpression(sourceType, targetType, context, p))
                    {
                        ee.Add(item);
                    }
                }
            }
            //Return value
            ee.Add(p.Target);

            BlockExpression block = Expression.Block(ee);
            LambdaExpression lambda = Expression.Lambda(block, new[] { p.Source, p.Target, p.Context });
            return lambda;
        }

        private List<Expression> CreateMapExpression(Type sourceType, Type targetType, MapParameterList parameterList)
        {
            var ee = new List<Expression>();
            var p = parameterList;
            var mapperMember = Expression.PropertyOrField(p.Context, "Mapper");

            var pp = CreatePropertyMapping(sourceType, targetType);
            foreach (var item in pp)
            {
                var sourceProperty = item.source;
                var targetProperty = item.target;
                if (sourceType.GetProperty(sourceProperty.Name) == null) { continue; }
                MemberExpression getMethod = Expression.PropertyOrField(p.Source, sourceProperty.Name);
                var setMethod = targetProperty.GetSetMethod();
                if (setMethod == null) { continue; }

                if (sourceProperty.PropertyType == targetProperty.PropertyType)
                {
                    if (targetProperty.PropertyType.IsValueType)
                    {
                        var body = Expression.Call(p.Target, setMethod, getMethod);
                        ee.Add(body);
                    }
                    else if (this.CompilerConfig.ClassPropertyMapMode != ClassPropertyMapMode.None)
                    {
                        var body = Expression.Call(p.Target, setMethod, getMethod);
                        ee.Add(body);
                    }
                }
                else if (targetProperty.PropertyType == typeof(Encoding))
                {
                    var parseMethod = _ParseOrNullMethodList[nameof(Encoding)];
                    var getTargetValueMethod = targetProperty.GetGetMethod();
                    var parse = Expression.Call(parseMethod, getMethod, Expression.Call(p.Target, getTargetValueMethod));
                    var body = Expression.Call(p.Target, setMethod, parse);
                    ee.Add(body);
                }
                else if (sourceProperty.PropertyType.IsClass && targetProperty.PropertyType.IsClass)
                {
                    var targetConstructor = targetProperty.PropertyType.GetConstructor(Type.EmptyTypes);
                    if (targetConstructor != null)
                    {
                        var body = Expression.Call(p.Target, setMethod
                            , Expression.Call(mapperMember, "Map"
                            , new Type[] { sourceProperty.PropertyType, targetProperty.PropertyType }
                            , getMethod, p.Context));
                        ee.Add(body);
                    }
                }
                else if (targetProperty.PropertyType.IsNullable())
                {
                    var targetNullableGenericType = targetProperty.PropertyType.GetGenericArguments()[0];
                    if (sourceProperty.PropertyType.IsNullable())
                    {
                        var sourceNullableGenericType = sourceProperty.PropertyType.GetGenericArguments()[0];
                        if (sourceNullableGenericType == targetNullableGenericType)
                        {
                            var body = Expression.Call(p.Target, setMethod, getMethod);
                            ee.Add(body);
                        }
                        else if (CanConvert(sourceNullableGenericType, targetNullableGenericType))
                        {
                            var body = Expression.Call(p.Target, setMethod
                                , Expression.Convert(getMethod, targetProperty.PropertyType));
                            ee.Add(body);
                        }
                    }
                    else
                    {
                        if (sourceProperty.PropertyType == targetNullableGenericType)
                        {
                            //Int32 --> Nullable<Int32>
                            var body = Expression.Call(p.Target, setMethod
                                , Expression.TypeAs(getMethod, targetProperty.PropertyType));
                            ee.Add(body);
                        }
                        else if (CanConvert(sourceProperty.PropertyType, targetNullableGenericType))
                        {
                            var body = Expression.Call(p.Target, setMethod
                                , Expression.Convert(getMethod, targetProperty.PropertyType));
                            ee.Add(body);
                        }
                    }
                }
                else if (sourceProperty.PropertyType == typeof(String) && ParseMethodList.HasParseMethod(targetProperty.PropertyType))
                {
                    var parseMethod = _ParseMethodList[targetProperty.PropertyType.Name];
                    var parse = Expression.Call(parseMethod, getMethod, Expression.Default(targetProperty.PropertyType));
                    var body = Expression.Call(p.Target, setMethod, parse);
                    ee.Add(body);
                }
                else if (CanConvert(sourceProperty.PropertyType, targetProperty.PropertyType))
                {
                    if (sourceProperty.PropertyType.IsNullable())
                    {
                    }
                    else
                    {
                        var body = Expression.Call(p.Target, setMethod
                            , Expression.Convert(getMethod, targetProperty.PropertyType));
                        ee.Add(body);
                    }
                }
            }
            LabelTarget returnTarget = Expression.Label();
            GotoExpression returnExpression = Expression.Return(returnTarget);
            LabelExpression returnLabel = Expression.Label(returnTarget);
            BlockExpression block = Expression.Block(returnExpression, returnLabel);
            ee.Add(block);

            return ee;
        }

        private List<Expression> CreateMapCollectionExpression(Type sourceType, Type targetType, MapContext context, MapParameterList parameterList)
        {
            var p = parameterList;

            var ee = new List<Expression>();
            var pp = this.CreateCollectionPropertyMapping(sourceType, targetType);
            if (pp.Count == 0) { return ee; }

            var mapperMember = Expression.PropertyOrField(p.Context, "Mapper");

            foreach (var item in pp)
            {
                var sourceProperty = item.source;
                var targetProperty = item.target;
                var targetElementType = targetProperty.PropertyType.GetCollectionElementType();

                var sourceMember = Expression.PropertyOrField(p.Source, sourceProperty.Name);
                var targetMember = Expression.PropertyOrField(p.Target, targetProperty.Name);
                var sourceElementType = sourceProperty.PropertyType.GetCollectionElementType();

                if (targetProperty.PropertyType.IsArray)
                {
                    var targetCostructor = targetElementType.GetConstructor(Type.EmptyTypes);
                    if (targetCostructor == null)
                    {
                        if (sourceProperty.PropertyType.IsArray)
                        {

                        }
                    }
                    else
                    {
                        BinaryExpression setTarget = Expression.Assign(targetMember
                            , Expression.Call(mapperMember, "MapToArray"
                            , new Type[] { sourceElementType, targetElementType }
                            , sourceMember, p.Context));
                        ee.Add(setTarget);
                    }
                }
                else
                {
                    if (this.CompilerConfig.CollectionElementMapMode == CollectionElementMapMode.NewObject)
                    {
                        var targetSetMethod = targetProperty.GetSetMethod();
                        if (targetSetMethod != null)
                        {
                            var ifThen = Expression.IfThen(Expression.Equal(targetMember, Expression.Default(targetProperty.PropertyType))
                                , Expression.Call(p.Target, targetSetMethod, Expression.New(targetProperty.PropertyType)));
                            ee.Add(ifThen);
                        }
                    }
                    MethodCallExpression setTarget = Expression.Call(mapperMember, "MapToCollection"
                        , new Type[] { sourceElementType, targetElementType }
                        , sourceMember, targetMember, p.Context);
                    ee.Add(setTarget);
                }
            }
            LabelTarget returnTarget = Expression.Label();
            GotoExpression returnExpression = Expression.Return(returnTarget);
            LabelExpression returnLabel = Expression.Label(returnTarget);
            BlockExpression block = Expression.Block(returnExpression, returnLabel);
            ee.Add(block);

            return ee;
        }
        public void MapToCollection<TSource, TTarget>(IEnumerable<TSource> source, ICollection<TTarget> target, MapContext context)
            where TTarget : new()
        {
            if (source == null || target == null) { return; }

            target.Clear();
            if (source is TSource[] ss)
            {
                for (int i = 0; i < ss.Length; i++)
                {
                    target.Add(this.Map(ss[i], new TTarget(), context));
                }
            }
            else if (source is IList<TSource> sList)
            {
                for (int i = 0; i < sList.Count; i++)
                {
                    target.Add(this.Map(sList[i], new TTarget(), context));
                }
            }
            else
            {
                foreach (var item in source)
                {
                    target.Add(this.Map(item, new TTarget(), context));
                }
            }
        }
        public TTarget[] MapToArray<TSource, TTarget>(IEnumerable<TSource> source, MapContext context)
            where TTarget : new()
        {
            if (source == null) { return null; }

            if (source is TSource[] ss)
            {
                var tt = new TTarget[ss.Length];
                for (int i = 0; i < ss.Length; i++)
                {
                    tt[i] = this.Map(ss[i], new TTarget(), context);
                }
                return tt;
            }
            else if (source is IList<TSource> sList)
            {
                var tt = new TTarget[sList.Count];
                for (int i = 0; i < sList.Count; i++)
                {
                    tt[i] = this.Map(sList[i], new TTarget(), context);
                }
                return tt;
            }
            else if (source is ICollection<TSource> sCollection)
            {
                var tt = new TTarget[sCollection.Count];
                var index = 0;
                foreach (var item in sCollection)
                {
                    tt[index++] = this.Map(item, new TTarget(), context);
                }
                return tt;
            }
            else
            {
                return source.Select(el => this.Map(el, new TTarget(), context)).ToArray();
            }
        }

        private List<Expression> CreateMapToDictionaryExpression(Type sourceType, MapParameterList parameterList)
        {
            var ee = new List<Expression>();
            var p = parameterList;
            var mapperMember = Expression.PropertyOrField(p.Context, "Mapper");

            var pp = CreatePropertyToDictionaryMapping(sourceType);
            foreach (var item in pp)
            {
                var sourceProperty = item.Item1;
                var targetProperty = item.Item2;
                if (sourceType.GetProperty(sourceProperty.Name) == null) { continue; }
                MemberExpression getMethod = Expression.PropertyOrField(p.Source, sourceProperty.Name);
                var addMethod = typeof(Dictionary<String, Object>).GetMethod("Add");

                {
                    var removeMethod = typeof(Dictionary<String, Object>).GetMethod("Remove", new Type[] { typeof(String) });
                    var body = Expression.Call(p.Target, removeMethod, Expression.Constant(sourceProperty.Name));
                    ee.Add(body);
                }
                if (sourceProperty.PropertyType.IsValueType)
                {
                    var body = Expression.Call(p.Target, addMethod, Expression.Constant(sourceProperty.Name)
                        , Expression.TypeAs(getMethod, typeof(Object)));
                    ee.Add(body);
                }
                else
                {
                    var body = Expression.Call(p.Target, addMethod, Expression.Constant(sourceProperty.Name), getMethod);
                    ee.Add(body);
                }
            }
            LabelTarget returnTarget = Expression.Label();
            GotoExpression returnExpression = Expression.Return(returnTarget);
            LabelExpression returnLabel = Expression.Label(returnTarget);
            BlockExpression block = Expression.Block(returnExpression, returnLabel);
            ee.Add(block);

            return ee;
        }

        private List<Expression> CreateMapFromDictionaryExpression(Type targetType, MapParameterList parameterList)
        {
            var ee = new List<Expression>();
            var p = parameterList;
            var mapperMember = Expression.PropertyOrField(p.Context, "Mapper");
            var containsKeyMethod = typeof(Dictionary<String, String>).GetMethod("ContainsKey", new Type[] { typeof(String) });
            var tryGetMethod = typeof(ObjectMapper).GetMethod("TryGetValue", BindingFlags.NonPublic | BindingFlags.Static);

            var pp = CreatePropertyFromDictionaryMapping(targetType);
            foreach (var item in pp)
            {
                var sourceProperty = item.Item1;
                var targetProperty = item.Item2;
                var getMethod = Expression.Call(tryGetMethod, p.Source, Expression.Constant(targetProperty.Name));
                var setMethod = targetProperty.GetSetMethod();
                if (setMethod == null) { continue; }

                if (targetProperty.PropertyType == typeof(String))
                {
                    var body = Expression.IfThen(Expression.Call(p.Source, containsKeyMethod, Expression.Constant(targetProperty.Name))
                        , Expression.Call(p.Target, setMethod, getMethod));
                    ee.Add(body);
                }
                else if (targetProperty.PropertyType == typeof(Encoding))
                {
                    var parseMethod = _ParseOrNullMethodList[nameof(Encoding)];
                    var getTargetValueMethod = targetProperty.GetGetMethod();
                    var parse = Expression.Call(parseMethod, getMethod, Expression.Call(p.Target, getTargetValueMethod));
                    var body = Expression.Call(p.Target, setMethod, parse);
                    ee.Add(body);
                }
                else if (ParseMethodList.HasParseMethod(targetProperty.PropertyType))
                {
                    var parseMethod = _ParseMethodList[targetProperty.PropertyType.Name];
                    var getTargetValueMethod = targetProperty.GetGetMethod();
                    var parse = Expression.Call(parseMethod, getMethod, Expression.Call(p.Target, getTargetValueMethod));
                    var body = Expression.Call(p.Target, setMethod, parse);
                    ee.Add(body);
                }
                else if (targetProperty.PropertyType.IsNullable())
                {
                    var targetNullableGenericType = targetProperty.PropertyType.GetGenericArguments()[0];
                    if (ParseMethodList.HasParseMethod(targetNullableGenericType))
                    {
                        var parseMethod = _ParseOrNullMethodList[targetNullableGenericType.Name];
                        var parse = Expression.Call(parseMethod, getMethod, Expression.Default(targetProperty.PropertyType));
                        var body = Expression.Call(p.Target, setMethod, parse);
                        ee.Add(body);
                    }
                }
            }
            LabelTarget returnTarget = Expression.Label();
            GotoExpression returnExpression = Expression.Return(returnTarget);
            LabelExpression returnLabel = Expression.Label(returnTarget);
            BlockExpression block = Expression.Block(returnExpression, returnLabel);
            ee.Add(block);

            return ee;
        }

        private static String TryGetValue(Dictionary<String, String> dictionary, String key)
        {
            if (dictionary.TryGetValue(key, out var value)) { return value; }
            return "";
        }
        private static Boolean CanConvert(Type sourceType, Type targetType)
        {
            if (_CanConvertList.TryGetValue(new ActionKey(sourceType, targetType), out var result)) { return result; }
            return false;
        }
    }
    public static class TypeExtensions
    {
        private static readonly String System_Collections_Generic_ICollection_1 = "System.Collections.Generic.ICollection`1";
        private static readonly String System_Collections_Generic_IEnumerable_1 = "System.Collections.Generic.IEnumerable`1";

        public static Boolean IsIEnumerableT(this Type type)
        {
            return type.FullName.StartsWith(System_Collections_Generic_IEnumerable_1) ||
                type.GetInterfaces().Any(tp => tp.FullName.StartsWith(System_Collections_Generic_IEnumerable_1));
        }
        public static Boolean IsICollectionT(this Type type)
        {
            return type.FullName.StartsWith(System_Collections_Generic_ICollection_1) ||
                type.GetInterfaces().Any(tp => tp.FullName.StartsWith(System_Collections_Generic_ICollection_1));
        }
        public static Boolean IsNullable(this Type type)
        {
            return type.FullName.StartsWith("System.Nullable`1[");
        }
        public static Boolean IsNumber(Type type)
        {
            return type == typeof(SByte) || type == typeof(Int16) || type == typeof(Int32) || type == typeof(Int64) ||
                type == typeof(Byte) || type == typeof(UInt16) || type == typeof(UInt32) || type == typeof(UInt64) ||
                type == typeof(Single) || type == typeof(Double) || type == typeof(Decimal);
        }
        public static Type GetCollectionElementType(this Type type)
        {
            if (type.IsArray) { type.GetElementType(); }
            if (IsGenericEnumerableType(type)) { return type.GetGenericArguments()[0]; }
            var arrayType = Array.Find(type.GetInterfaces(), IsGenericEnumerableType);
            if (arrayType == null) { return typeof(Object); }
            return arrayType.GetGenericArguments()[0];
        }
        private static Boolean IsGenericEnumerableType(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>);
        }
    }
}
