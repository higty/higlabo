using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core
{
    public class EqualityFunc<T> : IEqualityComparer<T>
    {
        private Func<T, T, Boolean> _Comparer = null;
        public EqualityFunc(Func<T, T, Boolean> comparer)
        {
            _Comparer = comparer;
        }
        public static EqualityFunc<T1> Create<T1>(Func<T1, T1, Boolean> comparer)
        {
            return new EqualityFunc<T1>(comparer);
        }
        public Boolean Equals(T x, T y)
        {
            if (x == null && y == null) return true;
            else if (x == null || y == null) return false;
            return _Comparer(x, y);
        }
        public int GetHashCode(T obj)
        {
            return 0;
        }
    }
}
