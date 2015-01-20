using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class PropertyNameMapList : List<PropertyNameMap>
    {
        public void Add(String sourcePropertyName, String targetPropertyName)
        {
            this.Add(new PropertyNameMap(sourcePropertyName, targetPropertyName));
        }
    }
}
