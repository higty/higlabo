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
        public List<Interface> Interfaces { get; private set; }= new List<Interface>();
        public List<Class> Classes { get; private set; } = new List<Class>();
        public List<Enum> Enums { get; private set; } = new List<Enum>();
        public Namespace(String name)
        {
            this.Name = name;
        }
    }
}
