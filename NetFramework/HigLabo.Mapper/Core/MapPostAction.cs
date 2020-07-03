using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class MapPostAction
    {
        public MappingCondition Condition { get; set; }
        public Delegate Action { get; set; }
        public MapPostAction(MappingCondition condition, Delegate action)
        {
            this.Condition = condition;
            this.Action = action;
        }
    }
}
