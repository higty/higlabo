using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HigLabo.Core
{
    /// <summary>
    /// Copyright from 
    /// http://blog.gauffin.org/2010/11/simplified-localization-for-dataannotations/#.UZ3me6JSjqs
    /// </summary>
    public class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        private PropertyInfo _NameProperty;
        private Type _ResourceType;

        public LocalizedDisplayNameAttribute(string displayNameKey)
            : base(displayNameKey)
        {

        }
        public Type NameResourceType
        {
            get
            {
                return _ResourceType;
            }
            set
            {
                _ResourceType = value;
                _NameProperty = _ResourceType.GetProperty(base.DisplayName, BindingFlags.Static | BindingFlags.Public);
            }
        }
        public override string DisplayName
        {
            get
            {
                if (_NameProperty == null)
                {
                    return base.DisplayName;
                }
                return (string)_NameProperty.GetValue(_NameProperty.DeclaringType, null);
            }
        }
    }
}
