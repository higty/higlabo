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

        private readonly ConcurrentDictionary<ObjectMapTypeInfo, Delegate> _Methods = new ConcurrentDictionary<ObjectMapTypeInfo, Delegate>();

        private MethodInfo _MapMethod = null;
        private MethodInfo _ConvertMethod = null;
        private List<MapPostAction> _PostActions = new List<MapPostAction>();
        private ConcurrentDictionary<Type, Delegate> _Converters = new ConcurrentDictionary<Type, Delegate>();

        public List<PropertyMappingRule> PropertyMapRules { get; private set; }
        public TypeConverter TypeConverter { get; set; }
        public Int32 MaxCallStack { get; set; }
        public Boolean DictionaryKeyIgnoreCase { get; set; }

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
            this.AddConverter<Object>(o => new ConvertResult<Object>(o != null, o));
            
            this.MaxCallStack = 100;
            this.DictionaryKeyIgnoreCase = true;
            _MapMethod = this.GetMethodInfo("Map");
            _ConvertMethod = this.GetMethodInfo("Convert");
        }
        private MethodInfo GetMethodInfo(String name)
        {
            return typeof(ObjectMapConfig).GetMethods().Where(el => el.GetCustomAttributes().Any(attr => attr is ObjectMapConfigMethodAttribute && ((ObjectMapConfigMethodAttribute)attr).Name == name)).FirstOrDefault();
        }
        private MappingContext CreateMappingContext()
        {
            return new MappingContext(this.DictionaryKeyIgnoreCase);
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
        [ObjectMapConfigMethodAttribute(Name = "Map")]
        public TTarget Map<TSource, TTarget>(TSource source, TTarget target, MappingContext context)
        {
            if (source == null || target == null) { return target; }
            if (context.CallStackCount > this.MaxCallStack)
            {
                throw new InvalidOperationException("Map method recursively called over " + this.MaxCallStack + ".");
            }

            if (source is IDataReader)
            {
                return this.MapIDataReader(source as IDataReader, target, context);
            }
            var md = this.GetMethod<TSource, TTarget>(source.GetType(), target.GetType());
            try
            {
                context.CallStackCount++;
                var result = (TTarget)md.DynamicInvoke(source, target, context);
                context.CallStackCount--;
                return result;
            }
            catch (TargetInvocationException ex)
            {
                throw new ObjectMapFailureException("Generated map method was failed.Maybe HigLabo.Mapper bug."
                    + "Please notify SouceObject,TargetObject class of this ObjectMapFailureException object to auther."
                    + "We will fix it."
                    , source, target, ex.InnerException);
            }
        }
        public IEnumerable<TTarget> Map<TSource, TTarget>(IEnumerable<TSource> source, Func<TTarget> constructor)
        {
            return Map(source, constructor, this.CreateMappingContext());
        }
        private IEnumerable<TTarget> Map<TSource, TTarget>(IEnumerable<TSource> source, Func<TTarget> constructor, MappingContext context)
        {
            return source.Select(el => el.Map(constructor()));
        }
        private TTarget MapIDataReader<TTarget>(IDataReader source, TTarget target, MappingContext context)
        {
            Dictionary<String, Object> d = null;
            if (context.DictionaryKeyIgnoreCase == true)
            {
                d = new Dictionary<String, Object>(StringComparer.InvariantCultureIgnoreCase);
            }
            else
            {
                d = new Dictionary<String, Object>();
            }
            d.SetValues((IDataReader)source);
            return this.Map(d, target, context);
        }

        public void RemovePropertyMap<TSource, TTarget>(IEnumerable<String> removePropertyNames, Action<TSource, TTarget> action)
        {
            this.RemovePropertyMap<TSource, TTarget>(objectMap => removePropertyNames.Contains(objectMap.Target.Name), action);
        }
        public void RemovePropertyMap<TSource, TTarget>(Func<PropertyMap, Boolean> selector)
        {
            this.RemovePropertyMap<TSource, TTarget>(selector, null);
        }
        public void RemovePropertyMap<TSource, TTarget>(Func<PropertyMap, Boolean> selector, Action<TSource, TTarget> action)
        {
            this.ReplaceMap(objectMap =>
            {
                var l = objectMap.PropertyMaps.Where(selector).ToList();
                for (int i = 0; i < l.Count; i++)
                {
                    objectMap.PropertyMaps.Remove(l[i]);
                }
            }, action);
        }
        private void ReplaceMap<TSource, TTarget>(Action<ObjectMap> objectMapAction)
        {
            ReplaceMap<TSource, TTarget>(objectMapAction, null);
        }
        private void ReplaceMap<TSource, TTarget>(Action<ObjectMap> objectMapAction, Action<TSource, TTarget> action)
        {
            var key = new ObjectMapTypeInfo(typeof(TSource), typeof(TTarget));
            var mappings = this.CreatePropertyMaps(key.Source, key.Target);
            var om = new ObjectMap(mappings);
            objectMapAction(om);
            var md = this.CreateMethod<TSource, TTarget>(key.Source, key.Target, om.PropertyMaps);
            _Methods[key] = md;

            this.AddPostAction(action);
        }

        public void AddConverter<T>(Func<Object, ConvertResult<T>> converter)
        {
            _Converters[typeof(T)] = converter;
        }
        [ObjectMapConfigMethodAttribute(Name = "Convert")]
        public Boolean Convert<T>(Object value, out T convertedValue)
        {
            convertedValue = default(T);
            Delegate converterDelegate = null;
            if (_Converters.TryGetValue(typeof(T), out converterDelegate) == false) return false;
            var converter = (Func<Object, ConvertResult<T>>)converterDelegate;
            var result = converter(value);
            if (result.Success == true)
            {
                convertedValue = result.Value;
            }
            return result.Success;
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

        private Delegate GetMethod<TSource, TTarget>(Type sourceType, Type targetType)
        {
            Delegate md = null;
            var key = new ObjectMapTypeInfo(sourceType, targetType);
            if (_Methods.TryGetValue(key, out md) == false)
            {
                var l = this.CreatePropertyMaps(key.Source, key.Target);
                md = this.CreateMethod<TSource, TTarget>(key.Source, key.Target, l);
                _Methods[key] = md;
            }
            return md;
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
        private Delegate CreateMethod<T, TResult>(Type sourceType, Type targetType, IEnumerable<PropertyMap> propertyMapInfo)
        {
            var action = this.CreateSetPropertyMethod(sourceType, targetType, propertyMapInfo);

            Func<T, TResult, MappingContext, TResult> func = (source, target, context) =>
            {
                var kv = new KeyValuePair<object, object>(source, target);
                //Prevent from StackOverFlowException by decursive object chain.
                if (context.MappedObjectPair.Contains(kv) == true) { return target; }
                context.MappedObjectPair.Add(kv);

                action.DynamicInvoke(this, source, target, context);

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
        private Delegate CreateSetPropertyMethod(Type sourceType, Type targetType, IEnumerable<PropertyMap> propertyMapInfo)
        {
            DynamicMethod dm = new DynamicMethod("SetProperty", null, new[] { typeof(ObjectMapConfig), sourceType, targetType, typeof(MappingContext) });
            ILGenerator il = dm.GetILGenerator();
            var mapConfigTypeConverterGetMethod = typeof(ObjectMapConfig).GetProperty("TypeConverter", BindingFlags.Instance | BindingFlags.Public).GetGetMethod();

            il.DeclareLocal(typeof(TypeConverter));
            il.Emit(OpCodes.Nop);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Callvirt, mapConfigTypeConverterGetMethod);
            il.Emit(OpCodes.Stloc_0);//ObjectMapConfig.TypeConverter

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
                il.Emit(OpCodes.Br, sourceHasValueLabel);

                il.MarkLabel(sourceHasValueLabel);
                //store sourceVal (never be null)
                il.SetLocal(sourceVal);
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
                        il.LoadLocal(sourceVal);
                        il.LoadLocal(targetVal);
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
                        il.SetLocal(convertedVal);
                        il.LoadLocala(convertedVal);
                        il.Emit(OpCodes.Call, targetTypeN.GetProperty("HasValue").GetGetMethod());
                        il.Emit(OpCodes.Brtrue_S, ifConvertedValueNotNullBlock);
                        {
                            //Try custom convert when convert failed
                            il.Emit(OpCodes.Br_S, customConvertStartLabel);
                        }
                        il.MarkLabel(ifConvertedValueNotNullBlock);
                        //GetValue
                        il.LoadLocala(convertedVal);
                        il.Emit(OpCodes.Call, targetTypeN.GetMethod("GetValueOrDefault", Type.EmptyTypes));
                        il.SetLocal(targetVal);
                    }
                    #endregion
                }
                il.Emit(OpCodes.Br_S, setValueStartLabel);
                #endregion

                #region Call custom convert method or Map method when convert failed. //ObjectMapConfig.Current.Convert<T>(...)
                il.MarkLabel(customConvertStartLabel);
                convertedVal = il.DeclareLocal(item.Target.ActualType);
                //Set up parameter for ObjectMapConfig.Convert<>(sourceVal, convertedVal)
                il.Emit(OpCodes.Ldarg_0);//ObjectMapConfig instance
                il.LoadLocal(sourceVal);
                if (item.Source.ActualType.IsValueType == true)
                {
                    //Boxing to Object
                    il.Emit(OpCodes.Box, item.Source.ActualType);
                }
                il.LoadLocala(convertedVal);

                //public Boolean Convert<T>(Object value, out T convertedValue)
                il.Emit(OpCodes.Call, _ConvertMethod.MakeGenericMethod(item.Target.ActualType));
                var convertResult = il.DeclareLocal(typeof(Boolean));
                il.SetLocal(convertResult);
                il.LoadLocal(convertedVal);
                il.SetLocal(targetVal);
                
                il.LoadLocal(convertResult);
                il.Emit(OpCodes.Brtrue, setValueStartLabel);
                if (item.Target.IsIndexedProperty == false)
                {
                    //Try Map method when convert failed
                    #region source.P1.Map(target.P1); //Call Map method
                    var targetObj = il.DeclareLocal(item.Target.PropertyType);
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Callvirt, item.Target.PropertyInfo.GetGetMethod());
                    il.SetLocal(targetObj);

                    il.Emit(OpCodes.Ldarg_0);//ObjectMapConfig instance
                    il.LoadLocal(sourceVal);
                    il.LoadLocal(targetObj);
                    il.Emit(OpCodes.Ldarg_3);//MappingContext
                    il.Emit(OpCodes.Call, _MapMethod.MakeGenericMethod(item.Source.ActualType, item.Target.PropertyType));
                    il.Emit(OpCodes.Pop);
                    il.Emit(OpCodes.Br, endOfCode);
                    #endregion
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

                #region Set value to TargetProperty
                il.MarkLabel(setValueStartLabel);
                il.Emit(OpCodes.Ldarg_2);
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
                il.Emit(OpCodes.Callvirt, setMethod);
                #endregion

                il.MarkLabel(endOfCode);
                il.Emit(OpCodes.Nop);
            }
            il.Emit(OpCodes.Ret);

            var f = typeof(Action<,,,>);
            var gf = f.MakeGenericType(typeof(ObjectMapConfig), sourceType, targetType, typeof(MappingContext));
            return dm.CreateDelegate(gf);
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
