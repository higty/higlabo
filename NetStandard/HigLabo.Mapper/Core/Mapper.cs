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
        private class ObjectMapConfigMethodAttribute : Attribute
        {
            public String Name { get; set; }
        }
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

        private Hashtable _MapActionList = new Hashtable();
        private Hashtable _MapCollectionActionList = new Hashtable();
        public MapConfig Config { get; set; } = new MapConfig();

        public TTarget Map<TSource, TTarget>(TSource source, TTarget target)
        {
            var config = this.Config;
            return this.Map(source, target, config);
        }
        public TTarget Map<TSource, TTarget>(TSource source, TTarget target, MapConfig config)
        {
            return Map(source, target, config, new MapContext(this));
        }
        public TTarget Map<TSource, TTarget>(TSource source, TTarget target, MapConfig config, MapContext context)
        {
            var key = new ActionKey(typeof(TSource), typeof(TTarget));
            this.MapAction<TSource, TTarget>(key, source, target, config, context);
            if (config.CollectionElementMapMode != CollectionElementMapMode.None)
            {
                this.MapCollectionAction<TSource, TTarget>(key, source, target, config, context);
            }
            return target;
        }

        public void Map_Collection<TSource, TTarget>(IEnumerable<TSource> source, ICollection<TTarget> target, MapConfig config, MapContext context)
            where TSource : class
            where TTarget : class, new()
        {
            if (source == null) { return; }
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

        private void MapAction<TSource, TTarget>(ActionKey key, TSource source, TTarget target, MapConfig config, MapContext context)
        {
            var action = _MapActionList[key] as Delegate;
            if (action == null)
            {
                action = CreateMapMethod(source, target);
                _MapActionList.Add(key, action);
            }
            var f = (Action<TSource, TTarget, MapConfig, MapContext>)action;
            f(source, target, config, context);
        }
        private void MapCollectionAction<TSource, TTarget>(ActionKey key, TSource source, TTarget target
            , MapConfig config, MapContext context)
        {
            var action = _MapCollectionActionList[key] as Delegate;
            if (action == null)
            {
                switch (config.CollectionElementMapMode)
                {
                    case CollectionElementMapMode.None: throw new InvalidOperationException();
                    case CollectionElementMapMode.NewObject:
                        action = CreateMapCollectionNewElementMethod(source, target, context);
                        break;
                    case CollectionElementMapMode.DeepCopy:
                        break;
                    default: throw new InvalidOperationException();
                }
                _MapCollectionActionList.Add(key, action);
            }
            var f = (Action<TSource, TTarget, MapConfig, MapContext>)action;
            f(source, target, config, context);
        }

        private Delegate CreateMapMethod<TSource, TTarget>(TSource source, TTarget target)
        {
            var lambda = CreateMapLambdaExpression(typeof(TSource), typeof(TTarget));
            Delegate action = (Action<TSource, TTarget, MapConfig, MapContext>)lambda.Compile();
            return action;
        }
        private LambdaExpression CreateMapLambdaExpression(Type sourceType, Type targetType)
        {
            var p = new MapParameterList();
            p.Source = Expression.Parameter(sourceType, "source");
            p.Target = Expression.Parameter(targetType, "target");
            p.Config = Expression.Parameter(typeof(MapConfig), "mapConfig");
            p.Context = Expression.Parameter(typeof(MapContext), "mapContext");

            var ee = CreateMapExpression(sourceType, targetType, p);
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
                MemberExpression getMethod = Expression.PropertyOrField(p.Source, sourceProperty.Name);
                MemberExpression setMethod = Expression.PropertyOrField(p.Target, targetProperty.Name);
                BinaryExpression body = Expression.Assign(setMethod, Expression.Convert(getMethod, targetProperty.PropertyType));
                ee.Add(body);
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

        private Delegate CreateMapCollectionNewElementMethod<TSource, TTarget>(TSource source, TTarget target, MapContext context)
        {
            var p = new MapParameterList();
            p.Source = Expression.Parameter(typeof(TSource), "source");
            p.Target = Expression.Parameter(typeof(TTarget), "target");
            p.Config = Expression.Parameter(typeof(MapConfig), "mapConfig");
            p.Context = Expression.Parameter(typeof(MapContext), "mapContext");
            var ee = CreateMapCollectionExpression(typeof(TSource), typeof(TTarget), context, p);
            BlockExpression block = Expression.Block(ee);
            LambdaExpression lambda = Expression.Lambda<Action<TSource, TTarget, MapConfig, MapContext>>(block
                , new[] { p.Source, p.Target, p.Config, p.Context });
            Delegate action = (Action<TSource, TTarget, MapConfig, MapContext>)lambda.Compile();
            return action;
        }
        private List<Expression> CreateMapCollectionExpression(Type sourceType, Type targetType, MapContext context, MapParameterList parameterList)
        {
            var p = parameterList;
            var sourcePropertyList = sourceType.GetProperties().Where(a => a.CanRead).ToList();
            var targetPropertyList = targetType.GetProperties().Where(a => a.CanWrite).ToList();
            var pp = new Dictionary<PropertyInfo, PropertyInfo>();
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

            var ee = new List<Expression>();
            var mapperMember = Expression.PropertyOrField(p.Context, "Mapper");

            foreach (var sourceProperty in pp.Keys)
            {
                var targetProperty = pp[sourceProperty];

                Expression newInstance = null;
                if (targetProperty.PropertyType.IsArray)
                {
                    var constructor = targetProperty.PropertyType.GetConstructors().FirstOrDefault();
                    if (constructor == null) { continue; }
                    newInstance = Expression.New(constructor
                        , constructor.GetParameters().Select(el => Expression.Constant(0)));
                }
                else
                {
                    var defaultConstructor = targetProperty.PropertyType.GetConstructor(Type.EmptyTypes);
                    if (defaultConstructor == null) { continue; }
                    newInstance = Expression.New(defaultConstructor);
                }
                MemberExpression sourceMember = Expression.PropertyOrField(p.Source, sourceProperty.Name);
                MemberExpression targetMember = Expression.PropertyOrField(p.Target, targetProperty.Name);
                BinaryExpression body = Expression.Assign(targetMember, newInstance);
                ee.Add(body);


                if (targetProperty.PropertyType.IsArray == false)
                {
                    var addMethod = targetProperty.PropertyType.GetMethod("Add");
                    if (addMethod != null)
                    {
                        var sourceIList = Expression.Convert(sourceMember, typeof(IList<>).MakeGenericType(sourceProperty.PropertyType.GetGenericArguments()));
                        var sourceElementType = sourceProperty.PropertyType.GenericTypeArguments[0];
                        var targetElementType = targetProperty.PropertyType.GenericTypeArguments[0];
                        var targetElementConstructor = targetElementType.GetConstructor(Type.EmptyTypes);
                        if (targetElementConstructor != null)
                        {
                            if (sourceProperty.PropertyType.FullName.StartsWith(System_Collections_Generic_IEnumerable_1))
                            {
                                ee.Add(Expression.Call(mapperMember, "Map_Collection"
                                    , new Type[] { sourceElementType, targetElementType }
                                    , sourceMember, targetMember, p.Config, p.Context));

                                //ee.Add(Expression.Call(targetMember, "AddRange", null
                                //   , Expression.Call(mapperMember, "CreateNewObjectArray_Class_Class"
                                //   , new Type[] { sourceElementType, targetElementType }
                                //   , sourceMember, p.Config, p.Context)));

                                //var param = Expression.Parameter(sourceElementType, "x");
                                //Expression lambdaBody = param;
                                //if (sourceElementType != targetElementType)
                                //{
                                //    var convertMethodInfo = typeof(TypeConverter<,>).MakeGenericType(sourceElementType, targetElementType).GetMethod("Execute");
                                //    lambdaBody = Expression.Call(convertMethodInfo, param);
                                //}
                                //var funcType = typeof(Func<,>).MakeGenericType(sourceElementType, targetElementType);
                                ////var lambda = Expression.Lambda(funcType, lambdaBody, param);
                                //var mapMD = Expression.Call(mapperMember, "Map"
                                //                , new Type[] { sourceElementType, targetElementType }
                                //                , param
                                //                , Expression.New(targetElementConstructor)
                                //                , p.Config, p.Context);
                                //var lambda = Expression.Lambda(funcType, mapMD, param);
                                //var selectMethod = (from m in typeof(Enumerable).GetMethods()
                                //                    where m.Name == "Select"
                                //                    let parameters = m.GetParameters()
                                //                    where parameters[1].ParameterType.GetGenericTypeDefinition() == typeof(Func<,>)
                                //                    select m).First().MakeGenericMethod(sourceElementType, targetElementType);
                                //ee.Add(Expression.Call(targetMember, "AddRange", null
                                //    , Expression.Call(selectMethod, sourceMember, lambda)));
                            }
                            else
                            {
                                var i = Expression.Variable(typeof(Int32), "i");
                                BinaryExpression iAssign = Expression.Assign(i, Expression.Constant(0, typeof(Int32)));
                                var endLoop = Expression.Label("EndLoop");
                                var loopBlock = new List<Expression>();
                                loopBlock.Add(Expression.IfThen
                                                (
                                                    Expression.LessThanOrEqual(Expression.PropertyOrField(sourceMember, "Count"), i),
                                                    Expression.Break(endLoop)
                                                ));
                                loopBlock.Add(Expression.Call(targetMember, "Add", null
                                                , Expression.Call(mapperMember, "Map"
                                                , new Type[] { sourceElementType, targetElementType }
                                                , Expression.Property(sourceIList, "Item", i)
                                                , Expression.New(targetElementConstructor)
                                                , p.Config, p.Context)));
                                loopBlock.Add(Expression.AddAssign(i, Expression.Constant(1)));

                                BlockExpression addCodeBlock = Expression.Block(
                                    typeof(int),
                                    new[] { i },
                                    iAssign,
                                    Expression.Block(
                                        Expression.Loop(
                                            Expression.Block(loopBlock), endLoop), i
                                        )
                                );
                                ee.Add(addCodeBlock);
                            }
                        }
                    }
                }
            }

            return ee;
        }

 }
}
