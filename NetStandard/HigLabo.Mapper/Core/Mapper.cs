using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    public class MapConfig
    {
        public CollectionElementMapMode CollectionElementMapMode { get; set; }
    }
    public class MapContext
    {
        public Mapper Mapper { get; private set; }

        public MapContext(Mapper mapper)
        {
            this.Mapper = mapper;
        }
    }
    public class Mapper
    {
        private class MapParameterList
        {
            public ParameterExpression Source { get; set; }
            public ParameterExpression Target { get; set; }
            public ParameterExpression Config { get; set; }
            public ParameterExpression Context { get; set; }
        }
        private static readonly String System_Collections_Generic_ICollection_1 = "System.Collections.Generic.ICollection`1";
        private static readonly String System_Collections_Generic_IEnumerable_1 = "System.Collections.Generic.IEnumerable`1";

        public static Mapper Default { get; private set; } = new Mapper();

        private MapContext _MapContext;
        private Dictionary<ActionKey, Boolean> _HasCollectionProperty = new Dictionary<ActionKey, Boolean>();
        private Dictionary<ActionKey, Delegate> _MapActionList = new Dictionary<ActionKey, Delegate>();
        private Dictionary<ActionKey, Delegate> _MapCollectionActionList = new Dictionary<ActionKey, Delegate>();
        public MapConfig Config { get; set; } = new MapConfig();

        public Mapper()
        {
            _MapContext = new MapContext(this);
        }

        public TTarget Map<TSource, TTarget>(TSource source, TTarget target)
        {
            return this.Map(source, target, this.Config);
        }
        public TTarget Map<TSource, TTarget>(TSource source, TTarget target, MapConfig config)
        {
            return Map(source, target, config, _MapContext);
        }
        private TTarget Map<TSource, TTarget>(TSource source, TTarget target, MapConfig config, MapContext context)
        {
            var key = new ActionKey(typeof(TSource), typeof(TTarget));
            this.MapProperty<TSource, TTarget>(key, source, target, config, context);
            return target;
        }

        private void MapProperty<TSource, TTarget>(ActionKey key, TSource source, TTarget target, MapConfig config, MapContext context)
        {
            if (_MapActionList.TryGetValue(key, out var action) == false)
            {
                action = CreateMapMethod(source, target, context);
                _MapActionList.Add(key, action);
            }
            var f = (Action<TSource, TTarget, MapConfig, MapContext>)action;
            f(source, target, config, context);
        }

        private Delegate CreateMapMethod<TSource, TTarget>(TSource source, TTarget target, MapContext context)
        {
            var lambda = CreateMapLambdaExpression(typeof(TSource), typeof(TTarget), context);
            Delegate action = (Action<TSource, TTarget, MapConfig, MapContext>)lambda.Compile();
            return action;
        }

        private Dictionary<PropertyInfo, PropertyInfo> CreatePropertyMapping(Type sourceType, Type targetType)
        {
            var pp = new Dictionary<PropertyInfo, PropertyInfo>();

            var sourcePropertyList = sourceType.GetProperties().Where(a => a.CanRead).ToList();
            var targetPropertyList = targetType.GetProperties().Where(a => a.CanWrite).ToList();
            foreach (var targetProperty in targetPropertyList)
            {
                var sourceProperty = sourcePropertyList.Find(el => el.Name == targetProperty.Name);
                if (sourceProperty == null) { continue; }
                if (sourceProperty.PropertyType.IsInheritanceFrom(targetProperty.PropertyType) == false) { continue; }
                var targetProperty_PropertyType = targetProperty.PropertyType;
                var targetInterfaceType = targetProperty_PropertyType.GetInterfaces()
                    .FirstOrDefault(tp => tp.FullName.StartsWith(System_Collections_Generic_ICollection_1));
                if (targetInterfaceType != null) { continue; }
                pp.Add(sourceProperty, targetProperty);
            }
            return pp;
        }
        private Dictionary<PropertyInfo, PropertyInfo> CreateCollectionPropertyMapping(Type sourceType, Type targetType)
        {
            var pp = new Dictionary<PropertyInfo, PropertyInfo>();

            var sourcePropertyList = sourceType.GetProperties().Where(a => a.CanRead).ToList();
            var targetPropertyList = targetType.GetProperties().Where(a => a.CanWrite).ToList();
            foreach (var targetProperty in targetPropertyList)
            {
                var sourceProperty = sourcePropertyList.Find(el => el.Name == targetProperty.Name);
                if (sourceProperty == null) { continue; }

                var sourceProperty_PropertyType = sourceProperty.PropertyType;
                Type sourceInterfaceType = null;
                if (sourceProperty_PropertyType.FullName.StartsWith(System_Collections_Generic_IEnumerable_1))
                {
                    sourceInterfaceType = sourceProperty_PropertyType;
                }
                if (sourceInterfaceType == null)
                {
                    sourceInterfaceType = sourceProperty_PropertyType.GetInterfaces()
                        .FirstOrDefault(tp => tp.FullName.StartsWith(System_Collections_Generic_IEnumerable_1));
                }

                var targetProperty_PropertyType = targetProperty.PropertyType;
                var targetInterfaceType = targetProperty_PropertyType.GetInterfaces()
                    .FirstOrDefault(tp => tp.FullName.StartsWith(System_Collections_Generic_ICollection_1));

                if (sourceInterfaceType != null && targetInterfaceType != null)
                {
                    pp.Add(sourceProperty, targetProperty);
                }
            }
            return pp;
        }

        private LambdaExpression CreateMapLambdaExpression(Type sourceType, Type targetType, MapContext context)
        {
            var p = new MapParameterList();
            p.Source = Expression.Parameter(sourceType, "source");
            p.Target = Expression.Parameter(targetType, "target");
            p.Config = Expression.Parameter(typeof(MapConfig), "mapConfig");
            p.Context = Expression.Parameter(typeof(MapContext), "mapContext");

            var ee = CreateMapExpression(sourceType, targetType, p);
            ee.AddRange(CreateMapCollectionExpression(sourceType, targetType, context, p
                , this.CreateCollectionPropertyMapping(sourceType, targetType)));
            BlockExpression block = Expression.Block(ee);
            LambdaExpression lambda = Expression.Lambda(block
                , new[] { p.Source, p.Target, p.Config, p.Context });
            return lambda;
        }
        private List<Expression> CreateMapExpression(Type sourceType, Type targetType, MapParameterList parameterList)
        {
            var p = parameterList;
            var pp = CreatePropertyMapping(sourceType, targetType);
            var ee = new List<Expression>();
            foreach (var sourceProperty in pp.Keys)
            {
                var targetProperty = pp[sourceProperty];
                if (sourceProperty.PropertyType == targetProperty.PropertyType)
                {
                    MemberExpression getMethod = Expression.PropertyOrField(p.Source, sourceProperty.Name);
                    MemberExpression setMethod = Expression.PropertyOrField(p.Target, targetProperty.Name);
                    BinaryExpression body = Expression.Assign(setMethod, getMethod);
                    ee.Add(body);
                }
                else
                {
                    MemberExpression getMethod = Expression.PropertyOrField(p.Source, sourceProperty.Name);
                    MemberExpression setMethod = Expression.PropertyOrField(p.Target, targetProperty.Name);
                    BinaryExpression body = Expression.Assign(setMethod
                        , Expression.TypeAs(getMethod, targetProperty.PropertyType));
                    ee.Add(body);
                }
            }
            LabelTarget returnTarget = Expression.Label();
            GotoExpression returnExpression = Expression.Return(returnTarget);
            LabelExpression returnLabel = Expression.Label(returnTarget);
            BlockExpression block = Expression.Block(
                returnExpression,
                returnLabel);
            ee.Add(block);

            return ee;
        }

        private List<Expression> CreateMapCollectionExpression(Type sourceType, Type targetType, MapContext context, MapParameterList parameterList
            , Dictionary<PropertyInfo, PropertyInfo> mapping)
        {
            var p = parameterList;

            var ee = new List<Expression>();
            var mapperMember = Expression.PropertyOrField(p.Context, "Mapper");

            foreach (var sourceProperty in mapping.Keys)
            {
                var targetProperty = mapping[sourceProperty];
                MemberExpression sourceMember = Expression.PropertyOrField(p.Source, sourceProperty.Name);
                MemberExpression targetMember = Expression.PropertyOrField(p.Target, targetProperty.Name);

                var sourceElementType = sourceProperty.PropertyType.GetCollectionElementType();
                var targetElementType = targetProperty.PropertyType.GetCollectionElementType();
                var targetElementConstructor = targetElementType.GetConstructor(Type.EmptyTypes);

                if (targetElementConstructor != null)
                {
                    if (targetProperty.PropertyType.IsArray)
                    {
                        BinaryExpression body = Expression.Assign(targetMember
                            , Expression.Call(mapperMember, "MapToArray"
                            , new Type[] { sourceElementType, targetElementType }
                            , sourceMember, p.Config, p.Context));
                        ee.Add(body);
                    }
                    else
                    {
                        ee.Add(Expression.Call(mapperMember, "MapToCollection"
                            , new Type[] { sourceElementType, targetElementType }
                            , sourceMember, targetMember, p.Config, p.Context));
                    }
                }
            }

            return ee;
        }
        public void MapToCollection<TSource, TTarget>(IEnumerable<TSource> source, ICollection<TTarget> target, MapConfig config, MapContext context)
            where TSource : class
            where TTarget : class, new()
        {
            if (source == null) { return; }
            if (target == null) { return; }
            target.Clear();
            if (source is TSource[] ss)
            {
                for (int i = 0; i < ss.Length; i++)
                {
                    var r = this.Map(ss[i], new TTarget(), config, context);
                    target.Add(r);
                }
            }
            else if (source is IList<TSource> sList)
            {
                for (int i = 0; i < sList.Count; i++)
                {
                    var r = this.Map(sList[i], new TTarget(), config, context);
                    target.Add(r);
                }
            }
            else
            {
                foreach (var item in source)
                {
                    var r = this.Map(item, new TTarget(), config, context);
                    target.Add(r);
                }
            }
        }
        public TTarget[] MapToArray<TSource, TTarget>(IEnumerable<TSource> source, MapConfig config, MapContext context)
            where TSource : class
            where TTarget : class, new()
        {
            if (source == null) { return null; }

            if (source is TSource[] ss)
            {
                var tt = new TTarget[ss.Length];
                for (int i = 0; i < ss.Length; i++)
                {
                    var r = this.Map(ss[i], new TTarget(), config, context);
                    tt[i] = r;
                }
                return tt;
            }
            else if (source is IList<TSource> sList)
            {
                var tt = new TTarget[sList.Count];
                for (int i = 0; i < sList.Count; i++)
                {
                    var r = this.Map(sList[i], new TTarget(), config, context);
                    tt[i] = r;
                }
                return tt;
            }
            else
            {
                var l = new List<TTarget>();
                foreach (var item in source)
                {
                    var r = this.Map(item, new TTarget(), config, context);
                    l.Add(r);
                }
                return l.ToArray();
            }
        }

    }
    public static class TypeExtensions
    {
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
