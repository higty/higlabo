using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator.Twitter
{
    public class TwitterApiCommandParameterInfo
    {
        public String Name { get; set; }
        public TypeName TypeName { get; set; }
        public Boolean Required { get; set; }

        public TwitterApiCommandParameterInfo(String name, TypeName typeName, Boolean required)
        {
            this.Name = name;
            this.TypeName = typeName;
            this.Required = required;
        }
        public override string ToString()
        {
            if (this.Required == true)
            {
                return String.Format("{0}:{1} (Required)", this.Name, this.TypeName.ToString());
            }
            return String.Format("{0}:{1}", this.Name, this.TypeName.ToString());
        }
    }
}
