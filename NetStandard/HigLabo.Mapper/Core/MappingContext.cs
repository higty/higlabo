using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class MappingContext
    {
        public Int32 MaxCallStackCount { get; set; }
        public Int32 CallStackCount { get; set; }
        public Int32 LayerLevel { get; set; }

        internal MappingContext(Int32 maxCallStackCount)
        {
            this.MaxCallStackCount = maxCallStackCount;
            this.CallStackCount = 0;
            this.LayerLevel = 0;
        }
        public Boolean MaxCallStackCountOver()
        {
            return this.CallStackCount > this.MaxCallStackCount;
        }
    }
}
