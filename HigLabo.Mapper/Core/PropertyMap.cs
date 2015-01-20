using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace HigLabo.Core
{
    public class PropertyMap
    {
        public PropertyMapInfo Source { get; private set; }
        public PropertyMapInfo Target { get; private set; }

        public PropertyMap(PropertyInfo source, PropertyInfo target)
        {
            this.Source = new PropertyMapInfo(source);
            this.Target = new PropertyMapInfo(target);
            if (this.Source.IsIndexedProperty == true)
            {
                this.Source.IndexedPropertyKey = target.Name;
            }
            if (this.Target.IsIndexedProperty == true)
            {
                this.Target.IndexedPropertyKey = source.Name;
            }
        }
        public override string ToString()
        {
            return String.Format("{0} <=> {1}", this.Source.Name, this.Target.Name);
        }
    }
}
