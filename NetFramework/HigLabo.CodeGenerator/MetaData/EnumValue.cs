using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class EnumValue
    {
        public String Text { get; set; }
        public Int32? Value { get; set; }

        public EnumValue(String text)
        {
            this.Text = text;
        }
        public EnumValue(String text, Int32 value)
        {
            this.Text = text;
            this.Value = value;
        }
        public override string ToString()
        {
            if (this.Value.HasValue)
            {
                return String.Format("{0} = {1}", this.Text, this.Value);
            }
            return this.Text;
        }
    }
}
