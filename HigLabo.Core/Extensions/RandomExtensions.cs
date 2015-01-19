using System;
using System.Collections.Generic;
using System.Linq;

namespace HigLabo.Core
{
    public static class RandomExtensions
    {
        public static Int32[] NextArray(this Random random, Int32 sourceCount, Int32 resultCount)
        {
            Int32[] source = new Int32[sourceCount];
            for (int i = 0; i < sourceCount; i++)
            {
                source[i] = i;
            }
            return random.NextArray(source, resultCount);
        }
        public static T[] NextArray<T>(this Random random, IEnumerable<T> source, Int32 resultCount)
        {
            var rdm = random;
            var sourceList = source.ToList();
            var resultList = new T[resultCount];
            for (int i = 0; i < resultCount; i++)
            {
                var index = rdm.Next(sourceList.Count);
                resultList[i] = sourceList[index];
                sourceList.RemoveAt(index);
            }
            return resultList;
        }
    }
}
