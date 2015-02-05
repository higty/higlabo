using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
        public class MappingContext
        {
            internal List<KeyValuePair<Object, Object>> MappedObjectPair { get; private set; }
            public Int32 CallStackCount { get; internal set; }

            internal MappingContext()
            {
                this.MappedObjectPair = new List<KeyValuePair<Object, Object>>();
            }
        }

        public static ObjectMapConfig Current { get; private set; }

        private readonly ConcurrentDictionary<ObjectMapTypeInfo, Delegate> _Methods = new ConcurrentDictionary<ObjectMapTypeInfo, Delegate>();

        private MethodInfo _MapMethod = null;
        private MethodInfo _ConvertClassMethod = null;
        private MethodInfo _ConvertStructureMethod = null;
        private MethodInfo _DictionaryExtensionsSetValuesMethod = null;
        private List<MapPostAction> _PostActions = new List<MapPostAction>();
        private ConcurrentDictionary<Type, Delegate> _ClassConverters = new ConcurrentDictionary<Type, Delegate>();
        private ConcurrentDictionary<Type, Delegate> _StructConverters = new ConcurrentDictionary<Type, Delegate>();

        public List<PropertyMappingRule> PropertyMapRules { get; private set; }
        public TypeConverter TypeConverter { get; set; }
        public Int32 MaxCallStack { get; set; }

        static ObjectMapConfig()
        {
            Current = new ObjectMapConfig();
        }
        public ObjectMapConfig()
        {
            this.TypeConverter = new TypeConverter();

            this.PropertyMapRules = new List<PropertyMappingRule>();
            this.PropertyMapRules.Add(new DefaultPropertyMappingRule());
            this.PropertyMapRules.Add(new DictionaryToObjectMappingRule());
            this.AddConverter<Object>(o => o);

            this.MaxCallStack = 100;
            _MapMethod = this.GetMethodInfo("Map");
            _ConvertClassMethod = this.GetMethodInfo("ConvertClass");
            _ConvertStructureMethod = this.GetMethodInfo("ConvertStructure");
            _DictionaryExtensionsSetValuesMethod = typeof(DictionaryExtensions).GetMethod("SetValues");
        }
        private MethodInfo GetMethodInfo(String name)
        {
            return typeof(ObjectMapConfig).GetMethods().Where(el => el.GetCustomAttributes().Any(attr => attr is ObjectMapConfigMethodAttribute && ((ObjectMapConfigMethodAttribute)attr).Name == name)).FirstOrDefault();
        }

        public TTarget Map<TSource, TTarget>(TSource source, TTarget target)
        {
            return this.Map(source, target, new MappingContext());
        }
        public TTarget MapOrNull<TSource, TTarget>(TSource source, TTarget target)
            where TTarget : class
        {
            if (source == null) return null;
            return this.Map(source, target, new MappingContext());
        }
        [ObjectMapConfigMethodAttribute(Name = "Map")]
        public TTarget Map<TSource, TTarget>(TSource source, TTarget target, MappingContext context)
        {
            if (source == null || target == null) { return target; }
            if (context.CallStackCount > this.MaxCallStack)
            {
                throw new InvalidOperationException("Map method recursively called over " + this.MaxCallStack + ".");
            }
            var md = this.GetMethod<TSource, TTarget>();
            try
            {
                context.CallStackCount++;
                var result = (TTarget)md.DynamicInvoke(source, target, context);
                context.CallStackCount--;
                return result;
            }
            catch (TargetInvocationException ex)
            {
#if DEBUG
                throw;
#else
                throw new ObjectMapFailureException("Generated map method was failed.Maybe HigLabo.Mapper bug."
                    + "Please notify SouceObject,TargetObject class of this ObjectMapFailureException object to auther."
                    + "We will fix it."
                    , source, target, ex.InnerException);
#endif
            }
        }
        public IEnumerable<TTarget> Map<TSource, TTarget>(IEnumerable<TSource> source, Func<TTarget> constructor)
        {
            return Map(source, constructor, new MappingContext());
        }
        private IEnumerable<TTarget> Map<TSource, TTarget>(IEnumerable<TSource> source, Func<TTarget> constructor, MappingContext context)
        {
            return source.Select(el => el.Map(constructor()));
        }

        public void RemovePropertyMap<TSource, TTarget>(IEnumerable<String> targetPropertyNames, Action<TSource, TTarget> action)
        {
            var l = new List<String>(targetPropertyNames);
            this.RemovePropertyMap<TSource, TTarget>(propertyMap => targetPropertyNames.Contains(propertyMap.Target.Name), action);
        }
        public void RemovePropertyMap<TSource, TTarget>(Func<PropertyMap, Boolean> selector)
        {
            this.RemovePropertyMap<TSource, TTarget>(selector, null);
        }
        public void RemovePropertyMap<TSource, TTarget>(Func<PropertyMap, Boolean> selector, Action<TSource, TTarget> action)
        {
            this.ReplaceMap(map =>
            {
                var l = map.PropertyMaps.Where(selector).ToList();
                for (int i = 0; i < l.Count; i++)
                {
                    map.PropertyMaps.Remove(l[i]);
                }
            }, action);
        }
        private void ReplaceMap<TSource, TTarget>(Action<ObjectMap> mapConfiguration)
        {
            ReplaceMap<TSource, TTarget>(mapConfiguration, null);
        }
        private void ReplaceMap<TSource, TTarget>(Action<ObjectMap> mapConfiguration, Action<TSource, TTarget> action)
        {
            var key = new ObjectMapTypeInfo(typeof(TSource), typeof(TTarget));
            var mappings = this.CreatePropertyMaps(key.Source, key.Target);
            var om = new ObjectMap(mappings);
            mapConfiguration(om);
            var md = this.CreateMethod<TSource, TTarget>(om.PropertyMaps);
            _Methods[key] = md;

            this.AddPostAction(action);
        }

        public void AddConverter<T>(Func<Object, Nullable<T>> converter) where T : struct
        {
            _StructConverters[typeof(T)] = converter;
        }
        public void AddConverter<T>(Func<Object, T> converter) where T : class
        {
            _ClassConverters[typeof(T)] = converter;
        }
        [ObjectMapConfigMethodAttribute(Name = "ConvertStructure")]
        public Boolean Convert<T>(Object value, out Nullable<T> convertedValue) where T : struct
        {
            convertedValue = default(T);
            Delegate converterDelegate = null;
            if (_StructConverters.TryGetValue(typeof(T), out converterDelegate) == false) return false;
            var converter = (Func<Object, Nullable<T>>)converterDelegate;
            convertedValue = converter(value);
            return convertedValue.HasValue;
        }
        [ObjectMapConfigMethodAttribute(Name = "ConvertClass")]
        public Boolean Convert<T>(Object value, out T convertedValue) where T : class
        {
            convertedValue = default(T);
            Delegate converterDelegate = null;
            if (_ClassConverters.TryGetValue(typeof(T), out converterDelegate) == false) return false;
            var converter = (Func<Object, T>)converterDelegate;
            convertedValue = converter(value);
            return convertedValue != null;
        }

        public void AddPostAction<TSource, TTarget>(Action<TSource, TTarget> action)
        {
            this.AddPostAction(TypeFilterCondition.Inherit, TypeFilterCondition.Inherit, action);
        }
        public void AddPostAction<TSource, TTarget>(TypeFilterCondition sourceCondition, TypeFilterCondition targetCondition, Action<TSource, TTarget> action)
        {
            if (action == null) { return; }

            var condition = new MappingCondition();
            condition.Source.Type = typeof(TSource);
            condition.Source.TypeFilterCondition = sourceCondition;
            condition.Target.Type = typeof(TTarget);
            condition.Target.TypeFilterCondition = targetCondition;
            _PostActions.Add(new MapPostAction(condition, (Delegate)action));
        }
        private void CallPostAction<TSource, TTarget>(TSource source, TTarget target)
        {
            var sourceType = source.GetType();
            var targetType = target.GetType();
            foreach (var item in _PostActions.Where(el => el.Condition.Match(sourceType, targetType)))
            {
                item.Action.DynamicInvoke(source, target);
            }
        }

        private Delegate GetMethod<TSource, TTarget>()
        {
            Delegate md = null;
            var key = new ObjectMapTypeInfo(typeof(TSource), typeof(TTarget));
            if (_Methods.TryGetValue(key, out md) == false)
            {
                var l = this.CreatePropertyMaps(key.Source, key.Target);
                md = this.CreateMethod<TSource, TTarget>(l);
                _Methods[key] = md;
            }
            return md;
        }

        private List<PropertyMap> CreatePropertyMaps(Type sourceType, Type targetType)
        {
            List<PropertyMap> l = new List<PropertyMap>();
            List<PropertyInfo> sourceProperties = new List<PropertyInfo>(sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance));
            List<PropertyInfo> targetProperties = targetType.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
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
        private Delegate CreateMethod<T, TResult>(IEnumerable<PropertyMap> propertyMapInfo)
        {
            var action = this.CreateSetPropertyMethod<T, TResult>(propertyMapInfo);

            Func<T, TResult, MappingContext, TResult> func = (source, target, context) =>
            {
                var kv = new KeyValuePair<object, object>(source, target);
                //Prevent from StackOverFlowException by decursive object chain.
                if (context.MappedObjectPair.Contains(kv) == true) { return target; }
                context.MappedObjectPair.Add(kv);

                action(this, source, target, context);

                this.CallPostAction(source, target);

                return target;
            };
            return (Delegate)func;
        }
        /// <summary>
        /// ***********************************************************************
        /// V1: Not nullable object. ex) Int32, DateTime, Point, DayOfWeek
        /// P1: Nullable object. ex) String, class, Nullable<T>
        /// -----------------------------------------------------------------------
        /// src.V1 --> tgt.V1;
        /// var converted = converter.ToXXX(src.V1);
        /// if (converted == null) return; // DoNothing...
        /// tgt.V1 = converted.Value;
        /// 
        /// -----------------------------------------------------------------------
        /// src.V1 --> tgt.P1;
        /// var converted = converter.ToXXX(src.V1);
        /// if (converted == null) return; // DoNothing...
        /// tgt.P1 = converted;
        /// 
        /// -----------------------------------------------------------------------
        /// src.P1 --> tgt.V1;
        /// if (src.P1 == null) return; // DoNothing...
        /// var converted = converter.ToXXX(src.P1);
        /// if (converted.HasValue == false) return; // DoNothing...
        /// tgt.V1 = converted;
        /// 
        /// -----------------------------------------------------------------------
        /// src.P1 --> tgt.P1;
        /// if (src.P1 == null) tgt.P1 = null; 
        /// var converted = converter.ToXXX(src.P1);
        /// if (converted.HasValue == false) return; // DoNothing...
        /// tgt.P1 = converted;
        /// 
        /// *************************************************************************/
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="propertyMapInfo"></param>
        /// <returns></returns>
        private Action<ObjectMapConfig, TSource, TTarget, MappingContext> CreateSetPropertyMethod<TSource, TTarget>(IEnumerable<PropertyMap> propertyMapInfo)
        {
            var sourceType = typeof(TSource);
            var targetType = typeof(TTarget);
            DynamicMethod dm = new DynamicMethod("SetProperty", null, new[] { typeof(ObjectMapConfig), sourceType, targetType, typeof(MappingContext) });
            ILGenerator il = dm.GetILGenerator();
            var mapConfigTypeConverterGetMethod = typeof(ObjectMapConfig).GetProperty("TypeConverter", BindingFlags.Instance | BindingFlags.Public).GetGetMethod();
            LocalBuilder dictionaryForDataReader = null;

            il.DeclareLocal(typeof(TypeConverter));
            il.Emit(OpCodes.Nop);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Callvirt, mapConfigTypeConverterGetMethod);
            il.Emit(OpCodes.Stloc_0);//ObjectMapConfig.TypeConverter


            #region Copy values to Dictionary<String, Objcet> from source DataReader
            if (sourceType.IsInheritanceFrom(typeof(System.Data.IDataRecord)) == true)
            {
                var dictionaryType = typeof(Dictionary<String, Object>);
                dictionaryForDataReader = il.DeclareLocal(dictionaryType);

                il.Emit(OpCodes.Newobj, dictionaryType.GetConstructor(new Type[0]));
                il.Emit(OpCodes.Stloc_S, dictionaryForDataReader);

                il.Emit(OpCodes.Ldnull);
                il.Emit(OpCodes.Ldloc_S, dictionaryForDataReader);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Call, _DictionaryExtensionsSetValuesMethod);
                il.Emit(OpCodes.Pop);
            }
            #endregion

            foreach (var item in propertyMapInfo)
            {
                var getMethod = item.Source.PropertyInfo.GetGetMethod();
                var setMethod = item.Target.PropertyInfo.GetSetMethod();
                //Target property is readonly
                if (setMethod == null) { continue; }
                #region DefineLabel
                Label customConvertStartLabel = il.DefineLabel();
                Label setValueStartLabel = il.DefineLabel();
                Label endOfCode = il.DefineLabel();
                Label setNullToTargetLabel = il.DefineLabel();
                Label sourceHasValueLabel = il.DefineLabel();
                #endregion
                var sourceVal = il.DeclareLocal(item.Source.ActualType);
                var targetVal = il.DeclareLocal(item.Target.ActualType);

                #region GetValue from SourceObject

                if (item.Source.IsIndexedProperty == true)
                {
                    #region Dictionary<String, String> or Dictionary<String, Object>
                    //Call TryGetValue method to avoid KeyNotFoundException
                    if (sourceType.IsInheritanceFrom(typeof(System.Data.IDataRecord)) == true ||
                        sourceType.IsInheritanceFrom(typeof(Dictionary<String, String>)) == true ||
                        sourceType.IsInheritanceFrom(typeof(Dictionary<String, Object>)) == true)
                    {
                        MethodInfo tryGetValue = null;
                        LocalBuilder outValue = null;
                        //Call TryGetValue method
                        if (sourceType.IsInheritanceFrom(typeof(System.Data.IDataRecord)) == true)
                        {
                            tryGetValue = typeof(Dictionary<String, Object>).GetMethod("TryGetValue");
                            outValue = il.DeclareLocal(typeof(Object));
                            il.Emit(OpCodes.Ldloc_S, dictionaryForDataReader);
                        }
                        else
                        {
                            tryGetValue = sourceType.GetMethod("TryGetValue");
                            outValue = il.DeclareLocal(item.Source.PropertyType);
                            il.Emit(OpCodes.Ldarg_1);
                        }
                        il.Emit(OpCodes.Ldstr, item.Source.IndexedPropertyKey);
                        il.Emit(OpCodes.Ldloca_S, outValue);
                        //TryGetValue(item.Source.IndexedPropertyKey, sourceVal) --> Boolean
                        il.Emit(OpCodes.Callvirt, tryGetValue);
                        il.Emit(OpCodes.Pop);
                        il.Emit(OpCodes.Ldloc_S, outValue);
                    }
                    else
                    {
                        //source[string key]
                        il.Emit(OpCodes.Ldarg_1);
                        il.Emit(OpCodes.Ldstr, item.Source.IndexedPropertyKey);
                        il.Emit(OpCodes.Callvirt, getMethod);
                    }
                    #endregion
                }
                else
                {
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Callvirt, getMethod);
                }

                //Check source.P1 is null 
                if (item.Source.CanBeNull == true)
                {
                    if (item.Source.IsNullableT == true)
                    {
                        #region if (source.P1.HasValue == false)
                        var sourceValN = il.DeclareLocal(item.Source.PropertyType);

                        il.Emit(OpCodes.Stloc_S, sourceValN);
                        //if (sourceValue.HasValue == true)
                        il.Emit(OpCodes.Ldloca_S, sourceValN);
                        il.Emit(OpCodes.Call, item.Source.PropertyType.GetProperty("HasValue").GetGetMethod());
                        il.Emit(OpCodes.Brfalse, setNullToTargetLabel); //null --> set target null
                        il.Emit(OpCodes.Ldloca_S, sourceValN);
                        //sourceVal.Value
                        il.Emit(OpCodes.Call, item.Source.PropertyType.GetMethod("GetValueOrDefault", Type.EmptyTypes));
                        #endregion
                    }
                    else if (item.Source.CanBeNull == true)
                    {
                        #region if (source.P1 == null)
                        Type sourceTypeN = item.Source.ActualType;
                        var sourceValN = il.DeclareLocal(sourceTypeN);
                        il.Emit(OpCodes.Stloc_S, sourceValN);
                        //if (sourceValue == null)
                        il.Emit(OpCodes.Ldloc_S, sourceValN);
                        il.Emit(OpCodes.Ldnull);
                        il.Emit(OpCodes.Ceq);
                        il.Emit(OpCodes.Brtrue, setNullToTargetLabel); //null --> set target null
                        il.Emit(OpCodes.Ldloc_S, sourceValN);
                        #endregion
                    }
                }
                il.Emit(OpCodes.Br, sourceHasValueLabel);

                il.MarkLabel(sourceHasValueLabel);
                //store sourceVal (never be null)
                il.Emit(OpCodes.Stloc_S, sourceVal);
                #endregion

                #region Convert value to target type.
                LocalBuilder convertedVal = null;
                var methodName = GetMethodName(item.Target.ActualType);
                if (item.Target.ActualType.IsEnum == false && methodName == null)
                {
                    if (item.Target.PropertyType.IsValueType == true &&
                        item.Source.ActualType == item.Target.ActualType)
                    {
                        #region target.Struct = source.Struct;
                        il.Emit(OpCodes.Ldloc_S, sourceVal);
                        il.Emit(OpCodes.Stloc_S, targetVal);
                        #endregion
                    }
                    else
                    {
                        convertedVal = il.DeclareLocal(item.Target.ActualType);
                        il.Emit(OpCodes.Br_S, customConvertStartLabel);
                    }
                }
                else
                {
                    #region var convertedValue = TypeConverter.ToXXX(sourceVal);
                    //Call TypeConverter.ToXXX(sourceVal);
                    il.Emit(OpCodes.Ldloc_0);//MapConfig.Current.TypeConverter
                    il.Emit(OpCodes.Ldloc_S, sourceVal);
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
                    if (item.Target.ActualType == typeof(String))
                    {
                        convertedVal = il.DeclareLocal(item.Target.ActualType);
                        il.Emit(OpCodes.Stloc_S, targetVal);
                        il.Emit(OpCodes.Ldloc_S, targetVal);
                        il.Emit(OpCodes.Ldnull);
                        il.Emit(OpCodes.Ceq);
                        il.Emit(OpCodes.Brfalse_S, ifConvertedValueNotNullBlock);
                        {
                            //DoNothing when convert failed
                            il.Emit(OpCodes.Br_S, customConvertStartLabel);
                        }
                        il.MarkLabel(ifConvertedValueNotNullBlock);
                    }
                    else
                    {
                        Type targetTypeN = typeof(Nullable<>).MakeGenericType(item.Target.ActualType);
                        convertedVal = il.DeclareLocal(targetTypeN);
                        //SetValue to TargetObject
                        il.Emit(OpCodes.Stloc_S, convertedVal);
                        il.Emit(OpCodes.Ldloca_S, convertedVal);
                        il.Emit(OpCodes.Call, targetTypeN.GetProperty("HasValue").GetGetMethod());
                        il.Emit(OpCodes.Brtrue_S, ifConvertedValueNotNullBlock);
                        {
                            //Try custom convert when convert failed
                            il.Emit(OpCodes.Br_S, customConvertStartLabel);
                        }
                        il.MarkLabel(ifConvertedValueNotNullBlock);
                        //GetValue
                        il.Emit(OpCodes.Ldloca_S, convertedVal);
                        il.Emit(OpCodes.Call, targetTypeN.GetMethod("GetValueOrDefault", Type.EmptyTypes));
                        il.Emit(OpCodes.Stloc_S, targetVal);
                    }
                    #endregion
                }
                il.Emit(OpCodes.Br_S, setValueStartLabel);
                #endregion

                #region Call custom convert method or Map method when convert failed. //ObjectMapConfig.Current.Convert<T>(...)
                if (convertedVal != null)
                {
                    il.MarkLabel(customConvertStartLabel);
                    //Set up parameter for ObjectMapConfig.Convert<>(sourceVal, convertedVal)
                    il.Emit(OpCodes.Ldarg_0);//ObjectMapConfig instance
                    if (item.Source.ActualType.IsValueType == true)
                    {
                        il.Emit(OpCodes.Ldloc_S, sourceVal);
                        il.Emit(OpCodes.Box, item.Source.ActualType);
                        il.Emit(OpCodes.Ldloca_S, convertedVal);
                    }
                    else
                    {
                        il.Emit(OpCodes.Ldloc_S, sourceVal);
                        il.Emit(OpCodes.Ldloca_S, convertedVal);
                    }

                    var convertResult = il.DeclareLocal(typeof(Boolean));
                    ////Structure (Int32, Decimal, Int32?, Enum...etc)
                    if (item.Target.IsNullableT == true ||
                        item.Target.CanBeNull == false)
                    {
                        il.Emit(OpCodes.Call, _ConvertStructureMethod.MakeGenericMethod(item.Target.ActualType));
                        il.Emit(OpCodes.Stloc_S, convertResult);
                        //GetValueOrDefault
                        if (item.Target.CanBeNull == false)
                        {
                            il.Emit(OpCodes.Ldloca_S, convertedVal);
                            il.Emit(OpCodes.Call, typeof(Nullable<>).MakeGenericType(item.Target.ActualType).GetMethod("GetValueOrDefault", Type.EmptyTypes));
                            il.Emit(OpCodes.Stloc_S, targetVal);
                        }
                    }
                    else
                    {
                        //Class
                        il.Emit(OpCodes.Call, _ConvertClassMethod.MakeGenericMethod(item.Target.ActualType));
                        il.Emit(OpCodes.Stloc_S, convertResult);
                        il.Emit(OpCodes.Ldloc_S, convertedVal);
                        il.Emit(OpCodes.Stloc_S, targetVal);
                    }
                    il.Emit(OpCodes.Ldloc_S, convertResult);
                    il.Emit(OpCodes.Brtrue, setValueStartLabel);
                    if (item.Target.IsIndexedProperty == false)
                    {
                        //Try Map method when convert failed
                        #region source.P1.Map(target.P1); //Call Map method
                        var targetObj = il.DeclareLocal(item.Target.PropertyType);
                        il.Emit(OpCodes.Ldarg_2);
                        il.Emit(OpCodes.Callvirt, item.Target.PropertyInfo.GetGetMethod());
                        il.Emit(OpCodes.Stloc_S, targetObj);

                        il.Emit(OpCodes.Ldarg_0);//ObjectMapConfig instance
                        il.Emit(OpCodes.Ldloc_S, sourceVal);
                        il.Emit(OpCodes.Ldloc_S, targetObj);
                        il.Emit(OpCodes.Ldarg_3);//MappingContext
                        il.Emit(OpCodes.Call, _MapMethod.MakeGenericMethod(item.Source.ActualType, item.Target.PropertyType));
                        il.Emit(OpCodes.Pop);
                        il.Emit(OpCodes.Br, endOfCode);
                        #endregion
                    }
                }
                #endregion

                #region Set Null to Target property //tgt.P1 = null
                il.MarkLabel(setNullToTargetLabel);
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
                            il.Emit(OpCodes.Ldloca_S, targetValN);
                            il.Emit(OpCodes.Initobj, item.Target.PropertyType);
                            il.Emit(OpCodes.Ldloc_S, targetValN);
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

                #region Set value to TargetProperty
                il.MarkLabel(setValueStartLabel);
                il.Emit(OpCodes.Ldarg_2);
                if (item.Target.IsIndexedProperty == true)
                {
                    //target["P1"] = source.P1;
                    il.Emit(OpCodes.Ldstr, item.Target.IndexedPropertyKey);
                }
                il.Emit(OpCodes.Ldloc_S, targetVal);
                if (item.Target.IsNullableT == true)
                {
                    //new Nullable<T>(new T());
                    il.Emit(OpCodes.Newobj, item.Target.PropertyType.GetConstructor(new Type[] { item.Target.ActualType }));
                }
                il.Emit(OpCodes.Callvirt, setMethod);
                #endregion

                il.MarkLabel(endOfCode);
                il.Emit(OpCodes.Nop);
            }
            il.Emit(OpCodes.Ret);

            var f = typeof(Action<,,,>);
            var gf = f.MakeGenericType(typeof(ObjectMapConfig), sourceType, targetType, typeof(MappingContext));
            return (Action<ObjectMapConfig, TSource, TTarget, MappingContext>)dm.CreateDelegate(gf);
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
            return null;
        }
    }
}
