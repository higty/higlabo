using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.CodeGenerator
{
    public class ClassModifier
    {
        public AccessModifier AccessModifier { get; set; }
        public Boolean Static { get; set; }
        public Boolean Abstract { get; set; }
        public Boolean Partial { get; set; }
        public ClassModifier()
            : this(AccessModifier.Public)
        {
        }
        public ClassModifier(AccessModifier accessModifier)
        {
            this.AccessModifier = accessModifier;
            this.Static = false;
            this.Abstract = false;
            this.Partial = false;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.AccessModifier.ToString().ToLower());
            if (this.Static) { sb.Append(" static"); }
            if (this.Abstract) { sb.Append(" abstract"); }
            if (this.Partial) { sb.Append(" partial"); }
            
            return sb.ToString();
        }
    }
}
