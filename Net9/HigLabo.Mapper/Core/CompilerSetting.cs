using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace HigLabo.Core;

public class CompilerSetting
{
    private Func<Type, PropertyInfo, Type, PropertyInfo, Boolean> _PropertyMatchRule = (c1, p1, c2, p2) => String.Equals(p1.Name, p2.Name, StringComparison.OrdinalIgnoreCase);
    private Func<String, String> _DictionaryKeyConvertRule = s => s;

    public Func<Type, PropertyInfo, Type, PropertyInfo, Boolean> PropertyMatchRule
    {
        get { return _PropertyMatchRule; }
        set
        {
            if (value == null) { return; }
            _PropertyMatchRule = value;
        }
    }
    public Func<String, String> DictionaryKeyConvertRule
    {
        get { return _DictionaryKeyConvertRule; }
        set
        {
            if (value == null) { return; }
            _DictionaryKeyConvertRule = value;
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
