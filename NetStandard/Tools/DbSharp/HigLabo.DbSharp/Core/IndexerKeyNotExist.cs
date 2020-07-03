using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public class IndexerKeyNotExist
    {
        private static readonly IndexerKeyNotExist _Value = new IndexerKeyNotExist();
        /// <summary>
        /// 
        /// </summary>
        public static IndexerKeyNotExist Value
        {
            get { return _Value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private IndexerKeyNotExist()
        {
        }
    }
}
