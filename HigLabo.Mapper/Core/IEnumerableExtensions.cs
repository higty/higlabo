using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<TTarget> MapTo<TTarget>(this IEnumerable<Object> source)
            where TTarget : new ()
        {
            return source.Select(el => el.Map(new TTarget()));
        }
        public static IEnumerable<TTarget> MapTo<TTarget>(this IEnumerable<Object> source, Func<TTarget> constructor)
        {
            return source.Select(el => el.Map(constructor()));
        }
    }
}
