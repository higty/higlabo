using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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
        private readonly ConcurrentDictionary<ObjectMapTypeInfo, Delegate> _Methods = new ConcurrentDictionary<ObjectMapTypeInfo, Delegate>();

        private static readonly MethodInfo _MapMethod = null;
        private static readonly MethodInfo _MapToMethod = null;
        private static readonly MethodInfo _MapReferenceMethod = null;
        private static readonly MethodInfo _MappingContext_NullPropertyMapMode_GetMethod = null;
        private static readonly MethodInfo _MappingContext_CollectionElementMapMode_GetMethod = null;
        private static readonly MethodInfo _ObjectMapConfig_TypeConverterProperty_GetMethod = null;

        private List<MapPostAction> _PostActions = new List<MapPostAction>();

        public List<PropertyMappingRule> PropertyMapRules { get; private set; }
        public TypeConverter TypeConverter { get; set; }
        public Int32 MaxCallStack { get; set; }
        public StringComparer DictionaryKeyStringComparer { get; set; }
        public NullPropertyMapMode NullPropertyMapMode { get; set; }
        public CollectionElementMapMode CollectionElementMapMode { get; set; }

        static ObjectMapConfig()
        {
            Current = new ObjectMapConfig();
            _MapMethod = GetMethodInfo("Map");
            _MapToMethod = GetMethodInfo("MapTo");
            _MapReferenceMethod = GetMethodInfo("MapReference");
            _MappingContext_NullPropertyMapMode_GetMethod = typeof(MappingContext).GetProperty("NullPropertyMapMode", BindingFlags.Instance | BindingFlags.Public).GetGetMethod();
            _MappingContext_CollectionElementMapMode_GetMethod = typeof(MappingContext).GetProperty("CollectionElementMapMode", BindingFlags.Instance | BindingFlags.Public).GetGetMethod();
            _ObjectMapConfig_TypeConverterProperty_GetMethod = typeof(ObjectMapConfig).GetProperty("TypeConverter", BindingFlags.Instance | BindingFlags.Public).GetGetMethod();
        }
        public ObjectMapConfig()
        {
            this.TypeConverter = new TypeConverter();

            this.PropertyMapRules = new List<PropertyMappingRule>();
            this.PropertyMapRules.Add(new DefaultPropertyMappingRule());
            this.PropertyMapRules.Add(new DictionaryToObjectMappingRule());
            
            this.MaxCallStack = 100;
            this.DictionaryKeyStringComparer = StringComparer.InvariantCultureIgnoreCase;
        }
        private static MethodInfo GetMethodInfo(String name)
        {
            return typeof(ObjectMapConfig).GetMethods().Where(el => el.GetCustomAttributes().Any(attr => attr is ObjectMapConfigMethodAttribute && ((ObjectMapConfigMethodAttribute)attr).Name == name)).FirstOrDefault();
        }
        private MappingContext CreateMappingContext()
        {
            return new MappingContext(this.DictionaryKeyStringComparer, this.NullPropertyMapMode, this.CollectionElementMapMode);
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
        [ObjectMapConfigMethod(Name = "Map")]
        public TTarget Map<TSource, TTarget>(TSource source, TTarget target, MappingContext context)
        {
            if (source == null || target == null) { return target; }
            var kv = new KeyValuePair<object, object>(source, target);
            if (context.Exists(kv)) { return target; }
            if (context.CallStackCount > this.MaxCallStack)
            {
                throw new InvalidOperationException("Map method recursively called over " + this.MaxCallStack + ".");
            }
            if (source is IDataReader)
            {
                return this.MapIDataReader(source as IDataReader, target, context);
            }
            var md = this.GetMethod<TSource, TTarget>(source, target);
            TTarget result = default(TTarget);
            try
            {
                context.CallStackCount++;
                result = md(this, source, target, context);
                context.CallStackCount--;
            }
            catch (TargetInvocationException ex)
            {
                throw new ObjectMapFailureException("Generated map method was failed.Maybe HigLabo.Mapper bug."
                    + "Please notify SouceObject,TargetObject class of this ObjectMapFailureException object to auther."
                    + "We will fix it." + Environment.NewLine
                    + String.Format("SourceType={0}, TargetType={1}", source.GetType().Name, target.GetType().Name)
                    , source, target, ex.InnerException);
            }
            if (_PostActions.Count > 0)
            {
                result = this.CallPostAction(source, result);
            }
            return result;
        }
        private TTarget MapIDataReader<TTarget>(IDataReader source, TTarget target, MappingContext context)
        {
            Dictionary<String, Object> d = new Dictionary<String, Object>(context.DictionaryKeyStringComparer);
            d.SetValues((IDataReader)source);
            return this.Map(d, target, context);
        }
        [ObjectMapConfigMethod(Name = "MapTo")]
        public ICollection<TTarget> MapTo<TSource, TTarget>(IEnumerable<TSource> source, ICollection<TTarget> target)
            where TTarget : new()
        {
            return this.MapTo(source, target, () => new TTarget());
        }
        public ICollection<TTarget> MapTo<TSource, TTarget>(IEnumerable<TSource> source, ICollection<TTarget> target
            , Func<TTarget> elementConstructor)
        {
            if (source != null && target != null)
            {
                foreach (var item in source)
                {
                    var o = this.Map(item, elementConstructor());
                    target.Add(o);
                }
            }
            return target;
        }
        [ObjectMapConfigMethod(Name = "MapReference")]
        public ICollection<TTarget> MapReference<TSource, TTarget>(IEnumerable<TSource> source, ICollection<TTarget> target)
           where TSource : TTarget
        {
            if (source != null && target != null)
            {
                foreach (var item in source)
                {
                    target.Add(item);
                }
            }
            return target;
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
            this.ReplaceMap(selector, action);
        }
        private void ReplaceMap<TSource, TTarget>(Func<PropertyMap, Boolean> selector)
        {
            ReplaceMap<TSource, TTarget>(selector, null);
        }
        private void ReplaceMap<TSource, TTarget>(Func<PropertyMap, Boolean> selector, Action<TSource, TTarget> action)
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
            var md = this.CreateMethod<TSource, TTarget>(key, mappings);
            _Methods[key] = md;

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

            var condition = new MappingCondition();
            condition.Source.Type = typeof(TSource);
            condition.Source.TypeFilterCondition = sourceCondition;
            condition.Target.Type = typeof(TTarget);
            condition.Target.TypeFilterCondition = targetCondition;
            _PostActions.Add(new MapPostAction(condition, (Delegate)action));
        }
        private TTarget CallPostAction<TSource, TTarget>(TSource source, TTarget target)
        {
            var sourceType = source.GetType();
            var targetType = target.GetType();
            for (int i = 0; i < _PostActions.Count; i++)
            {
                if (_PostActions[i].Condition.Match(sourceType, targetType) == false) { continue; }
                var f = (Func<TSource, TTarget, TTarget>)_PostActions[i].Action;
                return f(source, target);
            }
            return target;
        }

        private Func<ObjectMapConfig,TSource,TTarget,MappingContext,TTarget> GetMethod<TSource, TTarget>(TSource source, TTarget target)
        {
            Delegate md = null;
            var key = new ObjectMapTypeInfo(source.GetType(), target.GetType());
            if (_Methods.TryGetValue(key, out md) == false)
            {
                var l = this.CreatePropertyMaps(key.Source, key.Target);
                md = this.CreateMethod<TSource, TTarget>(key, l);
                _Methods[key] = md;
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
                sourceProperties.AddRange(item.GetProperties(BindingFlags.Public | BindingFlags.Instance));
            }
            foreach (var item in targetTypes)
            {
                targetProperties.AddRange(item.GetProperties(BindingFlags.Public | BindingFlags.Instance));
            }
            //Find target property by rules...
            foreach (PropertyMappingRule rule in this.PropertyMapRules)
            {
                //Validate to apply this rule
                if (rule.Condition.Match(sourceType, targetType) == false) { continue; }

                List<PropertyInfo> addedTargetPropertyMapInfo = new List<PropertyInfo>();
                //Object --> Object, Dictionary --> Object
                foreach (var piTarget in targetProperties)
                {
                    //Search property that meet condition
                    var piSource = sourceProperties.Find(el => rule.Match(el, piTarget));
                    if (piSource != null)
                    {
                        l.Add(new PropertyMap(piSource, piTarget));
                        addedTargetPropertyMapInfo.Add(piTarget);
                    }
                }
                //Remove added target property
                for (int i = 0; i < addedTargetPropertyMapInfo.Count; i++)
                {
                    targetProperties.Remove(addedTargetPropertyMapInfo[i]);
                }
            }
            //Object --> Dictionary<String, T>
            var piTargetItem = targetType.GetProperty("Item", new Type[] { typeof(String) });
            if (piTargetItem != null)
            {
                foreach (var piSource in sourceProperties)
                {
                    l.Add(new PropertyMap(piSource, piTargetItem));
                }
            }
            return l;
        }
        private Func<ObjectMapConfig, TSource, TTarget, MappingContext, TTarget> CreateMethod<TSource, TTarget>(ObjectMapTypeInfo key, IEnumerable<PropertyMap> propertyMapInfo)
        {
            return (Func<ObjectMapConfig, TSource, TTarget, MappingContext, TTarget>)this.CreateMethod(key.Source, key.Target, propertyMapInfo);
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
        ///     }
        ///     return;
        /// }
        /// else if (Map for other case...)
        /// {
        ///     switch (context.NullPropertyMapMode)
        ///     {
        ///         case NullPropertyMapMode.NewObject: target.P1 = new XXX(); break;
        ///         case NullPropertyMapMode.CopyReference: 
        ///         {
        ///             if (typeof(source) inheritant from typeof(parent))
        ///             {
        ///                 target.P1 = source.P1; 
        ///             }
        ///             break;
        ///         }
        ///     }
        ///     if (this.NullPropertyMapMode == NullPropertyMapMode.None &&
        ///         target.P1 is Nullable or Class)
        ///     {
        ///         target.P1 = null;
        ///     }
        ///     else if (source is IEnumerable and target is ICollection)
        ///     {
        ///         switch (context.collectionelementmapmode)
        ///         {
        ///             case collectionelementmapmode.newobject: this.mapto(source, target); break;
        ///             case collectionelementmapmode.copyreference: this.mapreference(source, target); break;
        ///         }
        ///     }
        ///     else
        ///     {
        ///         source.P1.Map(target.P1);
        ///     }
        /// }
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="propertyMapInfo"></param>
        /// <returns></returns>
        private Delegate CreateMethod(Type sourceType, Type targetType, IEnumerable<PropertyMap> propertyMapInfo)
        {
            DynamicMethod dm = new DynamicMethod("SetProperty", targetType, new[] { typeof(ObjectMapConfig), sourceType, targetType, typeof(MappingContext) });
            ILGenerator il = dm.GetILGenerator();
            Label methodEnd = il.DefineLabel();

            var typeConverterVal = il.DeclareLocal(typeof(TypeConverter));
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Callvirt, _ObjectMapConfig_TypeConverterProperty_GetMethod);
            il.SetLocal(typeConverterVal);//ObjectMapConfig.TypeConverter

            var collectionMapMode = il.DeclareLocal(typeof(CollectionElementMapMode));
            il.Emit(OpCodes.Ldarg_3);//MappingContext
            il.Emit(OpCodes.Callvirt, _MappingContext_CollectionElementMapMode_GetMethod);
            il.SetLocal(collectionMapMode);

            var nullPropertyMapMode = il.DeclareLocal(typeof(NullPropertyMapMode));
            il.Emit(OpCodes.Ldarg_3);//MappingContext
            il.Emit(OpCodes.Callvirt, _MappingContext_NullPropertyMapMode_GetMethod);
            il.SetLocal(nullPropertyMapMode);

            foreach (var item in propertyMapInfo)
            {
                var getMethod = item.Source.PropertyInfo.GetGetMethod();
                var setMethod = item.Target.PropertyInfo.GetSetMethod();
                #region DefineLabel
                Label nullPropertyMapLabel = il.DefineLabel();
                Label setValueStartLabel = il.DefineLabel();
                Label setNullToTargetLabel = il.DefineLabel();
                Label endOfCode = il.DefineLabel();
                #endregion
                var sourceVal = il.DeclareLocal(item.Source.ActualType);
                var targetVal = il.DeclareLocal(item.Target.ActualType);
                #region val sourceVal = source.P1; //GetValue from SourceObject. 

                //Get value from source property.
                if (item.Source.IsIndexedProperty == true)
                {
                    // var sourceVal = source["P1"];
                    #region Dictionary<String, String> or Dictionary<String, Object>
                    //Call TryGetValue method to avoid KeyNotFoundException
                    if (sourceType.IsInheritanceFrom(typeof(Dictionary<String, String>)) == true ||
                        sourceType.IsInheritanceFrom(typeof(Dictionary<String, Object>)) == true)
                    {
                        //Call ContainsKey method.If key does not exist, exit method.
                        var containsKey = sourceType.GetMethod("ContainsKey");
                        il.Emit(OpCodes.Ldarg_1);
                        il.Emit(OpCodes.Ldstr, item.Source.IndexedPropertyKey);
                        il.Emit(OpCodes.Callvirt, containsKey);
                        il.Emit(OpCodes.Brfalse, endOfCode); //ContainsKey=false --> Exit method without do anything.
                    }
                    //source[string key]
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Ldstr, item.Source.IndexedPropertyKey);
                    il.Emit(OpCodes.Callvirt, getMethod);
                    #endregion
                }
                else
                {
                    // var sourceVal = source.P1;
                    if (sourceType.IsValueType)
                    {
                        il.Emit(OpCodes.Ldarga_S, 1);
                        il.Emit(OpCodes.Call, getMethod);
                    }
                    else
                    {
                        il.Emit(OpCodes.Ldarg_1);
                        il.Emit(OpCodes.Callvirt, getMethod);
                    }
                }
                //Check source.P1 is null. If null, goto target.P1 = null.
                if (item.Source.CanBeNull == true)
                {
                    if (item.Source.IsNullableT == true)
                    {
                        #region if (source.P1.HasValue == false)
                        var sourceValN = il.DeclareLocal(item.Source.PropertyType);

                        il.SetLocal(sourceValN);
                        //if (sourceValue.HasValue == true)
                        il.LoadLocala(sourceValN);
                        il.Emit(OpCodes.Call, item.Source.PropertyType.GetProperty("HasValue").GetGetMethod());
                        il.Emit(OpCodes.Brfalse, setNullToTargetLabel); //null --> set target null
                        il.LoadLocala(sourceValN);
                        //sourceVal.Value
                        il.Emit(OpCodes.Call, item.Source.PropertyType.GetMethod("GetValueOrDefault", Type.EmptyTypes));
                        #endregion
                    }
                    else if (item.Source.CanBeNull == true)
                    {
                        #region if (source.P1 == null)
                        Type sourceTypeN = item.Source.ActualType;
                        var sourceValN = il.DeclareLocal(sourceTypeN);
                        il.SetLocal(sourceValN);
                        //if (sourceValue == null)
                        il.LoadLocal(sourceValN);
                        il.Emit(OpCodes.Ldnull);
                        il.Emit(OpCodes.Ceq);
                        il.Emit(OpCodes.Brtrue, setNullToTargetLabel); //null --> set target null
                        il.LoadLocal(sourceValN);
                        #endregion
                    }
                }
                //store sourceVal (never be null)
                il.SetLocal(sourceVal);
                #endregion

                #region var convertedVal = TypeConverter.ToXXX(sourceVal); //Convert value to target type.
                LocalBuilder convertedVal = null;
                var directSetValue = false;
                var methodName = GetMethodName(item.Target.ActualType);
                if (item.Source.ActualType == item.Target.ActualType &&
                    IsDirectSetValue(item.Source.ActualType))
                {
                    #region var convertedVal = sourceVal;
                    il.LoadLocal(sourceVal);
                    il.SetLocal(targetVal);
                    directSetValue = true;
                    #endregion
                }
                else if (item.Target.ActualType.IsEnum == true || methodName != null)
                {
                    #region var convertedVal = TypeConverter.ToXXX(sourceVal);
                    //Call TypeConverter.ToXXX(sourceVal);
                    il.LoadLocal(typeConverterVal);//MapConfig.TypeConverter
                    il.LoadLocal(sourceVal);
                    if (item.Source.ActualType.IsValueType == true)
                    {
                        il.Emit(OpCodes.Box, item.Source.ActualType);
                    }
                    if (item.Target.ActualType.IsEnum == true)
                    {
                        il.Emit(OpCodes.Callvirt, typeof(TypeConverter).GetMethod("ToEnum", new Type[] { typeof(Object) }).MakeGenericMethod(item.Target.ActualType));
                    }
                    else
                    {
                        il.Emit(OpCodes.Callvirt, typeof(TypeConverter).GetMethod(methodName, new Type[] { typeof(Object) }));
                    }

                    Label ifConvertedValueNotNullBlock = il.DefineLabel();
                    if (item.Target.ActualType == typeof(String) ||
                        item.Target.ActualType == typeof(Encoding))
                    {
                        convertedVal = il.DeclareLocal(item.Target.ActualType);
                        il.SetLocal(targetVal);
                        il.LoadLocal(targetVal);
                        il.Emit(OpCodes.Ldnull);
                        il.Emit(OpCodes.Ceq);
                        il.Emit(OpCodes.Brfalse_S, ifConvertedValueNotNullBlock);
                        {
                            il.Emit(OpCodes.Br_S, nullPropertyMapLabel);
                        }
                        il.MarkLabel(ifConvertedValueNotNullBlock);
                    }
                    else
                    {
                        Type targetTypeN = typeof(Nullable<>).MakeGenericType(item.Target.ActualType);
                        convertedVal = il.DeclareLocal(targetTypeN);
                        //SetValue to TargetObject
                        il.SetLocal(convertedVal);
                        il.LoadLocala(convertedVal);
                        il.Emit(OpCodes.Call, targetTypeN.GetProperty("HasValue").GetGetMethod());
                        il.Emit(OpCodes.Brtrue_S, ifConvertedValueNotNullBlock);
                        {
                            il.Emit(OpCodes.Br_S, nullPropertyMapLabel);
                        }
                        il.MarkLabel(ifConvertedValueNotNullBlock);
                        //GetValue
                        il.LoadLocala(convertedVal);
                        il.Emit(OpCodes.Call, targetTypeN.GetMethod("GetValueOrDefault", Type.EmptyTypes));
                        il.SetLocal(targetVal);
                    }
                    #endregion
                }
                else
                {
                    //target["P1"] = source; 
                    //source.P1.Map(target.P1);
                    #region 
                    convertedVal = il.DeclareLocal(item.Target.ActualType);
                    if (item.Target.IsIndexedProperty)
                    {
                        il.LoadLocal(sourceVal);
                        if (item.Source.ActualType.IsValueType == true)
                        {
                            //Boxing to Object
                            il.Emit(OpCodes.Box, item.Source.ActualType);
                        }
                        il.SetLocal(targetVal);
                        il.Emit(OpCodes.Br_S, setValueStartLabel);
                    }
                    il.Emit(OpCodes.Br_S, nullPropertyMapLabel);
                    #endregion
                }
                il.Emit(OpCodes.Br_S, setValueStartLabel);
                #endregion

                il.MarkLabel(nullPropertyMapLabel);
                if (directSetValue == false)
                {
                    #region if (target.P1 ==null) { ... }
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Callvirt, item.Target.PropertyInfo.GetGetMethod());
                    il.SetLocal(targetVal);

                    if (item.Target.CanBeNull)
                    {
                        il.LoadLocal(targetVal);
                        il.Emit(OpCodes.Ldnull);
                        il.Emit(OpCodes.Ceq);
                        Label ifTargetIsNotNull = il.DefineLabel();
                        il.Emit(OpCodes.Brfalse, ifTargetIsNotNull);
                        {
                            #region if (context.NullPropertyMapMode == NullPropertyMapMode.NewObjec) { target = new TTarget(); }
                            il.LoadLocal(nullPropertyMapMode);
                            il.Emit(OpCodes.Ldc_I4, (Int32)NullPropertyMapMode.NewObject);
                            il.Emit(OpCodes.Ceq);
                            Label ifNullMapModeIsNotNewObject = il.DefineLabel();
                            il.Emit(OpCodes.Brfalse, ifNullMapModeIsNotNewObject);
                            {
                                var constructor = item.Target.PropertyType.GetConstructor(Type.EmptyTypes);
                                if (constructor != null && constructor.IsPublic)
                                {
                                    il.Emit(OpCodes.Newobj, constructor);
                                    il.SetLocal(targetVal);
                                    if (item.Target.ActualType.FullName.StartsWith(System_Collections_Generic_Dictionary_2))
                                    {
                                        il.Emit(OpCodes.Ldarg_2);
                                        il.LoadLocal(targetVal);
                                        il.Emit(OpCodes.Callvirt, setMethod);
                                    }
                                }
                            }
                            il.MarkLabel(ifNullMapModeIsNotNewObject);
                            #endregion

                            #region if (context.NullPropertyMapMode == NullPropertyMapMode.CopyReference) { target = source; }
                            if (item.Source.ActualType.IsInheritanceFrom(item.Target.ActualType))
                            {
                                il.LoadLocal(nullPropertyMapMode);
                                il.Emit(OpCodes.Ldc_I4, (Int32)NullPropertyMapMode.CopyReference);
                                il.Emit(OpCodes.Ceq);
                                Label ifNullMapModeIsNotCopyReference = il.DefineLabel();
                                il.Emit(OpCodes.Brfalse, ifNullMapModeIsNotCopyReference);
                                {
                                    il.LoadLocal(sourceVal);
                                    il.SetLocal(targetVal);
                                }
                                il.MarkLabel(ifNullMapModeIsNotCopyReference);
                            }
                            #endregion
                        }
                        il.MarkLabel(ifTargetIsNotNull);
                    }
                    #endregion

                    #region source.P1.Map(target.P1); //Call Map method
                    if (this.IsEnumerableToCollection(item))
                    {
                        var sInterface = item.Source.ActualType.GetInterfaces().FirstOrDefault(el => el.FullName.StartsWith(System_Collections_Generic_IEnumerable_1));
                        var tInterface = item.Target.ActualType.GetInterfaces().FirstOrDefault(el => el.FullName.StartsWith(System_Collections_Generic_IEnumerable_1));
                        if (sInterface != null && tInterface != null)
                        {
                            var sourceElementType = sInterface.GenericTypeArguments[0];
                            var targetElementType = tInterface.GenericTypeArguments[0];
                            if (targetElementType.GetConstructor(Type.EmptyTypes) != null)
                            {
                                #region if (mode == CollectionElementMapMode.NewObject) { source.P1.MapTo(target); }
                                il.LoadLocal(collectionMapMode);
                                il.Emit(OpCodes.Ldc_I4, (Int32)CollectionElementMapMode.NewObject);
                                il.Emit(OpCodes.Ceq);
                                Label ifMapModeIsNotNewObject = il.DefineLabel();
                                il.Emit(OpCodes.Brfalse, ifMapModeIsNotNewObject); //_MapToMethod
                                {
                                    il.Emit(OpCodes.Ldarg_0);//ObjectMapConfig instance
                                    il.LoadLocal(sourceVal);
                                    il.LoadLocal(targetVal);
                                    il.Emit(OpCodes.Call, _MapToMethod.MakeGenericMethod(sourceElementType, targetElementType));
                                    il.Emit(OpCodes.Pop);
                                }
                                il.MarkLabel(ifMapModeIsNotNewObject);
                                #endregion
                            }

                            if (sourceElementType.IsInheritanceFrom(targetElementType))
                            {
                                #region if (mode == CollectionElementMapMode.CopyReference) { source.P1.MapReference(target); }
                                il.LoadLocal(collectionMapMode);
                                il.Emit(OpCodes.Ldc_I4, (Int32)CollectionElementMapMode.CopyReference);
                                il.Emit(OpCodes.Ceq);
                                Label ifMapModeIsNotCopyReference = il.DefineLabel();
                                il.Emit(OpCodes.Brfalse, ifMapModeIsNotCopyReference); //_MapReferenceMethod
                                {
                                    il.Emit(OpCodes.Ldarg_0);//ObjectMapConfig instance
                                    il.LoadLocal(sourceVal);
                                    il.LoadLocal(targetVal);
                                    il.Emit(OpCodes.Call, _MapReferenceMethod.MakeGenericMethod(sourceElementType, targetElementType));
                                    il.Emit(OpCodes.Pop);
                                }
                                il.MarkLabel(ifMapModeIsNotCopyReference);
                                #endregion
                            }
                        }
                    }
                    else
                    {
                        //Call Map method when convert failed try to get target value.
                        #region source.P1.Map(target.P1); //Call Map method

                        il.Emit(OpCodes.Ldarg_0);//ObjectMapConfig instance
                        il.LoadLocal(sourceVal);
                        il.LoadLocal(targetVal);
                        il.Emit(OpCodes.Ldarg_3);//MappingContext
                        il.Emit(OpCodes.Call, _MapMethod.MakeGenericMethod(item.Source.ActualType, item.Target.PropertyType));
                        il.SetLocal(targetVal);
                        il.Emit(OpCodes.Br, setValueStartLabel);
                        #endregion
                    }
                    if (item.Target.CanBeNull)
                    {
                        il.LoadLocal(targetVal);
                        il.Emit(OpCodes.Ldnull);
                        il.Emit(OpCodes.Ceq);
                        il.Emit(OpCodes.Brtrue, endOfCode);
                        il.Emit(OpCodes.Br, setValueStartLabel);
                    }
                    else
                    {
                        il.Emit(OpCodes.Br, endOfCode);
                    }
                    #endregion
                }

                il.MarkLabel(setValueStartLabel);
                #region target.P1 = source.P1; //Set value to TargetProperty
                if (setMethod != null)
                {
                    if (targetType.IsClass) { il.Emit(OpCodes.Ldarg_2); }
                    else if (targetType.IsValueType) { il.Emit(OpCodes.Ldarga_S, 2); }
                    if (item.Target.IsIndexedProperty == true)
                    {
                        //target["P1"] = source.P1;
                        il.Emit(OpCodes.Ldstr, item.Target.IndexedPropertyKey);
                    }
                    il.LoadLocal(targetVal);
                    if (item.Target.IsNullableT == true)
                    {
                        //new Nullable<T>(new T());
                        il.Emit(OpCodes.Newobj, item.Target.PropertyType.GetConstructor(new Type[] { item.Target.ActualType }));
                    }
                    if (targetType.IsClass) { il.Emit(OpCodes.Callvirt, setMethod); }
                    else if (targetType.IsValueType) { il.Emit(OpCodes.Call, setMethod); }
                    il.Emit(OpCodes.Br, endOfCode);
                }
                #endregion

                il.MarkLabel(setNullToTargetLabel);
                #region target.P1 = null. //Set Null to Target property.
                if (setMethod != null)
                {
                    if (item.Target.CanBeNull == true)
                    {
                        il.Emit(OpCodes.Ldarg_2);
                        if (item.Target.IsIndexedProperty == true)
                        {
                            //target["P1"] = source.P1;
                            il.Emit(OpCodes.Ldstr, item.Target.IndexedPropertyKey);
                        }
                        if (item.Target.IsNullableT == true)
                        {
                            var targetValN = il.DeclareLocal(item.Target.PropertyType);
                            il.LoadLocala(targetValN);
                            il.Emit(OpCodes.Initobj, item.Target.PropertyType);
                            il.LoadLocal(targetValN);
                        }
                        else
                        {
                            il.Emit(OpCodes.Ldnull);
                        }
                        il.Emit(OpCodes.Callvirt, setMethod);
                    }
                    il.Emit(OpCodes.Br_S, endOfCode);
                }
                #endregion

                il.MarkLabel(endOfCode);
                il.Emit(OpCodes.Nop);
            }
            il.MarkLabel(methodEnd);
            il.Emit(OpCodes.Ldarg_2);
            il.Emit(OpCodes.Ret);

            var f = typeof(Func<,,,,>);
            var gf = f.MakeGenericType(typeof(ObjectMapConfig), sourceType, targetType, typeof(MappingContext), targetType);
            return dm.CreateDelegate(gf);
        }
        private Boolean IsEnumerableToCollection(PropertyMap propertyMap)
        {
            var sType = propertyMap.Source.ActualType;
            var tType = propertyMap.Target.ActualType;

            if (propertyMap.Source.IsIndexedProperty == true || propertyMap.Target.IsIndexedProperty == true) { return false; }
            if (sType.GenericTypeArguments.Length == 0 || tType.GenericTypeArguments.Length == 0) { return false; }
            //Never use lambda expresion to improve performance.To avoid object creation.
            foreach (var sInterface in sType.GetInterfaces())
            {
                if (sInterface.FullName.StartsWith(System_Collections_Generic_IEnumerable_1))
                {
                    foreach (var tInterface in tType.GetInterfaces())
                    {
                        if (tInterface.FullName.StartsWith(System_Collections_Generic_ICollection_1)) { return true; }
                    }
                }
            }
            return false;
        }
        private static Boolean IsDirectSetValue(Type type)
        {
            if (type == typeof(String)) return true;
            if (type.IsValueType) return true;
            return false;
        }
        private static String GetMethodName(Type type)
        {
            if (type == typeof(String)) return "ToString";
            if (type == typeof(Boolean)) return "ToBoolean";
            if (type == typeof(Guid)) return "ToGuid";
            if (type == typeof(SByte)) return "ToSByte";
            if (type == typeof(Int16)) return "ToInt16";
            if (type == typeof(Int32)) return "ToInt32";
            if (type == typeof(Int64)) return "ToInt64";
            if (type == typeof(Byte)) return "ToByte";
            if (type == typeof(UInt16)) return "ToUInt16";
            if (type == typeof(UInt32)) return "ToUInt32";
            if (type == typeof(UInt64)) return "ToUInt64";
            if (type == typeof(Single)) return "ToSingle";
            if (type == typeof(Double)) return "ToDouble";
            if (type == typeof(Decimal)) return "ToDecimal";
            if (type == typeof(TimeSpan)) return "ToTimeSpan";
            if (type == typeof(DateTime)) return "ToDateTime";
            if (type == typeof(DateTimeOffset)) return "ToDateTimeOffset";
            if (type == typeof(Encoding)) return "ToEncoding";
            return null;
        }
    }
}
