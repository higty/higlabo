using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace HigLabo.Core
{
    public static class EnumExtensions
    {
        private static ConcurrentDictionary<Type, MulticastDelegate> _ToStringFromEnumMethods = new ConcurrentDictionary<Type, MulticastDelegate>();

        public static String ToStringOrNullFromEnum<T>(this Nullable<T> value)
            where T : struct
        {
            if (value.HasValue == true) return ToStringFromEnum(value.Value);
            return null;
        }
        public static String ToStringFromEnum<T>(this Nullable<T> value)
            where T : struct
        {
            if (value.HasValue == true) return ToStringFromEnum(value.Value);
            return "";
        }
        public static String ToStringFromEnum<T>(this T value)
            where T : struct
        {
            var tp = typeof(T);
            if (tp.IsEnum == false) throw new ArgumentException("value must be a enum type");

            MulticastDelegate md = null;
            if (_ToStringFromEnumMethods.TryGetValue(tp, out md) == false)
            {
                var aa = tp.GetCustomAttributes(typeof(FlagsAttribute), false);
                if (aa.Length == 0)
                {
                    md = CreateToStringFromEnumFunc<T>();
                }
                _ToStringFromEnumMethods[tp] = md;
            }
            // Flags
            if (md == null) return value.ToString().Replace(" ", "");

            var f = (Func<T, String>)md;
            return f(value);
        }
        private static Func<T, String> CreateToStringFromEnumFunc<T>()
        {
            var tp = typeof(T);
            DynamicMethod dm = new DynamicMethod("ToStringFromEnum", typeof(String), new[] { tp });
            ILGenerator il = dm.GetILGenerator();

            var values = ((T[])Enum.GetValues(tp)).Select(el => Convert.ToInt64(el)).ToList();
            var names = Enum.GetNames(tp);

            var returnLabel = il.DefineLabel();
            //Have any value different from index number
            if (values.Where((el, i) => el != i).Any())
            {
                var result = il.DeclareLocal(typeof(String));

                for (int i = 0; i < values.Count; i++)
                {
                    il.Emit(OpCodes.Ldarg_0);
                    il.Emit(OpCodes.Conv_I8);
                    il.Emit(OpCodes.Ldc_I8, values[i]);
                    il.Emit(OpCodes.Ceq);

                    var label = il.DefineLabel();
                    il.Emit(OpCodes.Brfalse, label);

                    il.Emit(OpCodes.Ldstr, names[i]);
                    il.Emit(OpCodes.Stloc, result);
                    il.Emit(OpCodes.Br, returnLabel);

                    il.MarkLabel(label);
                }
                il.ThrowException(typeof(InvalidOperationException));

                il.MarkLabel(returnLabel);
                il.Emit(OpCodes.Ldloc, result);
                il.Emit(OpCodes.Ret);
            }
            else
            {
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Conv_I8);
                il.Emit(OpCodes.Ldc_I4, 0);
                il.Emit(OpCodes.Conv_I8);
                il.Emit(OpCodes.Clt);
                il.Emit(OpCodes.Brtrue, returnLabel);

                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Conv_I8);
                il.Emit(OpCodes.Ldc_I4, names.Length - 1);
                il.Emit(OpCodes.Conv_I8);
                il.Emit(OpCodes.Cgt);
                il.Emit(OpCodes.Brtrue, returnLabel);

                il.Emit(OpCodes.Ldarg_0);
                var caseLabels = new Label[names.Length + 1];
                for (int i = 0; i < names.Length; i++)
                {
                    caseLabels[i] = il.DefineLabel();
                }
                Label defaultCase = il.DefineLabel();
                caseLabels[names.Length] = defaultCase;
                il.Emit(OpCodes.Switch, caseLabels);
                for (int i = 0; i < names.Length; i++)
                {
                    // Case ??: return "";
                    il.MarkLabel(caseLabels[i]);
                    il.Emit(OpCodes.Ldstr, names[i]);
                    il.Emit(OpCodes.Ret);
                }
                il.MarkLabel(defaultCase);
                il.ThrowException(typeof(InvalidOperationException));

                il.MarkLabel(returnLabel);
                il.ThrowException(typeof(InvalidOperationException));
            }

            var f = typeof(Func<,>);
            var gf = f.MakeGenericType(tp, typeof(String));
            return (Func<T, String>)dm.CreateDelegate(gf);
        }
    }
}
