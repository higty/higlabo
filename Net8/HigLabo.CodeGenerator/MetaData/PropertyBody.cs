using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class PropertyBody
    {
        public PropertyBodyType BodyType { get; set; }
        public AccessModifier? Modifier { get; set; }
        public CodeBlockCollection Body { get; private set; }
        public Boolean IsAutomaticProperty { get; set; }
        public PropertyBody(PropertyBodyType bodyType)
        {
            this.BodyType = bodyType;
            this.Modifier = null;
            this.Body = new CodeBlockCollection();
            this.IsAutomaticProperty = false;
        }
    }
}
