using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;

namespace HigLabo.Core
{
    public partial class TypeConverter
    {
        private static ConcurrentDictionary<Type, MulticastDelegate> _ToEnumMethods = new ConcurrentDictionary<Type, MulticastDelegate>();

        public Object ToEnum(String value, Type type, StringComparison comparisonType)
        {
            var tp = type;
            if (tp.IsEnum == false) throw new ArgumentException("value must be a enum type");

            MulticastDelegate md = null;
            if (_ToEnumMethods.TryGetValue(tp, out md) == false)
            {
                md = CreateToEnumFunc(type);
                _ToEnumMethods[tp] = md;
            }
            var f = (Func<String, StringComparison, Object>)md;
            return f(value, comparisonType);
        }
        private static Func<String, StringComparison, Object> CreateToEnumFunc(Type type)
        {
            var tp = type;
            DynamicMethod dm = new DynamicMethod("ToEnum", typeof(Object)
                , new[] { typeof(String), typeof(StringComparison) });
            ILGenerator il = dm.GetILGenerator();
            var stringEqualsMethod = typeof(String).GetMethod("Equals"
                , new Type[] { typeof(String), typeof(String), typeof(StringComparison) });
            var values = Enum.GetValues(tp);
            var names = Enum.GetNames(tp).ToArray();

            var skipLabels = new Label[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                skipLabels[i] = il.DefineLabel();
            }
            for (int i = 0; i < names.Length; i++)
            {
                il.Emit(OpCodes.Ldarg_0);//value
                il.Emit(OpCodes.Ldstr, names[i]);
                il.Emit(OpCodes.Ldarg_1);//StringComparison
                il.Emit(OpCodes.Call, stringEqualsMethod);
                il.Emit(OpCodes.Brfalse_S, skipLabels[i]);
                {
                    var eValue = values.GetValue(i);
                    il.Emit(OpCodes.Ldc_I4, System.Convert.ToInt32(eValue));
                    il.Emit(OpCodes.Box, tp);
                    il.Emit(OpCodes.Ret);
                }
                il.MarkLabel(skipLabels[i]);
            }
            il.Emit(OpCodes.Ldnull);
            il.Emit(OpCodes.Ret);

            var f = typeof(Func<String, StringComparison, Object>);
            return (Func<String, StringComparison, Object>)dm.CreateDelegate(f);
        }
    }
}
