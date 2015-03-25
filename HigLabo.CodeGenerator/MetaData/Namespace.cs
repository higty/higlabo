using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class Namespace
    {
        public String Name { get; set; }
        public List<Class> Classes { get; private set; }
        public List<Enum> Enums { get; private set; }
        public Namespace(String name)
        {
            this.Name = name;
            this.Classes = new List<Class>();
            this.Enums = new List<Enum>();
        }
    }
}
