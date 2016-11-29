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
        }
        public PropertyMap(PropertyInfo source, String sourceIndexedKey, PropertyInfo target)
        {
            this.Source = new PropertyMapInfo(source);
            this.Source.IndexedPropertyKey = sourceIndexedKey;
            this.Target = new PropertyMapInfo(target);
        }
        public PropertyMap(PropertyInfo source, PropertyInfo target, String targetIndexedKey)
        {
            this.Source = new PropertyMapInfo(source);
            this.Target = new PropertyMapInfo(target);
            this.Target.IndexedPropertyKey = targetIndexedKey;
        }
        public override string ToString()
        {
            return String.Format("{0} <=> {1}", this.Source.Name, this.Target.Name);
        }
    }
}
