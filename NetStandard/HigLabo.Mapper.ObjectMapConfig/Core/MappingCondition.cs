using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class MappingCondition
    {
        public TypeMatchCondition Source { get; set; }
        public TypeMatchCondition Target { get; set; }

        public MappingCondition()
        {
            this.Source = new TypeMatchCondition();
            this.Target = new TypeMatchCondition();
        }
        public Boolean Match(Type sourceType, Type targetType)
        {
            return this.Source.Match(sourceType) == true &&
                this.Target.Match(targetType) == true;
        }
    }
}
