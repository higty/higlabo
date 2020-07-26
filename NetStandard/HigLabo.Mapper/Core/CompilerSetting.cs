using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HigLabo.Core
{
    public class CompilerSetting
    {
        private Func<PropertyInfo, PropertyInfo, Boolean> _PropertyMatchRule = (p1, p2) => p1.Name == p2.Name;
        public Func<PropertyInfo, PropertyInfo, Boolean> PropertyMatchRule
        {
            get { return _PropertyMatchRule; }
            set
            {
                if (value == null) { return; }
                _PropertyMatchRule = value;
            }
        }
        public ClassPropertyCreateMode ClassPropertyCreateMode { get; set; } = ClassPropertyCreateMode.NewObject;
        public CollectionPropertyCreateMode CollectionPropertyCreateMode { get; set; } = CollectionPropertyCreateMode.NewObject;
        public CollectionElementCreateMode CollectionElementCreateMode { get; set; } = CollectionElementCreateMode.NewObject;
        public Int32 ChildPropertyRecursiveCount { get; set; } = 5;

        public Boolean MatchProperty(PropertyInfo source, PropertyInfo target)
        {
            return _PropertyMatchRule(source, target);
        }
    }
}
