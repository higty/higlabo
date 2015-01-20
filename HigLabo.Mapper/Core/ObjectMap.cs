using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class ObjectMap
    {
        public List<PropertyMap> PropertyMaps { get; private set; }

        public ObjectMap(IEnumerable<PropertyMap> maps)
        {
            this.PropertyMaps = new List<PropertyMap>();
            this.PropertyMaps.AddRange(maps);
        }
    }
}
