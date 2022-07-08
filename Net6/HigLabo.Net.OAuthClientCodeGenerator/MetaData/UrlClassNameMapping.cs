using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.CodeGenerator
{
    public class UrlClassNameMapping
    {
        public string Url { get; set; }
        public string ClassName { get; set; }

        public UrlClassNameMapping(string url, string className)
        {
            this.Url = url;
            this.ClassName = className;
        }
        public override string ToString()
        {
            return $"{this.ClassName} {this.Url}";
        }
    }
}
