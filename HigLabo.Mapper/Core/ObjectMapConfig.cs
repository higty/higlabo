using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    /// <summary>
    /// Configure Object Mapping settings.
    /// </summary>
    public class ObjectMapConfig
    {
        private class ObjectMapConfigMethodAttribute : Attribute
        {
            public String Name { get; set; }
        }
        public static ObjectMapConfig Current { get; private set; }

        private static readonly String System_Collections_Generic_ICollection_1 = "System.Collections.Generic.ICollection`1";
        private static readonly String System_Collections_Generic_IEnumerable_1 = "System.Collections.Generic.IEnumerable`1";
        private static readonly String System_Collections_Generic_Dictionary_2 = "System.Collections.Generic.Dictionary`2";
        private readonly ConcurrentDictionary<ObjectMapTypeInfo, Object> _Methods = new ConcurrentDictionary<ObjectMapTypeInfo, Object>();

        private static readonly MethodInfo _MapInternal_Method = null;
        private static readonly MethodInfo _MapInternal_Class_Class_Method = null;
        private static readonly MethodInfo _MapInternal_Class_Struct_Method = null;
        private static readonly MethodInfo _MapInternal_Struct_Class_Method = null;
        private static readonly MethodInfo _MapInternal_Struct_Struct_Method = null;

        private static readonly MethodInfo _MapElement_Method = null;
        private static readonly MethodInfo _MapElement_Class_Class_Method = null;
        private static readonly MethodInfo _MapElement_Class_Struct_Method = null;
        private static readonly MethodInfo _MapElement_Struct_Class_Method = null;
        private static readonly MethodInfo _MapElement_Struct_Struct_Method = null;

        private static readonly MethodInfo _CreateNewObjectArray_Class_Class_Method = null;
        private static readonly MethodInfo _CreateNewObjectArray_Struct_Class_Method = null;

        private static readonly MethodInfo _CallPostAction_Method = null;

        private static readonly MethodInfo _MapDeepCopy_Class_Class_Method = null;
        private static readonly MethodInfo _MapDeepCopy_Struct_Struct_Method = null;
        private static readonly MethodInfo _MapDeepCopy_Struct_Nullable_Method = null;
        private static readonly MethodInfo _MapDeepCopy_Nullable_Nullable_Method = null;

        private static readonly MethodInfo _CreateDeepCopyArrayMethod = null;
        private static readonly MethodInfo _ObjectMapConfig_TypeConverterProperty_GetMethod = null;
        private static readonly MethodInfo _ObjectMapConfig_HasPostActionPropertyGetMethod = null;

        private static readonly ConcurrentDictionary<Type, MethodInfo> _TypeConverter_ToEnumMethods = new ConcurrentDictionary<Type, MethodInfo>();
        private static readonly Dictionary<Type, MethodInfo> _TypeConverter_ToTypeMethods = new Dictionary<Type, MethodInfo>();
        private static readonly List<Type> _PrimitiveValueTypes = new List<Type>();

        private List<MapPostAction> _PostActions = new List<MapPostAction>();

        public List<PropertyMappingRule> PropertyMapRules { get; private set; }
        public List<DictionaryMappingRule> DictionaryMappingRules { get; private set; }
        public TypeConverter TypeConverter { get; set; }
        public Int32 MaxCallStackCount { get; set; }
        public Boolean HasPostAction
        {
            get { return _PostActions.Count > 0; }
        }
        public StringComparer DictionaryKeyStringComparer { get; set; }
        public NullPropertyMapMode NullPropertyMapMode { get; set; }
        public CollectionElementMapMode CollectionElementMapMode { get; set; }

        static ObjectMapConfig()
        {
            Current = new ObjectMapConfig();

            _MapInternal_Method = GetMethodInfo("MapInternal");
            _MapInternal_Class_Class_Method = GetMethodInfo("MapInternal_Class_Class");
            _MapInternal_Class_Struct_Method = GetMethodInfo("MapInternal_Class_Struct");
            _MapInternal_Struct_Class_Method = GetMethodInfo("MapInternal_Struct_Class");
            _MapInternal_Struct_Struct_Method = GetMethodInfo("MapInternal_Struct_Struct");

            _MapElement_Method = GetMethodInfo("MapElement");
            _MapElement_Class_Class_Method = GetMethodInfo("MapElement_Class_Class");
            _MapElement_Class_Struct_Method = GetMethodInfo("MapElement_Class_Struct");
            _MapElement_Struct_Class_Method = GetMethodInfo("MapElement_Struct_Class");
            _MapElement_Struct_Struct_Method = GetMethodInfo("MapElement_Struct_Struct");

            _CreateNewObjectArray_Class_Class_Method = GetMethodInfo("CreateNewObjectArray_Class_Class");
            _CreateNewObjectArray_Struct_Class_Method = GetMethodInfo("CreateNewObjectArray_Struct_Class");

            _CreateDeepCopyArrayMethod = GetMethodInfo("CreateDeepCopyArray");
            _MapDeepCopy_Class_Class_Method = GetMethodInfo("MapDeepCopy_Class_Class");
            _MapDeepCopy_Struct_Struct_Method = GetMethodInfo("MapDeepCopy_Struct_Struct");
            _MapDeepCopy_Struct_Nullable_Method = GetMethodInfo("MapDeepCopy_Struct_Nullable");
            _MapDeepCopy_Nullable_Nullable_Method = GetMethodInfo("MapDeepCopy_Nullable_Nullable");

            _CallPostAction_Method = GetMethodInfo("CallPostAction");

            _ObjectMapConfig_TypeConverterProperty_GetMethod = typeof(ObjectMapConfig).GetProperty("TypeConverter", BindingFlags.Instance | BindingFlags.Public).GetGetMethod();
            _ObjectMapConfig_HasPostActionPropertyGetMethod = typeof(ObjectMapConfig).GetProperty("HasPostAction").GetGetMethod();

            InitializeTypeConverter_ToTypeMethods();

            InitializePrimitiveValueTypes();
        }
        private static void InitializeTypeConverter_ToTypeMethods()
        {
            var d = _TypeConverter_ToTypeMethods;
            InitializeTypeConverter_ToTypeMethods(typeof(String));
            InitializeTypeConverter_ToTypeMethods(typeof(Boolean));
            InitializeTypeConverter_ToTypeMethods(typeof(Guid));
            InitializeTypeConverter_ToTypeMethods(typeof(SByte));
            InitializeTypeConverter_ToTypeMethods(typeof(Int16));
            InitializeTypeConverter_ToTypeMethods(typeof(Int32));
            InitializeTypeConverter_ToTypeMethods(typeof(Int64));
            InitializeTypeConverter_ToTypeMethods(typeof(Byte));
            InitializeTypeConverter_ToTypeMethods(typeof(UInt16));
            InitializeTypeConverter_ToTypeMethods(typeof(UInt32));
            InitializeTypeConverter_ToTypeMethods(typeof(UInt64));
            InitializeTypeConverter_ToTypeMethods(typeof(Single));
            InitializeTypeConverter_ToTypeMethods(typeof(Double));
            InitializeTypeConverter_ToTypeMethods(typeof(Decimal));
            InitializeTypeConverter_ToTypeMethods(typeof(TimeSpan));
            InitializeTypeConverter_ToTypeMethods(typeof(DateTime));
            InitializeTypeConverter_ToTypeMethods(typeof(DateTimeOffset));
            InitializeTypeConverter_ToTypeMethods(typeof(Encoding));
        }
        private static void InitializeTypeConverter_ToTypeMethods(Type type)
        {
            _TypeConverter_ToTypeMethods.Add(type
                , typeof(TypeConverter).GetMethod("To" + type.Name, new Type[] { typeof(Object) }));
        }
        private static void InitializePrimitiveValueTypes()
        {
            var l = _PrimitiveValueTypes;
            l.Add(typeof(String));
            l.Add(typeof(Boolean));
            l.Add(typeof(Guid));
            l.Add(typeof(SByte));
            l.Add(typeof(Int16));
            l.Add(typeof(Int32));
            l.Add(typeof(Int64));
            l.Add(typeof(Byte));
            l.Add(typeof(UInt16));
            l.Add(typeof(UInt32));
            l.Add(typeof(UInt64));
            l.Add(typeof(Single));
            l.Add(typeof(Double));
            l.Add(typeof(Decimal));
            l.Add(typeof(TimeSpan));
            l.Add(typeof(DateTime));
            l.Add(typeof(DateTimeOffset));
        }

        public ObjectMapConfig()
        {
            this.TypeConverter = new TypeConverter();

            this.PropertyMapRules = new List<PropertyMappingRule>();
            this.PropertyMapRules.Add(new DefaultPropertyMappingRule());
            this.DictionaryMappingRules = new List<DictionaryMappingRule>();
            this.DictionaryMappingRules.Add(new DictionaryMappingRule(DictionaryMappingDirection.DictionaryToObject, typeof(Object), TypeFilterCondition.Inherit));
            this.DictionaryMappingRules.Add(new DictionaryMappingRule(DictionaryMappingDirection.ObjectToDictionary, typeof(Object), TypeFilterCondition.Inherit));

            this.MaxCallStackCount = 10;
            this.DictionaryKeyStringComparer = StringComparer.OrdinalIgnoreCase;
            this.NullPropertyMapMode = NullPropertyMapMode.NewObject;
            this.CollectionElementMapMode = CollectionElementMapMode.NewObject;
        }
        private static MethodInfo GetMethodInfo(String name)
        {
            return typeof(ObjectMapConfig).GetMethods().Where(el => el.GetCustomAttributes().Any(attr => attr is ObjectMapConfigMethodAttribute && ((ObjectMapConfigMethodAttribute)attr).Name == name)).FirstOrDefault();
        }
        private MappingContext CreateMappingContext()
        {
            return new MappingContext(this.MaxCallStackCount);
        }

        public TTarget Map<TSource, TTarget>(TSource source, TTarget target)
        {
            return this.Map(source, target, this.CreateMappingContext());
        }
        public TTarget MapOrNull<TSource, TTarget>(TSource source, Func<TTarget> targetConstructor)
            where TTarget : class
        {
            if (source == null) return null;
            return this.Map(source, targetConstructor(), this.CreateMappingContext());
        }
        public TTarget MapOrNull<TSource, TTarget>(TSource source, TTarget target)
            where TTarget : class
        {
            if (source == null) return null;
            return this.Map(source, target, this.CreateMappingContext());
        }
        public TTarget Map<TSource, TTarget>(TSource source, TTarget target, MappingContext context)
        {
            if (source == null || context.MaxCallStackCountOver()) { return target; }
            if (target == null || IsPrimitive(typeof(TTarget)))
            {
                return this.CallPostAction(source, target);
            }
            if (source is IDataReader)
            {
                return this.MapFromDataReader(source as IDataReader, target, context);
            }
            var md = this.GetMethod<TSource, TTarget>(source, target);
            TTarget result = target;
            if (md != null)
            {
                Exception exception = null;
                try
                {
                    context.CallStackCount++;
                    result = md(this, source, result, context);
                }
                catch (VerificationException ex)
                {
                    exception = ex;
                }
                catch (TargetInvocationException ex)
                {
                    exception = ex.InnerException;
                }
                finally
                {
                    context.CallStackCount--;
                }
                if (exception != null)
                {
                    throw new ObjectMapFailureException("Generated map method was failed.Maybe HigLabo.Mapper bug."
                        + "Please notify SouceObject,TargetObject class of this ObjectMapFailureException object to auther."
                        + "We will fix it." + Environment.NewLine
                        + String.Format("SourceType={0}, TargetType={1}", source.GetType().Name, target.GetType().Name)
                        , source, target, exception);
                }
                if (_PostActions.Count == 0) { return result; }
            }
            return this.CallPostAction(source, result);
        }
        private TTarget MapFromDataReader<TTarget>(IDataReader source, TTarget target, MappingContext context)
        {
            Dictionary<String, Object> d = new Dictionary<String, Object>(this.DictionaryKeyStringComparer);
            d.SetValues((IDataReader)source);
            return this.Map(d, target, context);
        }

        [ObjectMapConfigMethod(Name = "MapInternal")]
        public TTarget MapInternal<TSource, TTarget>(TSource source, TTarget target, MappingContext context)
        {
            if (source == null || context.MaxCallStackCountOver()) { return target; }
            var md = this.GetMethod<TSource, TTarget>(source, target);
            if (md == null) { return target; }
            return md.Invoke(this, source, target, context);
        }
        [ObjectMapConfigMethod(Name = "MapInternal_Class_Class")]
        public TTarget MapInternal_Class_Class<TSource, TTarget>(TSource source, TTarget target, MappingContext context)
            where TSource : class
            where TTarget : class
        {
            if (source == null || context.MaxCallStackCountOver()) { return target; }
            var md = this.GetMethod<TSource, TTarget>(source, target);
            if (md == null) { return target; }
            try
            {
                context.CallStackCount++;
                return md(this, source, target, context);
            }
            finally
            {
                context.CallStackCount--;
            }
        }
        [ObjectMapConfigMethod(Name = "MapInternal_Class_Struct")]
        public TTarget MapInternal_Class_Struct<TSource, TTarget>(TSource source, TTarget target, MappingContext context)
            where TSource : class
            where TTarget : struct
        {
            if (source == null || context.MaxCallStackCountOver()) { return target; }
            var md = this.GetMethod<TSource, TTarget>(source, target);
            if (md == null) { return target; }
            try
            {
                context.CallStackCount++;
                return md(this, source, target, context);
            }
            finally
            {
                context.CallStackCount--;
            }
        }
        [ObjectMapConfigMethod(Name = "MapInternal_Struct_Class")]
        public TTarget MapInternal_Struct_Class<TSource, TTarget>(TSource source, TTarget target, MappingContext context)
            where TSource : struct
            where TTarget : class
        {
            if (context.MaxCallStackCountOver()) { return target; }
            var md = this.GetMethod<TSource, TTarget>(source, target);
            if (md == null) { return target; }
            try
            {
                context.CallStackCount++;
                return md(this, source, target, context);
            }
            finally
            {
                context.CallStackCount--;
            }
        }
        [ObjectMapConfigMethod(Name = "MapInternal_Struct_Struct")]
        public TTarget MapInternal_Struct_Struct<TSource, TTarget>(TSource source, TTarget target, MappingContext context)
            where TSource : struct
            where TTarget : struct
        {
            if (context.MaxCallStackCountOver()) { return target; }
            var md = this.GetMethod<TSource, TTarget>(source, target);
            if (md == null) { return target; }
            try
            {
                context.CallStackCount++;
                return md(this, source, target, context);
            }
            finally
            {
                context.CallStackCount--;
            }
        }

        [ObjectMapConfigMethod(Name = "MapElement")]
        public ICollection<TTarget> Map<TSource, TTarget>(IEnumerable<TSource> source, ICollection<TTarget> target, MappingContext context)
            where TTarget : new()
        {
            if (source != null && target != null)
            {
                foreach (var item in source)
                {
                    var o = this.Map(item, new TTarget(), context);
                    target.Add(o);
                }
            }
            return target;
        }
        public ICollection<TTarget> Map<TSource, TTarget>(IEnumerable<TSource> source, ICollection<TTarget> target, Func<TTarget> elementConstructor, MappingContext context)
        {
            if (source != null && target != null)
            {
                foreach (var item in source)
                {
                    var o = this.Map(item, elementConstructor(), context);
                    target.Add(o);
                }
            }
            return target;
        }
        [ObjectMapConfigMethod(Name = "MapElement_Class_Class")]
        public ICollection<TTarget> MapElement_Class_Class<TSource, TTarget>(IEnumerable<TSource> source, ICollection<TTarget> target, MappingContext context)
            where TSource : class
            where TTarget : class, new()
        {
            if (source != null && target != null)
            {
                try
                {
                    context.CallStackCount++;
                    foreach (var item in source.ToArray())
                    {
                        var o = this.MapInternal_Class_Class(item, new TTarget(), context);
                        target.Add(o);
                    }
                }
                finally
                {
                    context.CallStackCount--;
                }
            }
            return target;
        }
        [ObjectMapConfigMethod(Name = "MapElement_Class_Struct")]
        public ICollection<TTarget> MapElement_Class_Struct<TSource, TTarget>(IEnumerable<TSource> source, ICollection<TTarget> target, MappingContext context)
            where TSource : class
            where TTarget : struct
        {
            if (source != null && target != null)
            {
                try
                {
                    context.CallStackCount++;
                    foreach (var item in source.ToArray())
                    {
                        var o = this.MapInternal_Class_Struct(item, new TTarget(), context);
                        target.Add(o);
                    }
                }
                finally
                {
                    context.CallStackCount--;
                }
            }
            return target;
        }
        [ObjectMapConfigMethod(Name = "MapElement_Struct_Class")]
        public ICollection<TTarget> MapElement_Struct_Class<TSource, TTarget>(IEnumerable<TSource> source, ICollection<TTarget> target, MappingContext context)
            where TSource : struct
            where TTarget : class, new()
        {
            if (source != null && target != null)
            {
                try
                {
                    context.CallStackCount++;
                    foreach (var item in source.ToArray())
                    {
                        var o = this.MapInternal_Struct_Class(item, new TTarget(), context);
                        target.Add(o);
                    }
                }
                finally
                {
                    context.CallStackCount--;
                }
            }
            return target;
        }
        [ObjectMapConfigMethod(Name = "MapElement_Struct_Struct")]
        public ICollection<TTarget> MapElement_Struct_Struct<TSource, TTarget>(IEnumerable<TSource> source, ICollection<TTarget> target, MappingContext context)
            where TSource : struct
            where TTarget : struct
        {
            if (source != null && target != null)
            {
                try
                {
                    context.CallStackCount++;
                    foreach (var item in source.ToArray())
                    {
                        var o = this.MapInternal_Struct_Struct(item, new TTarget(), context);
                        target.Add(o);
                    }
                }
                finally
                {
                    context.CallStackCount--;
                }
            }
            return target;
        }

        [ObjectMapConfigMethod(Name = "MapDeepCopy_Class_Class")]
        public ICollection<TTarget> MapDeepCopy_Class_Class<TSource, TTarget>(IEnumerable<TSource> source, ICollection<TTarget> target)
            where TSource : class, TTarget
            where TTarget : class
        {
            if (source != null && target != null)
            {
                foreach (var item in source.ToArray())
                {
                    target.Add(item);
                }
            }
            return target;
        }
        [ObjectMapConfigMethod(Name = "MapDeepCopy_Struct_Struct")]
        public ICollection<TSource> MapDeepCopy_Struct_Struct<TSource>(IEnumerable<TSource> source, ICollection<TSource> target)
            where TSource : struct
        {
            if (source != null && target != null)
            {
                foreach (var item in source.ToArray())
                {
                    target.Add(item);
                }
            }
            return target;
        }
        [ObjectMapConfigMethod(Name = "MapDeepCopy_Struct_Nullable")]
        public ICollection<TSource?> MapDeepCopy_Struct_Nullable<TSource>(IEnumerable<TSource> source, ICollection<TSource?> target)
            where TSource : struct
        {
            if (source != null && target != null)
            {
                foreach (var item in source.ToArray())
                {
                    target.Add(item);
                }
            }
            return target;
        }
        [ObjectMapConfigMethod(Name = "MapDeepCopy_Nullable_Nullable")]
        public ICollection<TSource?> MapDeepCopy_Nullable_Nullable<TSource>(IEnumerable<TSource?> source, ICollection<TSource?> target)
            where TSource : struct
        {
            if (source != null && target != null)
            {
                foreach (var item in source.ToArray())
                {
                    target.Add(item);
                }
            }
            return target;
        }

        public TTarget[] CreateNewObjectArray<TSource, TTarget>(IEnumerable<TSource> source, MappingContext context)
          where TTarget : new()
        {
            if (source == null) { return new TTarget[0]; }
            return source.Select(el => this.MapInternal(el, new TTarget(), context)).ToArray();
        }
        [ObjectMapConfigMethod(Name = "CreateNewObjectArray_Class_Class")]
        public TTarget[] CreateNewObjectArray_Class_Class<TSource, TTarget>(IEnumerable<TSource> source, MappingContext context)
            where TSource : class
            where TTarget : class, new()
        {
            if (source == null) { return new TTarget[0]; }
            return source.Select(el => this.MapInternal_Class_Class(el, new TTarget(), context)).ToArray();
        }
        [ObjectMapConfigMethod(Name = "CreateNewObjectArray_Struct_Class")]
        public TTarget[] CreateNewObjectArray_Struct_Class<TSource, TTarget>(IEnumerable<TSource> source, MappingContext context)
            where TSource : struct
            where TTarget : class, new()
        {
            if (source == null) { return new TTarget[0]; }
            return source.Select(el => this.MapInternal_Struct_Class(el, new TTarget(), context)).ToArray();
        }

        [ObjectMapConfigMethod(Name = "CreateDeepCopyArray")]
        public TTarget[] CreateDeepCopyArray<TSource, TTarget>(IEnumerable<TSource> source)
            where TSource : TTarget
        {
            if (source == null) { return new TTarget[0]; }
            return source.Select<TSource, TTarget>(el => el).ToArray();
        }

        public void RemovePropertyMap<TSource, TTarget>()
        {
            this.RemovePropertyMap<TSource, TTarget>(propertyMap => true, null);
        }
        public void RemovePropertyMap<TSource, TTarget>(IEnumerable<String> propertyNames)
        {
            this.RemovePropertyMap<TSource, TTarget>(propertyMap => propertyNames.Contains(propertyMap.Target.Name), null);
        }
        public void RemovePropertyMap<TSource, TTarget>(params String[] propertyNames)
        {
            this.RemovePropertyMap<TSource, TTarget>(propertyMap => propertyNames.Contains(propertyMap.Target.Name), null);
        }
        public void RemovePropertyMap<TSource, TTarget>(IEnumerable<String> propertyNames, Action<TSource, TTarget> action)
        {
            this.RemovePropertyMap<TSource, TTarget>(propertyMap => propertyNames.Contains(propertyMap.Target.Name), action);
        }
        public void RemovePropertyMap<TSource, TTarget>(Func<PropertyMap, Boolean> selector)
        {
            this.RemovePropertyMap<TSource, TTarget>(selector, null);
        }
        public void RemovePropertyMap<TSource, TTarget>(Func<PropertyMap, Boolean> selector, Action<TSource, TTarget> action)
        {
            this.ReplacePropertyMap(selector, action);
        }

        public void ReplacePropertyMap<TSource, TTarget>(Action<TSource, TTarget> action)
        {
            this.ReplacePropertyMap<TSource, TTarget>(propertyMap => true, action);
        }
        private void ReplacePropertyMap<TSource, TTarget>(Func<PropertyMap, Boolean> selector, Action<TSource, TTarget> action)
        {
            var key = new ObjectMapTypeInfo(typeof(TSource), typeof(TTarget));
            var mappings = this.CreatePropertyMaps(key.Source, key.Target);
            var startIndex = mappings.Count - 1;
            for (int i = startIndex; i > -1; i--)
            {
                if (selector(mappings[i]) == true)
                {
                    mappings.RemoveAt(i);
                }
            }
            if (mappings.Count == 0)
            {
                _Methods[key] = null;
            }
            else
            {
                var md = this.CreateMapMethodInfo<TSource, TTarget>(key, mappings);
                _Methods[key] = md;
            }
            this.AddPostAction(action);
        }

        public void AddPostAction<T>(Action<T, T> action)
        {
            this.AddPostAction<T, T>(action);
        }
        public void AddPostAction<T>(Func<T, T, T> action)
        {
            this.AddPostAction<T, T>(action);
        }
        public void AddPostAction<TSource, TTarget>(Action<TSource, TTarget> action)
        {
            if (action == null) { return; }
            Func<TSource, TTarget, TTarget> f = (source, target) =>
            {
                action(source, target);
                return target;
            };
            this.AddPostAction(TypeFilterCondition.Inherit, TypeFilterCondition.Inherit, f);
        }
        public void AddPostAction<TSource, TTarget>(Func<TSource, TTarget, TTarget> action)
        {
            this.AddPostAction(TypeFilterCondition.Inherit, TypeFilterCondition.Inherit, action);
        }
        public void AddPostAction<TSource, TTarget>(TypeFilterCondition sourceCondition, TypeFilterCondition targetCondition, Func<TSource, TTarget, TTarget> action)
        {
            if (action == null) { return; }

            Func<Object, Object, Object> f = (source, target) => action((TSource)source, (TTarget)target);
            var condition = new MappingCondition();
            condition.Source.Type = typeof(TSource);
            condition.Source.TypeFilterCondition = sourceCondition;
            condition.Target.Type = typeof(TTarget);
            condition.Target.TypeFilterCondition = targetCondition;
            _PostActions.Add(new MapPostAction(condition, (Delegate)f));
        }

        [ObjectMapConfigMethod(Name = "CallPostAction")]
        public TTarget CallPostAction<TSource, TTarget>(TSource source, TTarget target)
        {
            if (_PostActions.Count == 0) { return target; }

            var sourceType = typeof(TSource);
            var targetType = typeof(TTarget);
            for (int i = 0; i < _PostActions.Count; i++)
            {
                if (_PostActions[i].Condition.Match(sourceType, targetType) == false) { continue; }
                var f = (Func<Object, Object, Object>)_PostActions[i].Action;
                return (TTarget)f(source, target);
            }
            return target;
        }

        public void CreateMap<TSource, TTarget>()
        {
            var md = this.GetMethod<TSource, TTarget>(typeof(TSource), typeof(TTarget));
        }
        private Func<ObjectMapConfig, TSource, TTarget, MappingContext, TTarget> GetMethod<TSource, TTarget>(TSource source, TTarget target)
        {
            var sType = typeof(TSource);
            var tType = typeof(TTarget);
            //if (source != null) { sType = source.GetType(); }
            //if (target != null) { tType = target.GetType(); }
            return this.GetMethod<TSource, TTarget>(sType, tType);
        }
        private Func<ObjectMapConfig, TSource, TTarget, MappingContext, TTarget> GetMethod<TSource, TTarget>(Type sourceType, Type targetType)
        {
            Object md = null;
            var key = new ObjectMapTypeInfo(sourceType, targetType);
            if (_Methods.TryGetValue(key, out md) == false)
            {
                var l = this.CreatePropertyMaps(key.Source, key.Target);
                md = this.CreateMapMethodInfo<TSource, TTarget>(key, l);
                _Methods[key] = md;
                //Int32 loopCount = 0;
                //while (true)
                //{
                //    if (_Methods.TryAdd(key, md)) { break; }
                //    loopCount++;
                //    if (loopCount > 3) { throw new InvalidOperationException("CreateMethod failed due to race condition.Please try later."); }
                //}
            }
            return (Func<ObjectMapConfig, TSource, TTarget, MappingContext, TTarget>)md;
        }

        private List<PropertyMap> CreatePropertyMaps(Type sourceType, Type targetType)
        {
            List<PropertyMap> l = new List<PropertyMap>();
            var sourceTypes = new List<Type>();
            sourceTypes.Add(sourceType);
            sourceTypes.AddRange(sourceType.GetBaseClasses());
            sourceTypes.AddRange(sourceType.GetInterfaces());
            var targetTypes = new List<Type>();
            targetTypes.Add(targetType);
            targetTypes.AddRange(targetType.GetBaseClasses());
            targetTypes.AddRange(targetType.GetInterfaces());
            List<PropertyInfo> sourceProperties = new List<PropertyInfo>();
            List<PropertyInfo> targetProperties = new List<PropertyInfo>();
            foreach (var item in sourceTypes)
            {
                if (item == typeof(Object)) { continue; }

                foreach (var p in item.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(el => el.GetIndexParameters().Length == 0))
                {
                    if (p.GetGetMethod() == null) { continue; }
                    if (p.Name == "SyncRoot" && p.PropertyType == typeof(Object)) { continue; }

                    sourceProperties.Add(p);
                }
            }
            foreach (var item in targetTypes)
            {
                if (item == typeof(Object)) { continue; }

                foreach (var p in item.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(el => el.GetIndexParameters().Length == 0))
                {
                    if (p.Name == "SyncRoot" && p.PropertyType == typeof(Object)) { continue; }
                    if (p.GetGetMethod() == null)
                    {
                        var targetInterfaceType = p.PropertyType.GetInterfaces()
                            .FirstOrDefault(tp => tp.FullName.StartsWith(System_Collections_Generic_ICollection_1));
                        if (targetInterfaceType == null) { continue; }
                    }
                    if (p.DeclaringType == item)
                    {
                        targetProperties.Add(p);
                    }
                }
            }
            //Object --> Object 
            foreach (PropertyMappingRule rule in this.PropertyMapRules)
            {
                //Find target property by rules.Validate rule is match to sourceType,targetType.
                if (rule.Condition.Match(sourceType, targetType) == false) { continue; }

                List<PropertyInfo> addedTargetPropertyMapInfo = new List<PropertyInfo>();
                foreach (var piTarget in targetProperties)
                {
                    //Search property that meet condition
                    foreach (var piSource in sourceProperties)
                    {
                        if (rule.Match(piSource, piTarget) == false) { continue; }

                        l.Add(new PropertyMap(piSource, piTarget));
                        addedTargetPropertyMapInfo.Add(piTarget);
                        break;
                    }
                }
                //Remove added target property
                for (int i = 0; i < addedTargetPropertyMapInfo.Count; i++)
                {
                    targetProperties.Remove(addedTargetPropertyMapInfo[i]);
                }
            }
            //Dictionary<String, T> --> Object. 
            var piSourceItem = sourceType.GetProperty("Item", new Type[] { typeof(String) });
            if (piSourceItem != null)
            {
                foreach (var rule in this.DictionaryMappingRules
                    .Where(el => el.Direction == DictionaryMappingDirection.DictionaryToObject))
                {
                    if (rule.Condition.Match(targetType) == false) { continue; }

                    foreach (var piTarget in targetProperties)
                    {
                        foreach (var key in rule.GetIndexedKeys(piTarget.Name))
                        {
                            l.Add(new PropertyMap(piSourceItem, key, piTarget));
                        }
                    }
                }
            }
            //Object --> Dictionary<String, T>. 
            var piTargetItem = targetType.GetProperty("Item", new Type[] { typeof(String) });
            if (piTargetItem != null)
            {
                foreach (var rule in this.DictionaryMappingRules
                    .Where(el => el.Direction == DictionaryMappingDirection.ObjectToDictionary))
                {
                    if (rule.Condition.Match(sourceType) == false) { continue; }

                    foreach (var piSource in sourceProperties)
                    {
                        foreach (var key in rule.GetIndexedKeys(piSource.Name))
                        {
                            l.Add(new PropertyMap(piSource, piTargetItem, key));
                        }
                    }
                }
            }
            return l;
        }
        private Func<ObjectMapConfig, TSource, TTarget, MappingContext, TTarget> CreateMapMethodInfo<TSource, TTarget>(ObjectMapTypeInfo key, IEnumerable<PropertyMap> propertyMapInfo)
        {
            return (Func<ObjectMapConfig, TSource, TTarget, MappingContext, TTarget>)this.CreateMapPropertyMethod(key.Source, key.Target, propertyMapInfo);
        }
        /// <summary>
        /// ***********************************************************************
        /// source.P1 --> target.P1;
        /// source.P1 --> target["P1"];
        /// source["P1"] --> target.P1;
        /// source["P1"] --> target["P1"];
        /// context --> MappingContext.
        /// if (typeof(source) == typeof(target))
        /// {
        ///     target.P1 = source.P1;
        /// }
        /// else if (Use TypeConverter for primitive types)
        /// {
        ///     var converted = converter.ToXXX(source.P1);
        ///     if (converted != null)
        ///     {
        ///         target.P1 = converted;
        ///         return;
        ///     }
        /// }
        /// else
        /// {
        ///     target.P1 = source["P1"];
        ///     return;
        /// }
        /// //Null property handling...
        /// if (target property is Class)
        /// {
        ///     switch (context.NullPropertyMapMode)
        ///     {
        ///         case NullPropertyMapMode.NewObject: target.P1 = new XXX(); break;
        ///         case NullPropertyMapMode.CopyReference: 
        ///         {
        ///             if (typeof(source) inherit from typeof(parent))
        ///             {
        ///                 target.P1 = source.P1; 
        ///             }
        ///             break;
        ///         }
        ///     }
        ///     if (source type is IEnumerable and target type is ICollection)
        ///     {
        ///         switch (context.CollectionElementMapmode)
        ///         {
        ///             case CollectionElementMapmode.NewObject: this.MapElement(source, target); break;
        ///             case CollectionElementMapmode.CopyReference: this.MapDeepCopy(source, target); break;
        ///         }
        ///     }
        /// }
        /// target.P1 = source.P1.Map(target.P1);
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="propertyMapInfo"></param>
        /// <returns></returns>
        private Delegate CreateMapPropertyMethod(Type sourceType, Type targetType, IEnumerable<PropertyMap> propertyMapInfo)
        {
            DynamicMethod dm = new DynamicMethod("MapProperty", targetType, new[] { typeof(ObjectMapConfig), sourceType, targetType, typeof(MappingContext) });
            ILGenerator il = dm.GetILGenerator();

            var typeConverter = il.DeclareLocal(typeof(TypeConverter));
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Callvirt, _ObjectMapConfig_TypeConverterProperty_GetMethod);
            il.SetLocal(typeConverter);//ObjectMapConfig.TypeConverter

            Label endOfMethodLabel = il.DefineLabel();
            foreach (var item in propertyMapInfo)
            {
                #region local variables
                var sourceProperty = item.Source;
                var targetProperty = item.Target;
                var sourceProperty_PropertyType = sourceProperty.PropertyType;
                var targetProperty_PropertyType = targetProperty.PropertyType;
                var sourceGetMethod = sourceProperty.PropertyInfo.GetGetMethod();
                var sourceSetMethod = sourceProperty.PropertyInfo.GetSetMethod();
                var targetGetMethod = targetProperty.PropertyInfo.GetGetMethod();
                var targetSetMethod = targetProperty.PropertyInfo.GetSetMethod();
                var ldSourceTypeArg = sourceType.IsValueType ? OpCodes.Ldarga_S : OpCodes.Ldarg;
                var ldTargetTypeArg = targetType.IsValueType ? OpCodes.Ldarga_S : OpCodes.Ldarg;
                var sourceMethodCall = sourceType.IsValueType ? OpCodes.Call : OpCodes.Callvirt;
                var targetMethodCall = targetType.IsValueType ? OpCodes.Call : OpCodes.Callvirt;
                var targetCreated = false;
                var deepCopy = false;
                var newCollection = false;
                #endregion

                if (targetProperty.IsIndexedProperty)
                {
                    #region
                    if (sourceProperty.IsIndexedProperty)
                    {
                        #region Dictionary<String, String> or Dictionary<String, Object>
                        //Call TryGetValue method to avoid KeyNotFoundException
                        if (sourceType.IsInheritanceFrom(typeof(Dictionary<String, String>)) == true)
                        {
                            //Call ContainsKey method.If key does not exist, exit method.
                            var containsKey = sourceType.GetMethod("ContainsKey");
                            il.Emit(OpCodes.Ldarg_1);
                            il.Emit(OpCodes.Ldstr, sourceProperty.IndexedPropertyKey);
                            il.Emit(OpCodes.Callvirt, containsKey);
                            var containsKey_False = il.DefineLabel();
                            il.Emit(OpCodes.Brfalse, containsKey_False); //ContainsKey=false --> Exit method without do anything.
                            {
                                if (targetProperty_PropertyType == typeof(Object))
                                {
                                    il.Emit(OpCodes.Ldarg_2);
                                    il.Emit(OpCodes.Ldstr, targetProperty.IndexedPropertyKey);
                                    il.Emit(OpCodes.Ldarg_1);
                                    il.Emit(OpCodes.Ldstr, sourceProperty.IndexedPropertyKey);
                                    il.Emit(OpCodes.Callvirt, sourceGetMethod);
                                    il.Emit(OpCodes.Callvirt, targetSetMethod);
                                }
                                else if (sourceProperty_PropertyType == typeof(String))
                                {
                                    il.Emit(OpCodes.Ldarg_2);
                                    il.Emit(OpCodes.Ldstr, targetProperty.IndexedPropertyKey);
                                    il.LoadLocal(typeConverter);
                                    il.Emit(OpCodes.Ldarg_1);
                                    il.Emit(OpCodes.Ldstr, sourceProperty.IndexedPropertyKey);
                                    il.Emit(OpCodes.Callvirt, sourceGetMethod);
                                    il.Emit(OpCodes.Callvirt, GetTypeConverterToTypeMethodInfo(targetProperty_PropertyType));
                                    il.Emit(OpCodes.Callvirt, targetSetMethod);
                                }
                            }
                            il.MarkLabel(containsKey_False);
                        }
                        #endregion
                    }
                    else
                    {
                        if (targetProperty_PropertyType == typeof(Object))
                        {
                            il.Emit(ldTargetTypeArg, 2);
                            il.Emit(OpCodes.Ldstr, targetProperty.IndexedPropertyKey);
                            il.Emit(ldSourceTypeArg, 1);
                            il.Emit(sourceMethodCall, sourceGetMethod);
                            if (sourceProperty_PropertyType.IsValueType)
                            {
                                il.Emit(OpCodes.Box, sourceProperty_PropertyType);
                            }
                            il.Emit(targetMethodCall, targetSetMethod);
                        }
                        else if (targetProperty_PropertyType == typeof(String))
                        {
                            il.Emit(ldTargetTypeArg, 2);
                            il.Emit(OpCodes.Ldstr, targetProperty.IndexedPropertyKey);
                            il.LoadLocal(typeConverter);
                            il.Emit(ldSourceTypeArg, 1);
                            il.Emit(sourceMethodCall, sourceGetMethod);
                            if (sourceProperty_PropertyType.IsValueType)
                            {
                                il.Emit(OpCodes.Box, sourceProperty_PropertyType);
                            }
                            il.Emit(OpCodes.Callvirt, GetTypeConverterToTypeMethodInfo(targetProperty_PropertyType));
                            il.Emit(targetMethodCall, targetSetMethod);
                        }
                    }
                    #endregion
                }
                else if (targetProperty_PropertyType == typeof(String))
                {
                    #region
                    if (sourceProperty.IsIndexedProperty)
                    {
                        #region Dictionary<String, String> or Dictionary<String, Object>
                        //Call TryGetValue method to avoid KeyNotFoundException
                        if (sourceType.IsInheritanceFrom(typeof(Dictionary<String, String>)) == true ||
                            sourceType.IsInheritanceFrom(typeof(Dictionary<String, Object>)) == true)
                        {
                            //Call ContainsKey method.If key does not exist, exit method.
                            var containsKey = sourceType.GetMethod("ContainsKey");
                            il.Emit(OpCodes.Ldarg_1);
                            il.Emit(OpCodes.Ldstr, sourceProperty.IndexedPropertyKey);
                            il.Emit(OpCodes.Callvirt, containsKey);
                            var containsKey_False = il.DefineLabel();
                            il.Emit(OpCodes.Brfalse, containsKey_False); //ContainsKey=false --> Exit method without do anything.
                            {
                                if (sourceProperty_PropertyType == typeof(String))
                                {
                                    il.Emit(ldTargetTypeArg, 2);
                                    il.Emit(ldSourceTypeArg, 1);
                                    il.Emit(OpCodes.Ldstr, sourceProperty.IndexedPropertyKey);
                                    il.Emit(sourceMethodCall, sourceGetMethod);
                                    il.Emit(targetMethodCall, targetSetMethod);
                                }
                                else if (sourceProperty_PropertyType == typeof(Object))
                                {
                                    il.Emit(ldTargetTypeArg, 2);
                                    il.LoadLocal(typeConverter);
                                    il.Emit(ldSourceTypeArg, 1);
                                    il.Emit(OpCodes.Ldstr, sourceProperty.IndexedPropertyKey);
                                    il.Emit(sourceMethodCall, sourceGetMethod);
                                    il.Emit(OpCodes.Callvirt, GetTypeConverterToTypeMethodInfo(targetProperty_PropertyType));
                                    il.Emit(targetMethodCall, targetSetMethod);
                                }
                            }
                            il.MarkLabel(containsKey_False);
                        }
                        #endregion
                    }
                    else if (sourceProperty_PropertyType == typeof(String))
                    {
                        #region
                        il.Emit(ldTargetTypeArg, 2);
                        il.Emit(ldSourceTypeArg, 1);
                        il.Emit(sourceMethodCall, sourceGetMethod);
                        il.Emit(targetMethodCall, targetSetMethod);
                        #endregion
                    }
                    else if (IsPrimitive(sourceProperty.ActualType))//Int32, Int32? ...etc
                    {
                        #region
                        il.Emit(ldTargetTypeArg, 2);
                        il.LoadLocal(typeConverter);
                        il.Emit(ldSourceTypeArg, 1);
                        il.Emit(sourceMethodCall, sourceGetMethod);
                        il.Emit(OpCodes.Box, sourceProperty_PropertyType);
                        il.Emit(OpCodes.Callvirt, GetTypeConverterToTypeMethodInfo(typeof(String)));
                        il.Emit(targetMethodCall, targetSetMethod);
                        #endregion
                    }
                    else if (sourceProperty_PropertyType.IsValueType)//Vector, Complex
                    {
                        //Do nothing...
                    }
                    #endregion
                }
                else if (targetProperty_PropertyType == typeof(Encoding))
                {
                    #region
                    if (sourceProperty.IsIndexedProperty)
                    {
                        #region Dictionary<String, String> or Dictionary<String, Object>
                        //Call TryGetValue method to avoid KeyNotFoundException
                        if (sourceType.IsInheritanceFrom(typeof(Dictionary<String, String>)) == true)
                        {
                            //Call ContainsKey method.If key does not exist, exit method.
                            var containsKey = sourceType.GetMethod("ContainsKey");
                            il.Emit(OpCodes.Ldarg_1);
                            il.Emit(OpCodes.Ldstr, sourceProperty.IndexedPropertyKey);
                            il.Emit(OpCodes.Callvirt, containsKey);
                            var containsKey_False = il.DefineLabel();
                            il.Emit(OpCodes.Brfalse, containsKey_False); //ContainsKey=false --> Exit method without do anything.
                            {
                                il.Emit(OpCodes.Ldarg_2);
                                il.LoadLocal(typeConverter);
                                il.Emit(OpCodes.Ldarg_1);
                                il.Emit(OpCodes.Ldstr, sourceProperty.IndexedPropertyKey);
                                il.Emit(OpCodes.Callvirt, sourceGetMethod);
                                il.Emit(OpCodes.Callvirt, GetTypeConverterToTypeMethodInfo(targetProperty_PropertyType));
                                il.Emit(OpCodes.Callvirt, targetSetMethod);
                            }
                            il.MarkLabel(containsKey_False);
                        }
                        #endregion
                    }
                    else if (sourceProperty_PropertyType == targetProperty_PropertyType)
                    {
                        #region
                        il.Emit(ldTargetTypeArg, 2);
                        il.Emit(ldSourceTypeArg, 1);
                        il.Emit(sourceMethodCall, sourceGetMethod);
                        il.Emit(targetMethodCall, targetSetMethod);
                        #endregion
                    }
                    else if (IsNumber(sourceProperty.ActualType))//Convert from encode number.
                    {
                        #region
                        il.Emit(ldTargetTypeArg, 2);
                        il.LoadLocal(typeConverter);
                        il.Emit(ldSourceTypeArg, 1);
                        il.Emit(sourceMethodCall, sourceGetMethod);
                        il.Emit(OpCodes.Box, sourceProperty_PropertyType);
                        il.Emit(OpCodes.Callvirt, GetTypeConverterToTypeMethodInfo(targetProperty_PropertyType));
                        il.Emit(targetMethodCall, targetSetMethod);
                        #endregion
                    }
                    #endregion
                }
                else if (IsPrimitive(targetProperty_PropertyType) && targetSetMethod != null)//Int32, DateTime, Boolean
                {
                    #region
                    if (sourceProperty.IsIndexedProperty)
                    {
                        #region Dictionary<String, String> or Dictionary<String, Object>
                        //Call TryGetValue method to avoid KeyNotFoundException
                        if (sourceType.IsInheritanceFrom(typeof(Dictionary<String, String>)) == true ||
                            sourceType.IsInheritanceFrom(typeof(Dictionary<String, Object>)) == true)
                        {
                            //Call ContainsKey method.If key does not exist, exit method.
                            var containsKey = sourceType.GetMethod("ContainsKey");
                            il.Emit(OpCodes.Ldarg_1);
                            il.Emit(OpCodes.Ldstr, sourceProperty.IndexedPropertyKey);
                            il.Emit(OpCodes.Callvirt, containsKey);
                            var containsKey_False = il.DefineLabel();
                            il.Emit(OpCodes.Brfalse, containsKey_False); //ContainsKey=false --> Exit method without do anything.
                            {
                                il.LoadLocal(typeConverter);
                                if (sourceProperty_PropertyType == typeof(String))
                                {
                                    il.Emit(ldSourceTypeArg, 1);
                                    il.Emit(OpCodes.Ldstr, sourceProperty.IndexedPropertyKey);
                                    il.Emit(sourceMethodCall, sourceGetMethod);
                                }
                                else if (sourceProperty_PropertyType == typeof(Object))
                                {
                                    il.Emit(ldSourceTypeArg, 1);
                                    il.Emit(OpCodes.Ldstr, sourceProperty.IndexedPropertyKey);
                                    il.Emit(sourceMethodCall, sourceGetMethod);
                                }
                                il.Emit(OpCodes.Callvirt, GetTypeConverterToTypeMethodInfo(targetProperty.ActualType));
                                var nullableTargetType = typeof(Nullable<>).MakeGenericType(targetProperty.ActualType);
                                var convertedValue = il.DeclareLocal(nullableTargetType);
                                il.SetLocal(convertedValue);
                                il.LoadLocala(convertedValue);
                                il.Emit(OpCodes.Call, nullableTargetType.GetProperty("HasValue").GetGetMethod());
                                var hasValue_False = il.DefineLabel();
                                il.Emit(OpCodes.Brfalse_S, hasValue_False);
                                {
                                    il.Emit(OpCodes.Ldarg_2);
                                    il.LoadLocala(convertedValue);
                                    il.Emit(OpCodes.Call, nullableTargetType.GetMethod("GetValueOrDefault", Type.EmptyTypes));
                                    il.Emit(OpCodes.Callvirt, targetSetMethod);
                                }
                                il.MarkLabel(hasValue_False);
                            }
                            il.MarkLabel(containsKey_False);
                        }
                        #endregion
                    }
                    else if (sourceProperty_PropertyType == targetProperty_PropertyType)
                    {
                        #region
                        il.Emit(ldTargetTypeArg, 2);
                        il.Emit(ldSourceTypeArg, 1);
                        il.Emit(sourceMethodCall, sourceGetMethod);
                        il.Emit(targetMethodCall, targetSetMethod);
                        #endregion
                    }
                    else
                    {
                        #region target.P1 = this.TypeConverter.ToXXX(source.P1) ?? target.P1;
                        il.LoadLocal(typeConverter);
                        il.Emit(OpCodes.Ldarg_1);
                        il.Emit(OpCodes.Callvirt, sourceGetMethod);
                        il.Emit(OpCodes.Box, sourceProperty_PropertyType);
                        il.Emit(OpCodes.Callvirt, GetTypeConverterToTypeMethodInfo(targetProperty.ActualType));
                        var nullableTargetType = typeof(Nullable<>).MakeGenericType(targetProperty.ActualType);
                        var convertedValue = il.DeclareLocal(nullableTargetType);
                        il.SetLocal(convertedValue);
                        il.LoadLocala(convertedValue);
                        il.Emit(OpCodes.Call, nullableTargetType.GetProperty("HasValue").GetGetMethod());
                        var hasValue_False = il.DefineLabel();
                        il.Emit(OpCodes.Brfalse_S, hasValue_False);
                        {
                            il.Emit(OpCodes.Ldarg_2);
                            il.LoadLocala(convertedValue);
                            il.Emit(OpCodes.Call, nullableTargetType.GetMethod("GetValueOrDefault", Type.EmptyTypes));
                            il.Emit(OpCodes.Callvirt, targetSetMethod);
                        }
                        il.MarkLabel(hasValue_False);
                        #endregion
                    }
                    #endregion
                }
                else if (IsPrimitive(targetProperty.ActualType) && targetSetMethod != null)//Int32?, DateTime?, Boolean?
                {
                    #region
                    if (sourceProperty.IsIndexedProperty)
                    {
                        #region Dictionary<String, String> or Dictionary<String, Object>
                        //Call TryGetValue method to avoid KeyNotFoundException
                        if (sourceType.IsInheritanceFrom(typeof(Dictionary<String, String>)) == true ||
                            sourceType.IsInheritanceFrom(typeof(Dictionary<String, Object>)) == true)
                        {
                            //Call ContainsKey method.If key does not exist, exit method.
                            var containsKey = sourceType.GetMethod("ContainsKey");
                            il.Emit(OpCodes.Ldarg_1);
                            il.Emit(OpCodes.Ldstr, sourceProperty.IndexedPropertyKey);
                            il.Emit(OpCodes.Callvirt, containsKey);
                            var containsKey_False = il.DefineLabel();
                            il.Emit(OpCodes.Brfalse, containsKey_False); //ContainsKey=false --> Exit method without do anything.
                            {
                                il.Emit(OpCodes.Ldarg_2);
                                il.LoadLocal(typeConverter);
                                il.Emit(OpCodes.Ldarg_1);
                                il.Emit(OpCodes.Ldstr, sourceProperty.IndexedPropertyKey);
                                il.Emit(OpCodes.Callvirt, sourceGetMethod);
                                il.Emit(OpCodes.Callvirt, GetTypeConverterToTypeMethodInfo(targetProperty.ActualType));
                                il.Emit(OpCodes.Callvirt, targetSetMethod);
                            }
                            il.MarkLabel(containsKey_False);
                        }
                        #endregion
                    }
                    else if (sourceProperty_PropertyType == targetProperty_PropertyType)
                    {
                        #region
                        il.Emit(ldTargetTypeArg, 2);
                        il.Emit(ldSourceTypeArg, 1);
                        il.Emit(sourceMethodCall, sourceGetMethod);
                        il.Emit(targetMethodCall, targetSetMethod);
                        #endregion
                    }
                    else
                    {
                        #region target.P1 = this.TypeConverter.ToXXX(source.P1) ?? target.P1;
                        il.Emit(OpCodes.Ldarg_2);
                        il.LoadLocal(typeConverter);
                        il.Emit(OpCodes.Ldarg_1);
                        il.Emit(OpCodes.Callvirt, sourceGetMethod);
                        il.Emit(OpCodes.Box, sourceProperty_PropertyType);
                        il.Emit(OpCodes.Callvirt, GetTypeConverterToTypeMethodInfo(targetProperty.ActualType));
                        il.Emit(OpCodes.Callvirt, targetSetMethod);
                        #endregion
                    }
                    #endregion
                }
                else if (targetProperty_PropertyType.IsClass || targetProperty_PropertyType.IsInterface)
                {
                    #region
                    if (this.NullPropertyMapMode != NullPropertyMapMode.None && targetSetMethod != null)
                    {
                        #region if (target.P1 == null) { target.P1 = new TTarget(); }
                        il.Emit(OpCodes.Ldarg_2);
                        il.Emit(OpCodes.Callvirt, targetGetMethod);
                        il.Emit(OpCodes.Ldnull);
                        il.Emit(OpCodes.Ceq);
                        var sourceIsNullLabel = il.DefineLabel();
                        il.Emit(OpCodes.Brfalse_S, sourceIsNullLabel);
                        {
                            if (this.NullPropertyMapMode == NullPropertyMapMode.NewObject &&
                                targetProperty_PropertyType.IsClass)
                            {
                                var defaultConstructor = targetProperty_PropertyType.GetConstructor(Type.EmptyTypes);
                                if (defaultConstructor != null)
                                {
                                    targetCreated = true;
                                    il.Emit(OpCodes.Ldarg_2);
                                    il.Emit(OpCodes.Newobj, defaultConstructor);
                                    il.Emit(OpCodes.Callvirt, targetSetMethod);
                                }
                            }
                            else if (this.NullPropertyMapMode == NullPropertyMapMode.DeepCopy)
                            {
                                if (targetProperty_PropertyType.IsAssignableFrom(sourceProperty_PropertyType))
                                {
                                    targetCreated = true;
                                    deepCopy = true;
                                    il.Emit(OpCodes.Ldarg_2);
                                    il.Emit(OpCodes.Ldarg_1);
                                    il.Emit(OpCodes.Callvirt, sourceGetMethod);
                                    il.Emit(OpCodes.Callvirt, targetSetMethod);
                                }
                            }
                        }
                        il.MarkLabel(sourceIsNullLabel);
                        #endregion
                    }

                    if (this.CollectionElementMapMode != CollectionElementMapMode.None &&
                        sourceProperty.IsIndexedProperty == false && targetProperty.IsIndexedProperty == false &&
                        sourceProperty_PropertyType.FullName.StartsWith(System_Collections_Generic_Dictionary_2) == false &&
                        targetProperty_PropertyType.FullName.StartsWith(System_Collections_Generic_Dictionary_2) == false)
                    {
                        #region IEnumerable<TSource> to ICollection<TTarget>
                        var sourceInterfaceType = sourceProperty_PropertyType.GetInterfaces()
                            .FirstOrDefault(tp => tp.FullName.StartsWith(System_Collections_Generic_IEnumerable_1));
                        var targetInterfaceType = targetProperty_PropertyType.GetInterfaces()
                            .FirstOrDefault(tp => tp.FullName.StartsWith(System_Collections_Generic_ICollection_1));
                        if (sourceInterfaceType != null && targetInterfaceType != null)
                        {
                            newCollection = true;
                            var sourceElementType = sourceInterfaceType.GenericTypeArguments[0];
                            var targetElementType = targetInterfaceType.GenericTypeArguments[0];

                            if ((this.CollectionElementMapMode == CollectionElementMapMode.DeepCopy || IsImmutable(targetElementType)) &&
                                targetElementType.IsAssignableFrom(sourceElementType))
                            {
                                #region DeepCopy when SourceElementType can assign to TargetElementTyep.
                                il.Emit(OpCodes.Ldarg_1);
                                il.Emit(OpCodes.Callvirt, sourceGetMethod);
                                il.Emit(OpCodes.Ldnull);
                                il.Emit(OpCodes.Ceq);
                                var sourceIsNullLabel = il.DefineLabel();
                                il.Emit(OpCodes.Brtrue_S, sourceIsNullLabel);
                                {
                                    if (targetProperty_PropertyType.IsArray && targetProperty_PropertyType.GetArrayRank() == 1)
                                    {
                                        if (targetSetMethod != null)
                                        {
                                            #region IEnumerabe<TSouce> to TTarget[]
                                            il.Emit(OpCodes.Ldarg_2);
                                            il.Emit(OpCodes.Ldarg_0);
                                            il.Emit(OpCodes.Ldarg_1);
                                            il.Emit(OpCodes.Callvirt, sourceGetMethod);
                                            il.Emit(OpCodes.Call, _CreateDeepCopyArrayMethod.MakeGenericMethod(sourceElementType, targetElementType));
                                            il.Emit(OpCodes.Callvirt, targetSetMethod);
                                            #endregion
                                        }
                                    }
                                    else
                                    {
                                        #region this.MapDeepCopy(source.P1, target.P1); //SourceElementType can assign to TargetElementTyep.
                                        il.Emit(OpCodes.Ldarg_0);
                                        il.Emit(OpCodes.Ldarg_1);
                                        il.Emit(OpCodes.Callvirt, sourceGetMethod);
                                        il.Emit(OpCodes.Ldarg_2);
                                        il.Emit(OpCodes.Callvirt, targetGetMethod);
                                        MethodInfo md = null;
                                        if (sourceElementType.IsInheritanceFrom(typeof(Nullable<>)) && targetElementType.IsInheritanceFrom(typeof(Nullable<>)))
                                        { md = _MapDeepCopy_Nullable_Nullable_Method.MakeGenericMethod(sourceElementType.GenericTypeArguments[0]); }
                                        else if (sourceElementType.IsValueType && targetElementType.IsInheritanceFrom(typeof(Nullable<>)))
                                        { md = _MapDeepCopy_Struct_Nullable_Method.MakeGenericMethod(sourceElementType); }
                                        else if (sourceElementType.IsValueType && targetElementType.IsValueType) { md = _MapDeepCopy_Struct_Struct_Method.MakeGenericMethod(sourceElementType); }
                                        else if (sourceElementType.IsClass) { md = _MapDeepCopy_Class_Class_Method.MakeGenericMethod(sourceElementType, targetElementType); }
                                        il.Emit(OpCodes.Call, md);
                                        il.Emit(OpCodes.Pop);
                                        #endregion
                                    }
                                }
                                il.MarkLabel(sourceIsNullLabel);
                                #endregion
                            }
                            else if (this.CollectionElementMapMode == CollectionElementMapMode.NewObject &&
                                targetProperty_PropertyType.IsClass)
                            {
                                #region New Object when TargetElementTyep has default constructor.
                                var defaultConstructor = targetElementType.GetConstructor(Type.EmptyTypes);
                                if (defaultConstructor != null)
                                {
                                    il.Emit(OpCodes.Ldarg_1);
                                    il.Emit(OpCodes.Callvirt, sourceGetMethod);
                                    il.Emit(OpCodes.Ldnull);
                                    il.Emit(OpCodes.Ceq);
                                    var sourceIsNullLabel = il.DefineLabel();
                                    il.Emit(OpCodes.Brtrue_S, sourceIsNullLabel);
                                    {
                                        #region this.MapElement(source.P1, target.P1); //SourceElementType has default constructor.
                                        if (targetProperty_PropertyType.IsArray && targetProperty_PropertyType.GetArrayRank() == 1)
                                        {
                                            if (targetSetMethod != null)
                                            {
                                                #region IEnumerabe<TSouce> to TTarget[]
                                                il.Emit(OpCodes.Ldarg_2);
                                                il.Emit(OpCodes.Ldarg_0);
                                                il.Emit(OpCodes.Ldarg_1);
                                                il.Emit(OpCodes.Callvirt, sourceGetMethod);
                                                il.Emit(OpCodes.Ldarg_3);
                                                MethodInfo md = null;
                                                if (sourceElementType.IsClass && targetElementType.IsClass) { md = _CreateNewObjectArray_Class_Class_Method; }
                                                else if (sourceElementType.IsValueType && targetElementType.IsClass) { md = _CreateNewObjectArray_Struct_Class_Method; }
                                                il.Emit(OpCodes.Call, md.MakeGenericMethod(sourceElementType, targetElementType));
                                                il.Emit(OpCodes.Callvirt, targetSetMethod);
                                                #endregion
                                            }
                                        }
                                        else
                                        {
                                            #region IEnumerabe<TSouce> to ICollection<TTarget>
                                            il.Emit(OpCodes.Ldarg_0);
                                            il.Emit(OpCodes.Ldarg_1);
                                            il.Emit(OpCodes.Callvirt, sourceGetMethod);
                                            il.Emit(OpCodes.Ldarg_2);
                                            il.Emit(OpCodes.Callvirt, targetGetMethod);
                                            il.Emit(OpCodes.Ldarg_3);
                                            MethodInfo md = null;
                                            if (sourceProperty.IsNullableT || targetProperty.IsNullableT) { md = _MapElement_Method; }
                                            else if (sourceElementType.IsClass && targetElementType.IsClass) { md = _MapElement_Class_Class_Method; }
                                            else if (sourceElementType.IsClass && targetElementType.IsValueType) { md = _MapElement_Class_Struct_Method; }
                                            else if (sourceElementType.IsValueType && targetElementType.IsClass) { md = _MapElement_Struct_Class_Method; }
                                            else if (sourceElementType.IsValueType && targetElementType.IsValueType) { md = _MapElement_Struct_Struct_Method; }
                                            il.Emit(OpCodes.Callvirt, md.MakeGenericMethod(sourceElementType, targetElementType));
                                            il.Emit(OpCodes.Pop);
                                            #endregion
                                        }
                                        #endregion
                                    }
                                    il.MarkLabel(sourceIsNullLabel);
                                }
                                #endregion
                            }
                        }
                        #endregion
                    }
                    #endregion
                }
                if (targetSetMethod == null) { continue; }
                if (sourceProperty.IsIndexedProperty || targetProperty.IsIndexedProperty) { continue; }

                #region Map or CallPostAction
                if (deepCopy == false && newCollection == false)
                {
                    MethodInfo md = null;

                    if (IsImmutable(targetProperty.ActualType) == true)
                    {
                        if (this.HasPostAction)
                        {
                            #region target.P1 = this.CallPostAction(source.P1, target.P1);
                            //if (this.HasPostAction == true) { ... }
                            il.Emit(OpCodes.Ldarg_0);
                            il.Emit(OpCodes.Callvirt, _ObjectMapConfig_HasPostActionPropertyGetMethod);
                            var hasPostActionIsFalseLabel = il.DefineLabel();
                            il.Emit(OpCodes.Brfalse_S, hasPostActionIsFalseLabel);
                            {
                                il.Emit(ldTargetTypeArg, 2);
                                {
                                    il.Emit(OpCodes.Ldarg_0);
                                    il.Emit(ldSourceTypeArg, 1);
                                    il.Emit(sourceMethodCall, sourceGetMethod);
                                    il.Emit(ldTargetTypeArg, 2);
                                    il.Emit(targetMethodCall, targetGetMethod);
                                    md = _CallPostAction_Method;
                                    il.Emit(OpCodes.Callvirt, md.MakeGenericMethod(sourceProperty_PropertyType, targetProperty_PropertyType));
                                }
                                il.Emit(targetMethodCall, targetSetMethod);
                            }
                            il.MarkLabel(hasPostActionIsFalseLabel);
                            #endregion
                        }
                    }
                    else if (targetCreated)
                    {
                        #region this.Map(source.P1, target.P1, context);
                        il.Emit(ldTargetTypeArg, 2);
                        {
                            il.Emit(OpCodes.Ldarg_0);
                            il.Emit(ldSourceTypeArg, 1);
                            il.Emit(sourceMethodCall, sourceGetMethod);
                            il.Emit(ldTargetTypeArg, 2);
                            il.Emit(targetMethodCall, targetGetMethod);
                            il.Emit(OpCodes.Ldarg_3);
                            if (sourceProperty.IsNullableT || targetProperty.IsNullableT) { md = _MapInternal_Method; }
                            else if (sourceProperty_PropertyType.IsClass && targetProperty_PropertyType.IsClass) { md = _MapInternal_Class_Class_Method; }
                            else if (sourceProperty_PropertyType.IsClass && targetProperty_PropertyType.IsValueType) { md = _MapInternal_Class_Struct_Method; }
                            else if (sourceProperty_PropertyType.IsValueType && targetProperty_PropertyType.IsClass) { md = _MapInternal_Struct_Class_Method; }
                            else if (sourceProperty_PropertyType.IsValueType && targetProperty_PropertyType.IsValueType) { md = _MapInternal_Struct_Struct_Method; }
                            il.Emit(OpCodes.Callvirt, md.MakeGenericMethod(sourceProperty_PropertyType, targetProperty_PropertyType));
                        }
                        //il.Emit(OpCodes.Pop);
                        il.Emit(targetMethodCall, targetSetMethod);
                        #endregion
                    }
                }
                #endregion
            }
            il.MarkLabel(endOfMethodLabel);
            il.Emit(OpCodes.Ldarg_2);
            il.Emit(OpCodes.Ret);

            var f = typeof(Func<,,,,>);
            var gf = f.MakeGenericType(typeof(ObjectMapConfig), sourceType, targetType, typeof(MappingContext), targetType);
            return dm.CreateDelegate(gf);
        }

        private static Boolean IsPrimitive(Type type)
        {
            return type.IsEnum || _PrimitiveValueTypes.Contains(type);
        }
        private static Boolean IsNumber(Type type)
        {
            return type == typeof(SByte) || type == typeof(Int16) || type == typeof(Int32) || type == typeof(Int64) ||
                type == typeof(Byte) || type == typeof(UInt16) || type == typeof(UInt32) || type == typeof(UInt64) ||
                type == typeof(Single) || type == typeof(Double) || type == typeof(Decimal);
        }
        private static Boolean IsImmutable(Type type)
        {
            if (type == typeof(String)) return true;
            if (type == typeof(Encoding)) return true;
            if (type.IsValueType) return true;
            return false;
        }
        private static MethodInfo GetTypeConverterToTypeMethodInfo(Type type)
        {
            MethodInfo md = null;
            if (type.IsEnum)
            {
                if (_TypeConverter_ToEnumMethods.TryGetValue(type, out md) == true) { return md; }
                md = typeof(TypeConverter).GetMethod("ToEnum", new Type[] { typeof(Object) }).MakeGenericMethod(type);
                _TypeConverter_ToEnumMethods.TryAdd(type, md);
                return md;
            }
            else
            {
                if (_TypeConverter_ToTypeMethods.TryGetValue(type, out md) == true) { return md; }
            }
            return null;
        }
    }
}
