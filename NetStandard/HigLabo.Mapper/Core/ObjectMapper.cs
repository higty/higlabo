using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;

namespace HigLabo.Core
{
    public class ObjectMapper
    {
        private struct ActionKey : IEquatable<ActionKey>
        {
            public Type Source { get; private set; }
            public Type Target { get; private set; }

            public ActionKey(Type source, Type target)
            {
                this.Source = source;
                this.Target = target;
            }

            public bool Equals(ActionKey obj)
            {
                return Source == obj.Source && Target == obj.Target;
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
                    var h2 = Target.GetHashCode();
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

            public override string ToString()
            {
                return String.Format("{0} - {1}", this.Source.Name, this.Target.Name);
            }
        }
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
            [MapperMethod]
            public static T Enum<T>(String value, T defaultValue)
                where T : struct
            {
                if (System.Enum.TryParse<T>(value, out var v)) { return v; }
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
            public static T? Enum<T>(String value, T? defaultValue)
                where T: struct
            {
                if (System.Enum.TryParse<T>(value, out var v)) { return v; }
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
                return defaultValue;
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
        private class MapParameter
        {
            public Type SourceType { get; set; }
            public Type TargetType { get; set; }
            public Expression Source { get; set; }
            public Expression Target { get; set; }
        }
        private class CompileState
        {
            public Int32 Layer { get; set; } = 0;
        }

        private static readonly Dictionary<String, MethodInfo> _ParseMethodList = new Dictionary<string, MethodInfo>();
        private static readonly Dictionary<String, MethodInfo> _DictionaryMethodList = new Dictionary<string, MethodInfo>();
        private static readonly Dictionary<String, MethodInfo> _ParseOrNullMethodList = new Dictionary<string, MethodInfo>();
        private static readonly Dictionary<ActionKey, Boolean> _CanConvertList = new Dictionary<ActionKey, bool>();
        private static readonly MethodInfo _ToStringMethod = typeof(Object).GetMethod("ToString");
        private static readonly MethodInfo _ValueTypeToString = typeof(ObjectMapper).GetMethod("ValueTypeToString", BindingFlags.NonPublic | BindingFlags.Static);

        public static ObjectMapper Default { get; private set; } = new ObjectMapper();

        private IDictionary<ActionKey, Delegate> _MapActionList = new Dictionary<ActionKey, Delegate>(100);

        public CompilerSetting CompilerConfig { get; private set; } = new CompilerSetting();

        static ObjectMapper()
        {
            InitializeParseMethodList();
            InitializeDictionaryMethodList();
            InitializeCanConvertList();
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
        private static void InitializeDictionaryMethodList()
        {
            _DictionaryMethodList.Add("MapDictionary_String_String", typeof(ObjectMapper).GetMethod("MapDictionary_String_String"));
            _DictionaryMethodList.Add("MapDictionary_String_Object", typeof(ObjectMapper).GetMethod("MapDictionary_String_Object"));
            _DictionaryMethodList.Add("MapDictionary_Object_String", typeof(ObjectMapper).GetMethod("MapDictionary_Object_String"));
            _DictionaryMethodList.Add("MapDictionary_Object_Object", typeof(ObjectMapper).GetMethod("MapDictionary_Object_Object"));
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
            if (source == null || target == null) { return target; }

            var key = new ActionKey(source.GetType(), target.GetType());
            if (_MapActionList.TryGetValue(key, out var func) == false)
            {
                func = CreateMapMethod(key.Source, key.Target);
                _MapActionList[key] = func;
            }
#if DEBUG
            return ((Func<Object, Object, TTarget>)func)(source, target);
#else
            try
            {
                return ((Func<Object, Object, TTarget>)func)(source, target);
            }
            catch (Exception ex)
            {
                var ex1 = new ObjectMapFailureException("Generated map method was failed.Maybe HigLabo.Mapper bug."
                        + "Please notify SouceObject,TargetObject class of this ObjectMapFailureException object to GitHub issue." + Environment.NewLine
                        + "https://github.com/higty/higlabo" + Environment.NewLine
                        + "We will fix it. You can avoid this issue by using ReplaceMap method temporary." + Environment.NewLine
                        + String.Format("SourceType={0}, TargetType={1}", source.GetType().Name, target.GetType().Name)
                        , source, target, ex);
                ExceptionDispatchInfo.Capture(ex1).Throw();
            }
            throw new InvalidOperationException();
#endif
        }
        public TTarget MapOrNull<TSource, TTarget>(TSource source, Func<TTarget> func)
            where TTarget : class
        {
            if (source == null) { return null; }
            return Map(source, func());
        }
        public TTarget MapOrNull<TSource, TTarget>(TSource source, TTarget target)
            where TTarget: class
        {
            if (source == null) { return null; }
            return Map(source, target);
        }
        public void AddPostAction<TSource, TTarget>(Action<TSource, TTarget> action)
        {
            var key = new ActionKey(typeof(TSource), typeof(TTarget));
            if (_MapActionList.TryGetValue(key, out var defaultMapFunc) == false)
            {
                defaultMapFunc = CreateMapMethod(typeof(TSource), typeof(TTarget));
                _MapActionList[key] = defaultMapFunc;
            }
            Func<Object, Object, TTarget> newMapFunc = (source, target) =>
            {
                var t = ((Func<Object, Object, TTarget>)defaultMapFunc)(source, target);
                action((TSource)source, (TTarget)target);
                return t;
            };
            _MapActionList[key] = newMapFunc;
        }
        public void ReplaceMap<TSource, TTarget>(Func<TSource, TTarget, TTarget> func)
        {
            Func<Object, Object, TTarget> newMapFunc = (source, target) =>
            {
                return func((TSource)source, (TTarget)target);
            };
            _MapActionList[new ActionKey(typeof(TSource), typeof(TTarget))] = newMapFunc;
        }
        /// <summary>
        /// Set thread mode of Map method.
        /// If you call this method, all customize by AddPostAction and ReplaceMap will be cleared.
        /// So, you should call this method on initialization process of application.
        /// 
        /// ThreadMode.Performance is not thread safe.This mode may be used on desktop, console application.
        /// ThreadMode.ThreadSafe is thread safe mode from multithreading environment like web application.
        /// If Mode is ThreadMode.ThreadSafe, the performance goes a little bit worse.
        /// It may be 10%-20% slower than ThreadMode.Performance when you call Map method.
        /// This method will set ConcurrentDictionary to private _MapActionList field to manage action list.
        /// Be careful that you must call this method before calling AddPostAction, ReplaceMap method.
        /// </summary>
        public void SetThreadMode(ThreadMode mode)
        {
            switch (mode)
            {
                case ThreadMode.Performance:_MapActionList = new Dictionary<ActionKey, Delegate>(100); break;
                case ThreadMode.ThreadSafe:_MapActionList = new ConcurrentDictionary<ActionKey, Delegate>();break;
                default:throw new InvalidOperationException();
            }
        }

        private Delegate CreateMapMethod(Type sourceType, Type targetType)
        {
            var lambda = CreateFunctionExpression(sourceType, targetType);
            return lambda.Compile();
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

                foreach (var p in item.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    if (p.DeclaringType == typeof(Object)) { continue; }
                    if (p.GetGetMethod() == null) { continue; }
                    if (p.PropertyType.Name != nameof(String) && p.PropertyType.IsDictionary() == false)
                    {
                        if (p.PropertyType.IsArray || p.PropertyType.IsIEnumerableT()) { continue; }
                    }
                    if (sourcePropertyList.Exists(el => el.Name == p.Name)) { continue; }
                    //Exclude indexer. userList[2] of List<T> class.
                    if (p.Name == "Item" && p.GetMethod.GetParameters().Length > 0) { continue; }
 
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
                    if (p.DeclaringType == typeof(Object)) { continue; }
                    if (targetPropertyList.Exists(el => el.Name == p.Name)) { continue; }
                    if (p.PropertyType.Name != nameof(String) && p.PropertyType.IsDictionary() == false)
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
                var sourceProperty = sourcePropertyList.Find(el => this.CompilerConfig.MatchProperty(sourceType, el, targetType, targetProperty));
                if (sourceProperty == null) { continue; }

                pp.Add((sourceProperty, targetProperty));
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
                    if (p.PropertyType.Name == "Dictionary`2" || p.PropertyType.Name == "IDictionary`2") { continue; }
                    if (p.DeclaringType == typeof(Object)) { continue; }
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
                    if (p.PropertyType.Name == nameof(String)) { continue; }
                    if (p.PropertyType.Name == "Dictionary`2" || p.PropertyType.Name == "IDictionary`2") { continue; }
                    if (p.DeclaringType == typeof(Object)) { continue; }
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
                var sourceProperty = sourcePropertyList.Find(el => this.CompilerConfig.MatchProperty(sourceType, el, targetType, targetProperty));
                if (sourceProperty == null) { continue; }

                pp.Add((sourceProperty, targetProperty));
            }
            return pp;
        }
        private List<(PropertyInfo source, PropertyInfo target)> CreatePropertyToDictionaryMapping(Type sourceType, Type targetType)
        {
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
        private List<(PropertyInfo source, PropertyInfo target)> CreatePropertyFromDictionaryMapping(Type sourceType, Type targetType)
        {
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

        private LambdaExpression CreateFunctionExpression(Type sourceType, Type targetType)
        {
            var p = new MapParameter();
            var sourceParameter = Expression.Parameter(typeof(Object), "sourceParameter");
            var targetParameter = Expression.Parameter(typeof(Object), "targetParameter");

            var ee = new List<Expression>();
            p.SourceType = sourceType;
            p.TargetType = targetType;
            p.Source = Expression.Variable(sourceType, "source");
            p.Target = Expression.Variable(targetType, "target");

            if (sourceType.IsValueType)
            {
                ee.Add(Expression.Assign(p.Source, Expression.Unbox(sourceParameter, sourceType)));
            }
            else
            {
                ee.Add(Expression.Assign(p.Source, Expression.TypeAs(sourceParameter, sourceType)));
            }
            if (targetType.IsValueType)
            {
                ee.Add(Expression.Assign(p.Target, Expression.Unbox(targetParameter, targetType)));
            }
            else
            {
                ee.Add(Expression.Assign(p.Target, Expression.TypeAs(targetParameter, targetType)));
            }

            if (sourceType.GetInterfaces().Any(el => el == typeof(IDictionary<String, String>) || el == typeof(IDictionary<String, Object>)))
            {
                if (targetType.GetInterfaces().Any(el => el == typeof(IDictionary<String, String>) || targetType == typeof(IDictionary<String, Object>)))
                {
                    var methodName = String.Format("MapDictionary_{0}_{1}"
                        , sourceType.GetGenericArguments()[1].Name
                        , targetType.GetGenericArguments()[1].Name);
                    var body = Expression.Call(_DictionaryMethodList[methodName], p.Source, p.Target);
                    ee.Add(body);
                }
                else
                {
                    foreach (var item in CreateMapFromDictionaryExpression(sourceType, targetType, p))
                    {
                        ee.Add(item);
                    }
                }
            }
            else if (targetType.GetInterfaces().Any(el => el == typeof(IDictionary<String, String>) || el == typeof(IDictionary<String, Object>)))
            {
                foreach (var item in CreateMapToDictionaryExpression(p))
                {
                    ee.Add(item);
                }
            }
            else
            {
                var state = new CompileState();
                foreach (var item in ValidateCompileStateAndCreateMapPropertyExpression(p, state))
                {
                    ee.Add(item);
                }
                foreach (var item in CreateMapCollectionExpression(p, state))
                {
                    ee.Add(item);
                }
            }
            //Return value
            ee.Add(p.Target);

            BlockExpression block = Expression.Block(new[] { p.Source as ParameterExpression, p.Target as ParameterExpression }, ee);
            LambdaExpression lambda = Expression.Lambda(block, new[] { sourceParameter, targetParameter });
            return lambda;
        }

        private List<Expression> ValidateCompileStateAndCreateMapPropertyExpression(MapParameter parameter, CompileState state)
        {
            if (state.Layer > this.CompilerConfig.ChildPropertyRecursiveCount) { return new List<Expression>(); }
            state.Layer = state.Layer + 1;
            var ee = CreateMapPropertyExpression(parameter, state);
            state.Layer = state.Layer - 1;
            return ee;
        }

        private List<Expression> CreateMapPropertyExpression(MapParameter parameter, CompileState state)
        {
            var ee = new List<Expression>();
            var p = parameter;
            var sourceType = p.SourceType;
            var targetType = p.TargetType;
            if (sourceType == typeof(String) || targetType == typeof(String)) { return ee; }

            var pp = CreatePropertyMapping(sourceType, targetType);
            foreach (var item in pp)
            {
                var sourceProperty = item.source;
                var targetProperty = item.target;
                if (sourceType.GetProperty(sourceProperty.Name) == null) { continue; }
          
                MemberExpression getMethod = Expression.Property(p.Source, sourceProperty);
                var setMethod = targetProperty.GetSetMethod();
                if (setMethod == null) { continue; }

                if (sourceProperty.PropertyType == targetProperty.PropertyType)
                {
                    if (targetProperty.PropertyType.IsValueType)
                    {
                        var body = Expression.Call(p.Target, setMethod, getMethod);
                        ee.Add(body);
                        continue;
                    }
                    else if (targetProperty.PropertyType == typeof(String))
                    {
                        var body = Expression.Call(p.Target, setMethod, getMethod);
                        ee.Add(body);
                        continue;
                    }
                    else
                    {

                    }
                }


                if (sourceProperty.PropertyType == typeof(String))
                {
                    if (targetProperty.PropertyType.IsNullable())
                    {
                        var targetNullableGenericType = targetProperty.PropertyType.GetGenericArguments()[0];
                        if (ParseMethodList.HasParseMethod(targetNullableGenericType))
                        {
                            var targetGetMethod = targetProperty.GetGetMethod();
                            var parseMethod = _ParseMethodList[targetNullableGenericType.Name];
                            var parse = Expression.Call(parseMethod, getMethod, Expression.Call(p.Target, targetGetMethod));
                            var body = Expression.Call(p.Target, setMethod, parse);
                            ee.Add(body);
                        }
                        else if (targetNullableGenericType.IsEnum)
                        {
                            var parseMethod = _ParseOrNullMethodList[nameof(Enum)].MakeGenericMethod(targetNullableGenericType);
                            var getTargetValueMethod = targetProperty.GetGetMethod();
                            var parse = Expression.Call(parseMethod, getMethod, Expression.Call(p.Target, getTargetValueMethod));
                            var body = Expression.Call(p.Target, setMethod, parse);
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
                    else
                    {
                        if (ParseMethodList.HasParseMethod(targetProperty.PropertyType))
                        {
                            var targetGetMethod = targetProperty.GetGetMethod();
                            var parseMethod = _ParseMethodList[targetProperty.PropertyType.Name];
                            var parse = Expression.Call(parseMethod, getMethod, Expression.Call(p.Target, targetGetMethod));
                            var body = Expression.Call(p.Target, setMethod, parse);
                            ee.Add(body);
                        }
                        else if (targetProperty.PropertyType.IsEnum)
                        {
                            var parseMethod = _ParseMethodList[nameof(Enum)].MakeGenericMethod(targetProperty.PropertyType);
                            var getTargetMethod = targetProperty.GetGetMethod();
                            var parse = Expression.Call(parseMethod, getMethod, Expression.Call(p.Target, getTargetMethod));
                            var body = Expression.Call(p.Target, setMethod, parse);
                            ee.Add(body);
                        }
                    }

                }
                else if (sourceProperty.PropertyType.IsClass && targetProperty.PropertyType.IsClass)
                {
                    switch (this.CompilerConfig.ClassPropertyCreateMode)
                    {
                        case ClassPropertyCreateMode.None: break;
                        case ClassPropertyCreateMode.NewObject:
                            var targetConstructor = targetProperty.PropertyType.GetConstructor(Type.EmptyTypes);
                            if (targetConstructor != null)
                            {
                                var sourceMember = Expression.Property(p.Source, sourceProperty);
                                var targetMember = Expression.Property(p.Target, targetProperty);
                                var elementParameter = new MapParameter();
                                elementParameter.SourceType = sourceProperty.PropertyType;
                                elementParameter.TargetType = targetProperty.PropertyType;
                                elementParameter.Source = sourceMember;
                                elementParameter.Target = targetMember;
                                
                                var block = new List<Expression>();
                                block.Add(Expression.IfThen(Expression.Equal(targetMember, Expression.Constant(null, typeof(Object)))
                                    , Expression.Assign(targetMember, Expression.New(targetProperty.PropertyType)))
                                    );
                                block.AddRange(ValidateCompileStateAndCreateMapPropertyExpression(elementParameter, state));
                                var body = Expression.IfThenElse(Expression.Equal(getMethod, Expression.Constant(null, typeof(Object)))
                                          , Expression.Call(p.Target, setMethod, Expression.Default(targetProperty.PropertyType))
                                          , Expression.Block(block));
                                ee.Add(body);
                            }
                            break;
                        case ClassPropertyCreateMode.Assign:
                            if (targetProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                            {
                                var body = Expression.Call(p.Target, setMethod, getMethod);
                                ee.Add(body);
                            }
                            break;
                        default: throw new InvalidOperationException();
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
                else
                {
                    if (sourceProperty.PropertyType.IsNullable())
                    {
                        var sourceNullableGenericType = sourceProperty.PropertyType.GetGenericArguments()[0];
                        if (CanConvert(sourceNullableGenericType, targetProperty.PropertyType))
                        {
                            var ifThen = Expression.IfThen(Expression.NotEqual(getMethod, Expression.Constant(null, typeof(Object)))
                                , Expression.Call(p.Target, setMethod
                            , Expression.Convert(getMethod, targetProperty.PropertyType)));
                            ee.Add(ifThen);
                        }
                        else if (targetProperty.PropertyType == typeof(String))
                        {
                            //If Premitive or Enum, convert to string
                            var toStringMethod = sourceProperty.PropertyType.GetMethods().First(el => el.Name == "ToString");
                            var ifThen = Expression.IfThen(Expression.NotEqual(getMethod, Expression.Constant(null, typeof(Object)))
                                , Expression.Call(p.Target, setMethod, Expression.Call(getMethod, toStringMethod)));
                            ee.Add(ifThen);
                        }
                    }
                    else
                    {
                        if (CanConvert(sourceProperty.PropertyType, targetProperty.PropertyType))
                        {
                            var body = Expression.Call(p.Target, setMethod
                            , Expression.Convert(getMethod, targetProperty.PropertyType));
                            ee.Add(body);
                        }
                        else if (targetProperty.PropertyType == typeof(String))
                        {
                            //If Premitive or Enum, convert to string
                            var toStringMethod = sourceProperty.PropertyType.GetMethods().First(el => el.Name == "ToString");
                            ee.Add(Expression.Call(p.Target, setMethod, Expression.Call(getMethod, toStringMethod)));
                        }
                    }
                }
            }

            return ee;
        }

        private List<Expression> CreateMapCollectionExpression(MapParameter parameter, CompileState state)
        {
            var ee = new List<Expression>();
            var p = parameter;
            var sourceType = p.SourceType;
            var targetType = p.TargetType;

            var pp = this.CreateCollectionPropertyMapping(sourceType, targetType);
            if (pp.Count == 0) { return ee; }

            foreach (var item in pp)
            {
                var sourceProperty = item.source;
                var targetProperty = item.target;
                var targetElementType = targetProperty.PropertyType.GetCollectionElementType();

                var sourceMember = Expression.Property(p.Source, sourceProperty);
                var targetMember = Expression.Property(p.Target, targetProperty);
                var sourceElementType = sourceProperty.PropertyType.GetCollectionElementType();
                var targetSetMethod = targetProperty.GetSetMethod();

                if (targetProperty.PropertyType.IsArray)
                {
                    var sourceElement = Expression.Variable(sourceElementType, "sourceElement");
                    var targetElement = Expression.Variable(targetElementType, "targetElement");
                    var elementParameter = new MapParameter();
                    elementParameter.SourceType = sourceElementType;
                    elementParameter.TargetType = targetElementType;
                    elementParameter.Source = sourceElement;
                    elementParameter.Target = targetElement;
                    
                    var loopBlock = new List<Expression>();
                    var endLoop = Expression.Label("endLoop");

                    if (sourceProperty.PropertyType.IsICollectionT())
                    {
                        //var array = new T[source.Count];
                        //for (int i = 0; i < source.Count; i++)
                        //{
                        //    target = source[i];
                        //    array[i] = target;
                        //}
                        //target.ArrayProperty = array;
                        var index = Expression.Variable(typeof(Int32), "i");
                        var arrayMember = Expression.Variable(targetProperty.PropertyType, "arrayMember");
                        var elementCountPropertyName = "Count";
                        if (sourceProperty.PropertyType.IsArray)
                        {
                            elementCountPropertyName = "Length";
                        }

                        loopBlock.Add(Expression.IfThen(
                                    Expression.LessThanOrEqual(Expression.PropertyOrField(sourceMember, elementCountPropertyName), index),
                                    Expression.Break(endLoop)
                                    ));
                        var indexerProperty = sourceProperty.PropertyType.GetIndexerProperty();
                        if (sourceProperty.PropertyType.IsArray)
                        {
                            loopBlock.Add(Expression.Assign(sourceElement, Expression.ArrayIndex(sourceMember, index)));
                        }
                        else
                        {
                            loopBlock.Add(Expression.Assign(sourceElement, Expression.Property(sourceMember, indexerProperty, index)));
                        }
                        if (targetElementType.IsNullable())
                        {
                            var targetElementGenericType = targetElementType.GetGenericArguments()[0];
                            var nullableTargetElement = Expression.TypeAs(Expression.New(targetElementGenericType), targetElementType);
                            if (CanConvert(sourceElementType, targetElementGenericType))
                            {
                                loopBlock.Add(Expression.Assign(targetElement, Expression.Convert(sourceElement, targetElementType)));
                            }
                            else
                            {
                                //DoNothing
                                //public struct Vector { int X, int Y } does not convert to public struct MapPoint { int X, int Y }
                            }
                        }
                        else
                        {
                            switch (this.CompilerConfig.CollectionElementCreateMode)
                            {
                                case CollectionElementCreateMode.NewObject:
                                    if (sourceElementType == targetElementType && (sourceElementType == typeof(String) || sourceElementType.IsPrimitive))
                                    {
                                        loopBlock.Add(Expression.Assign(targetElement, sourceElement));
                                        loopBlock.AddRange(ValidateCompileStateAndCreateMapPropertyExpression(elementParameter, state));
                                    }
                                    else 
                                    {
                                        var targetConstructor = targetElementType.GetConstructor(Type.EmptyTypes);
                                        if (targetConstructor != null)
                                        {
                                            loopBlock.Add(Expression.Assign(targetElement, Expression.New(targetElementType)));
                                            loopBlock.AddRange(ValidateCompileStateAndCreateMapPropertyExpression(elementParameter, state));
                                        }
                                    }
                                    break;
                                case CollectionElementCreateMode.Assign:
                                    if (sourceElementType == targetElementType)
                                    {
                                        loopBlock.Add(Expression.Assign(targetElement, sourceElement));
                                        loopBlock.AddRange(ValidateCompileStateAndCreateMapPropertyExpression(elementParameter, state));
                                    }
                                    else if ((targetElementType.IsAssignableFrom(sourceElementType)))
                                    {
                                        loopBlock.Add(Expression.Assign(targetElement, Expression.TypeAs(sourceElement, targetElementType)));
                                        loopBlock.AddRange(ValidateCompileStateAndCreateMapPropertyExpression(elementParameter, state));
                                    }
                                    break;
                                default: throw new InvalidOperationException();
                            }
                        }
                        loopBlock.Add(Expression.Assign(Expression.ArrayAccess(arrayMember, index), targetElement));
                        loopBlock.Add(Expression.AddAssign(index, Expression.Constant(1, typeof(Int32))));
                        var body = Expression.Block(new[] { sourceElement, targetElement, index, arrayMember }
                        , index
                        , Expression.Assign(index, Expression.Constant(0, typeof(Int32)))
                        , arrayMember
                        , Expression.Assign(arrayMember, Expression.NewArrayBounds(targetElementType, Expression.PropertyOrField(sourceMember, elementCountPropertyName)))
                        , Expression.Loop(Expression.Block(loopBlock), endLoop)
                        , Expression.Assign(targetMember, arrayMember));

                        ee.Add(Expression.IfThen(Expression.NotEqual(sourceMember, Expression.Constant(null, typeof(Object))), body));
                    }
                }
                else
                {
                    switch (this.CompilerConfig.CollectionPropertyCreateMode)
                    {
                        case CollectionPropertyCreateMode.None: break;
                        case CollectionPropertyCreateMode.NewObject:
                            if (targetSetMethod != null)
                            {
                                var targetConstructor = targetProperty.PropertyType.GetConstructor(Type.EmptyTypes);
                                if (targetConstructor != null)
                                {
                                    var ifThen = Expression.IfThen(Expression.Equal(targetMember, Expression.Constant(null, typeof(Object)))
                                    , Expression.Call(p.Target, targetSetMethod, Expression.New(targetProperty.PropertyType)));
                                    ee.Add(ifThen);
                                }
                            }
                            break;
                        case CollectionPropertyCreateMode.Assign:
                            if (sourceProperty.PropertyType == targetProperty.PropertyType)
                            {
                                var ifThen = Expression.IfThen(Expression.Equal(targetMember, Expression.Constant(null, typeof(Object)))
                                    , Expression.Assign(targetMember, sourceMember));
                                ee.Add(ifThen);
                            }
                            break;
                        default: throw new InvalidOperationException();
                    }

                    var createMapExpression = false;
                    if (this.CompilerConfig.CollectionPropertyCreateMode == CollectionPropertyCreateMode.NewObject)
                    {
                        if (this.CompilerConfig.CollectionElementCreateMode == CollectionElementCreateMode.NewObject)
                        {
                            if (targetElementType.IsValueType || targetElementType.GetConstructor(Type.EmptyTypes) != null)
                            {
                                createMapExpression = true;
                            }
                        }
                        else
                        {
                            createMapExpression = true;
                        }
                    }

                    if (createMapExpression)
                    {
                        var sourceElement = Expression.Variable(sourceElementType, "sourceElement");
                        var targetElement = Expression.Variable(targetElementType, "targetElement");
                        var elementParameter = new MapParameter();
                        elementParameter.SourceType = sourceElementType;
                        elementParameter.TargetType = targetElementType;
                        elementParameter.Source = sourceElement;
                        elementParameter.Target = targetElement;
                        
                        var loopBlock = new List<Expression>();
                        var endLoop = Expression.Label("endLoop");
                        if (sourceProperty.PropertyType.IsICollectionT())
                        {
                            var index = Expression.Variable(typeof(Int32), "i");
                            loopBlock.Add(Expression.IfThen(
                                        Expression.LessThanOrEqual(Expression.PropertyOrField(sourceMember, "Count"), index),
                                        Expression.Break(endLoop)
                                        ));
                            var indexerProperty = sourceProperty.PropertyType.GetIndexerProperty();
                            loopBlock.Add(Expression.Assign(sourceElement, Expression.Property(sourceMember, indexerProperty, index)));
                            if (targetElementType.IsNullable())
                            {
                                var targetElementGenericType = targetElementType.GetGenericArguments()[0];
                                if (sourceElementType.IsNullable())
                                {
                                    var sourceElementGenericType = sourceElementType.GetGenericArguments()[0];
                                    if (sourceElementGenericType == targetElementGenericType)
                                    {
                                        loopBlock.Add(Expression.Assign(targetElement, sourceElement));
                                    }
                                    else if (CanConvert(sourceElementType, targetElementGenericType))
                                    {
                                        loopBlock.Add(Expression.Assign(targetElement, Expression.Convert(sourceElement, targetElementType)));
                                    }
                                }
                                else
                                {
                                    if (sourceElementType == targetElementGenericType)
                                    {
                                        loopBlock.Add(Expression.Assign(targetElement
                                            , Expression.TypeAs(sourceElement, targetElementType)));
                                    }
                                    else if (CanConvert(sourceElementType, targetElementGenericType))
                                    {
                                        loopBlock.Add(Expression.Assign(targetElement, Expression.Convert(sourceElement, targetElementType)));
                                    }
                                }
                            }
                            else if (targetElementType.IsValueType)
                            {
                                if (sourceElementType.IsNullable())
                                {
                                    var sourceNullableGenericType = sourceElementType.GetGenericArguments()[0];
                                    if (CanConvert(sourceNullableGenericType, targetElementType))
                                    {
                                        var ifThen = Expression.IfThen(Expression.NotEqual(sourceElement, Expression.Constant(null, typeof(Object)))
                                            , Expression.Assign(targetElement, Expression.Convert(sourceElement, targetElementType)));
                                        loopBlock.Add(ifThen);
                                    }
                                }
                                else
                                {
                                    if (CanConvert(sourceElementType, targetElementType))
                                    {
                                        loopBlock.Add(Expression.Assign(targetElement, Expression.Convert(sourceElement, targetElementType)));
                                    }
                                }
                            }
                            else
                            {
                                switch (this.CompilerConfig.CollectionElementCreateMode)
                                {
                                    case CollectionElementCreateMode.NewObject:
                                        if (sourceElementType.IsClass && targetElementType.IsClass)
                                        {
                                            var targetConstructor = targetElementType.GetConstructor(Type.EmptyTypes);
                                            if (targetConstructor != null)
                                            {
                                                loopBlock.Add(Expression.Assign(targetElement, Expression.New(targetElementType)));
                                            }
                                        }
                                        loopBlock.AddRange(ValidateCompileStateAndCreateMapPropertyExpression(elementParameter, state));
                                        break;
                                    case CollectionElementCreateMode.Assign:
                                        if (sourceElementType == targetElementType)
                                        {
                                            loopBlock.Add(Expression.Assign(targetElement, sourceElement));
                                            loopBlock.AddRange(ValidateCompileStateAndCreateMapPropertyExpression(elementParameter, state));
                                        }
                                        else if ((targetElementType.IsAssignableFrom(sourceElementType)))
                                        {
                                            loopBlock.Add(Expression.Assign(targetElement, Expression.TypeAs(sourceElement, targetElementType)));
                                            loopBlock.AddRange(ValidateCompileStateAndCreateMapPropertyExpression(elementParameter, state));
                                        }
                                        break;
                                    default: throw new InvalidOperationException();
                                }
                            }
                            loopBlock.Add(Expression.Call(targetMember, "Add", Type.EmptyTypes, targetElement));
                            loopBlock.Add(Expression.AddAssign(index, Expression.Constant(1, typeof(Int32))));

                            var endLabel = Expression.Label("end");
                            
                            var body = Expression.Block(new[] { sourceElement, targetElement, index }
                            , index
                            , Expression.IfThen(Expression.Equal(sourceMember, Expression.Constant(null, typeof(Object)))
                            , Expression.Return(endLabel))
                            , Expression.Assign(index, Expression.Constant(0, typeof(Int32)))
                            , Expression.Loop(Expression.Block(loopBlock), endLoop)
                            , Expression.Label(endLabel));

                            ee.Add(body);
                        }
                        else
                        {
                            var moveNext = typeof(IEnumerator).GetMethod("MoveNext");
                            var enumerableType = sourceProperty.PropertyType;
                            var getEnumerator = enumerableType.GetMethod("GetEnumerator");
                            if (getEnumerator is null)
                            {
                                getEnumerator = typeof(IEnumerable<>).MakeGenericType(sourceElementType).GetMethod("GetEnumerator");
                            }
                            var enumerator = Expression.Variable(getEnumerator.ReturnType, "enumerator");

                            loopBlock.Add(Expression.IfThen(
                                    Expression.IsFalse(Expression.Call(enumerator, moveNext)),
                                    Expression.Break(endLoop)
                                    ));
                            loopBlock.Add(Expression.Assign(sourceElement, Expression.TypeAs(Expression.Property(enumerator, "Current"), sourceElementType)));
                            loopBlock.Add(Expression.Assign(targetElement, Expression.New(targetElementType)));

                            loopBlock.AddRange(ValidateCompileStateAndCreateMapPropertyExpression(elementParameter, state));
                            loopBlock.Add(Expression.Call(targetMember, "Add", Type.EmptyTypes, targetElement));

                            var endLabel = Expression.Label("end");

                            var body = Expression.Block(new[] { sourceElement, targetElement, enumerator }
                            , Expression.Assign(enumerator, Expression.Call(sourceMember, "GetEnumerator", Type.EmptyTypes))
                            , Expression.IfThen(Expression.Equal(enumerator, Expression.Constant(null, typeof(Object)))
                            , Expression.Return(endLabel))
                            , Expression.Loop(Expression.Block(loopBlock), endLoop)
                            , Expression.Label(endLabel));

                            ee.Add(body);
                        }
                    }
                }
            }

            return ee;
        }

        private List<Expression> CreateMapToDictionaryExpression(MapParameter parameter)
        {
            var ee = new List<Expression>();
            var p = parameter;
            var sourceType = p.SourceType;
            var targetType = p.TargetType;

            var addMethod = targetType.GetMethod("Add");

            var pp = CreatePropertyToDictionaryMapping(sourceType, targetType);
            foreach (var item in pp)
            {
                var sourceProperty = item.source;
                var targetProperty = item.target;
                if (sourceType.GetProperty(sourceProperty.Name) == null) { continue; }
                MemberExpression getMethod = Expression.Property(p.Source, sourceProperty);

                {
                    var removeMethod = targetType.GetMethod("Remove", new Type[] { typeof(String) });
                    var body = Expression.Call(p.Target, removeMethod, Expression.Constant(sourceProperty.Name));
                    ee.Add(body);
                }

                var dictionaryValueType = targetProperty.PropertyType;
                if (sourceProperty.PropertyType.IsValueType)
                {
                    if (dictionaryValueType == typeof(Object))
                    {
                        var body = Expression.Call(p.Target, addMethod, Expression.Constant(sourceProperty.Name)
                            , Expression.TypeAs(getMethod, typeof(Object)));
                        ee.Add(body);
                    }
                    else if (dictionaryValueType == typeof(String))
                    {
                        if (sourceProperty.PropertyType.IsNullable())
                        {
                            var ifThen = Expression.IfThen(Expression.NotEqual(getMethod, Expression.Constant(null, typeof(Object)))
                                , Expression.Call(p.Target, addMethod, Expression.Constant(sourceProperty.Name)
                                , Expression.Call(Expression.TypeAs(getMethod, typeof(Object)), _ToStringMethod)));
                            ee.Add(ifThen);
                        }
                        else
                        {
                            var body = Expression.Call(p.Target, addMethod, Expression.Constant(sourceProperty.Name)
                                , Expression.Call(Expression.TypeAs(getMethod, typeof(Object)), _ToStringMethod));
                            ee.Add(body);
                        }
                    }
                }
                else
                {
                    if (dictionaryValueType == typeof(Object))
                    {
                        var body = Expression.Call(p.Target, addMethod, Expression.Constant(sourceProperty.Name), getMethod);
                        ee.Add(body);
                    }
                    else if (dictionaryValueType == typeof(String))
                    {
                        var ifThen = Expression.IfThen(Expression.NotEqual(getMethod, Expression.Constant(null, typeof(Object)))
                            , Expression.Call(p.Target, addMethod, Expression.Constant(sourceProperty.Name)
                            , Expression.Call(getMethod, _ToStringMethod)));
                        ee.Add(ifThen);
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

        private List<Expression> CreateMapFromDictionaryExpression(Type sourceType, Type targetType, MapParameter parameterList)
        {
            var ee = new List<Expression>();
            var p = parameterList;
            var sourceTypeIDictionary = sourceType.GetInterface("IDictionary`2");
            var sourceDictionaryValueType = sourceTypeIDictionary.GetGenericArguments()[1];

            var containsKeyMethod = sourceTypeIDictionary.GetMethod("ContainsKey", new Type[] { typeof(String) });
            var tryGetMethod = typeof(ObjectMapper).GetMethod("TryGetValue", BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(sourceDictionaryValueType);
            var tryGetStringMethod = typeof(ObjectMapper).GetMethod("TryGetStringValue", BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(sourceDictionaryValueType);

            var pp = CreatePropertyFromDictionaryMapping(sourceType, targetType);
            foreach (var item in pp)
            {
                var sourceProperty = item.Item1;
                var targetProperty = item.Item2;
                var getMethod = Expression.Call(tryGetStringMethod, p.Source, Expression.Constant(targetProperty.Name));
                var setMethod = targetProperty.GetSetMethod();
                if (setMethod == null) { continue; }

                if (sourceDictionaryValueType == typeof(Object))
                {
                    getMethod = Expression.Call(tryGetStringMethod, p.Source, Expression.Constant(targetProperty.Name));
                }
                var ifThenBlock = new List<Expression>();
                if (targetProperty.PropertyType == typeof(String))
                {
                    ifThenBlock.Add(Expression.Call(p.Target, setMethod, getMethod));
                }
                else if (targetProperty.PropertyType == typeof(Encoding))
                {
                    var parseMethod = _ParseOrNullMethodList[nameof(Encoding)];
                    var getTargetValueMethod = targetProperty.GetGetMethod();
                    var parse = Expression.Call(parseMethod, getMethod, Expression.Call(p.Target, getTargetValueMethod));
                    ifThenBlock.Add(Expression.Call(p.Target, setMethod, parse));
                }
                else
                {
                    if (targetProperty.PropertyType.IsNullable())
                    {
                        var targetNullableGenericType = targetProperty.PropertyType.GetGenericArguments()[0];
                        if (targetNullableGenericType.IsEnum)
                        {
                            var parseMethod = _ParseOrNullMethodList[nameof(Enum)].MakeGenericMethod(targetNullableGenericType);
                            var getTargetValueMethod = targetProperty.GetGetMethod();
                            var parse = Expression.Call(parseMethod, getMethod, Expression.Call(p.Target, getTargetValueMethod));
                            ifThenBlock.Add(Expression.Call(p.Target, setMethod, parse));
                        }
                        else if (ParseMethodList.HasParseMethod(targetNullableGenericType))
                        {
                            var parseMethod = _ParseOrNullMethodList[targetNullableGenericType.Name];
                            var parse = Expression.Call(parseMethod, getMethod, Expression.Default(targetProperty.PropertyType));
                            ifThenBlock.Add(Expression.Call(p.Target, setMethod, parse));
                        }
                    }
                    else
                    {
                        if (targetProperty.PropertyType.IsEnum)
                        {
                            var parseMethod = _ParseMethodList[nameof(Enum)].MakeGenericMethod(targetProperty.PropertyType);
                            var getTargetValueMethod = targetProperty.GetGetMethod();
                            var parse = Expression.Call(parseMethod, getMethod, Expression.Call(p.Target, getTargetValueMethod));
                            var body = Expression.Call(p.Target, setMethod, parse);
                            ifThenBlock.Add(body);
                        }
                        else if (ParseMethodList.HasParseMethod(targetProperty.PropertyType))
                        {
                            var parseMethod = _ParseMethodList[targetProperty.PropertyType.Name];
                            var getTargetValueMethod = targetProperty.GetGetMethod();
                            var parse = Expression.Call(parseMethod, getMethod, Expression.Call(p.Target, getTargetValueMethod));
                            ifThenBlock.Add(Expression.Call(p.Target, setMethod, parse));
                        }
                    }
                }
                if (ifThenBlock.Count > 0)
                {
                    if (sourceDictionaryValueType == typeof(String))
                    {
                        ee.Add(Expression.IfThen(Expression.Call(p.Source, containsKeyMethod, Expression.Constant(targetProperty.Name))
                            , Expression.Block(ifThenBlock)));
                    }
                    else if (sourceDictionaryValueType == typeof(Object))
                    {
                        var sourceValue = Expression.Call(tryGetMethod, p.Source, Expression.Constant(targetProperty.Name));
                        if (targetProperty.PropertyType == typeof(String))
                        {
                            ee.Add(Expression.IfThen(Expression.Call(p.Source, containsKeyMethod, Expression.Constant(targetProperty.Name))
                                , Expression.Block(ifThenBlock)));
                        }
                        else
                        {
                            ee.Add(Expression.IfThen(Expression.Call(p.Source, containsKeyMethod, Expression.Constant(targetProperty.Name))
                                , Expression.IfThenElse(Expression.TypeIs(sourceValue, targetProperty.PropertyType)
                                , Expression.Call(p.Target, setMethod, Expression.Convert(sourceValue, targetProperty.PropertyType))
                                , Expression.Block(ifThenBlock))));
                        }
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

        private static IDictionary<String, String> MapDictionary_String_String(IDictionary<String, String> source, IDictionary<String, String> target)
        {
            foreach (var key in source.Keys)
            {
                target[key] = source[key].ToString();
            }
            return target;
        }
        private static IDictionary<String, Object> MapDictionary_String_Object(IDictionary<String, String> source, IDictionary<String, Object> target)
        {
            foreach (var key in source.Keys)
            {
                target[key] = source[key];
            }
            return target;
        }
        private static IDictionary<String, String> MapDictionary_Object_String(IDictionary<String, Object> source, IDictionary<String, String> target)
        {
            foreach (var key in source.Keys)
            {
                if (source[key] == null)
                {
                    target[key] = null;
                }
                else
                {
                    target[key] = source[key].ToString();
                }
            }
            return target;
        }
        private static IDictionary<String, Object> MapDictionary_Object_Object(IDictionary<String, Object> source, IDictionary<String, Object> target)
        {
            foreach (var key in source.Keys)
            {
                target[key] = source[key].ToString();
            }
            return target;
        }

        private static TValue TryGetValue<TValue>(IDictionary<String, TValue> dictionary, String key)
        {
            if (dictionary.TryGetValue(key, out var value)) { return value; }
            return default(TValue);
        }
        private static String TryGetStringValue<TValue>(IDictionary<String, TValue> dictionary, String key)
        {
            if (dictionary.TryGetValue(key, out var value))
            {
                if (value == null) { return ""; }
                return value.ToString();
            }
            return "";
        }
        private static Boolean CanConvert(Type sourceType, Type targetType)
        {
            if (sourceType == targetType) { return true; }
            if (_CanConvertList.TryGetValue(new ActionKey(sourceType, targetType), out var result)) { return result; }
            return false;
        }
    }
}
