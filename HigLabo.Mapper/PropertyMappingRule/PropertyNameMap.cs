using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class PropertyNameMap
    {
        public String SourcePropertyName { get; set; }
        public String TargetPropertyName { get; set; }

        public PropertyNameMap(String sourcePropertyName, String targetPropertyName)
        {
            this.SourcePropertyName = sourcePropertyName;
            this.TargetPropertyName = targetPropertyName;
        }
    }
}
