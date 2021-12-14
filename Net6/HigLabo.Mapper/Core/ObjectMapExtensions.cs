using System;

namespace HigLabo.Core
{
    public static class ObjectMapperExtensions
    {
        public static TTarget Map<TSource, TTarget>(this TSource source, TTarget target)
        {
            return ObjectMapper.Default.Map(source, target);
        }
        public static TTarget MapOrNull<TSource, TTarget>(this TSource source, Func<TTarget> targetConstructor)
            where TTarget : class
        {
            return ObjectMapper.Default.MapOrNull(source, targetConstructor);
        }
        public static TTarget MapOrNull<TSource, TTarget>(this TSource source, TTarget target)
            where TTarget : class
        {
            return ObjectMapper.Default.MapOrNull(source, target);
        }
        public static TTarget MapFrom<TTarget, TSource>(this TTarget target, TSource source)
        {
            return ObjectMapper.Default.Map(source, target);
        }
    }
}
