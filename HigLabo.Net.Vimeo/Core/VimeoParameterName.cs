using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Vimeo
{
    public class VimeoParameterName : Attribute
    {
        public String Name { get; set; }

        public VimeoParameterName(String name)
        {
            this.Name = name;
        }
    }
}
