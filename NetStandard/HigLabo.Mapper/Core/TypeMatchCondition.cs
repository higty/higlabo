using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class TypeMatchCondition
    {
        public Type Type { get; set; }
        public TypeFilterCondition TypeFilterCondition { get; set; }

        public Boolean Match(Type type)
        {
            return (this.Type == null ||
                (this.TypeFilterCondition == TypeFilterCondition.Equal && this.Type == type) ||
                (this.TypeFilterCondition == TypeFilterCondition.Inherit && type.IsInheritanceFrom(this.Type)));
        }
    }
}
