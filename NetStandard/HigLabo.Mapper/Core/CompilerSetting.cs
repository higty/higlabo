using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HigLabo.Core
{
    public class CompilerSetting
    {
        private Func<Type, PropertyInfo, Type, PropertyInfo, Boolean> _PropertyMatchRule = (c1, p1, c2, p2) => String.Equals(p1.Name, p2.Name, StringComparison.OrdinalIgnoreCase);

        public Func<Type, PropertyInfo, Type, PropertyInfo, Boolean> PropertyMatchRule
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
        public Int32 ChildPropertyRecursiveCount { get; set; } = 4;

        public Boolean MatchProperty(Type sourceType, PropertyInfo sourceProperty, Type targetType, PropertyInfo targetProperty)
        {
            return _PropertyMatchRule(sourceType, sourceProperty, targetType, targetProperty);
        }
    }
}
