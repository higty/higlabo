using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class PropertyMapInfo
    {
        public String Name { get; private set; }
        internal PropertyInfo PropertyInfo { get; private set; }
        public Type PropertyType { get; private set; }
        internal Type ActualType { get; private set; }
        internal Boolean IsNullableT { get; private set; }
        /// <summary>
        /// True when PropertyType is class or Nullable&lt;T>
        /// </summary>
        public Boolean CanBeNull { get; private set; }
        public Boolean IsIndexedProperty { get; private set; }
        public String IndexedPropertyKey { get; set; }

        public PropertyMapInfo(PropertyInfo propertyInfo)
        {
            this.Name = propertyInfo.Name;
            this.PropertyInfo = propertyInfo;

            this.PropertyType = propertyInfo.PropertyType;
            this.IsNullableT = propertyInfo.PropertyType.IsInheritanceFrom(typeof(Nullable<>));
            this.IsIndexedProperty = propertyInfo.GetIndexParameters().Length > 0;
            if (this.IsNullableT == true)
            {
                this.ActualType = propertyInfo.PropertyType.GenericTypeArguments[0];
                this.CanBeNull = true;
            }
            else
            {
                this.ActualType = propertyInfo.PropertyType;
                this.CanBeNull = this.ActualType.IsValueType == false;
            }
        }
        public override string ToString()
        {
            return String.Format("{0}: {1}", this.Name, this.PropertyType);
        }
    }
}
