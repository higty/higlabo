using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class SourceCode
    {
        public List<String> UsingNamespaces { get; private set; }
        public List<Namespace> Namespaces { get; private set; }
        public SourceCode()
        {
            this.UsingNamespaces = new List<string>();
            this.Namespaces = new List<Namespace>();
        }
    }
}
