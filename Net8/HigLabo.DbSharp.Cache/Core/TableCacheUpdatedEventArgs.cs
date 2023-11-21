using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public class TableCacheUpdatedEventArgs
    {
        public DateTimeOffset UpdateTime { get; set; } = DateTimeOffset.Now;
        public List<String> TableNameList { get; set; } = new();

        public TableCacheUpdatedEventArgs()
        {
        }
        public TableCacheUpdatedEventArgs(DateTimeOffset updateTime)
        {
            this.UpdateTime = updateTime;
        }
    }
}
