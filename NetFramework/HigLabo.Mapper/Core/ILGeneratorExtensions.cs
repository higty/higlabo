using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HigLabo.Core
{
    public static class ILGeneratorExtensions
    {
        public static void LoadLocal(this ILGenerator il, LocalBuilder local)
        {
            if (local.LocalIndex < 256)
            {
                il.Emit(OpCodes.Ldloc_S, (byte)local.LocalIndex);
            }
            else
            {
                il.Emit(OpCodes.Ldloc, (ushort)local.LocalIndex);
            }
        }
        public static void LoadLocala(this ILGenerator il, LocalBuilder local)
        {
            if (local.LocalIndex < 256)
            {
                il.Emit(OpCodes.Ldloca_S, (byte)local.LocalIndex);
            }
            else
            {
                il.Emit(OpCodes.Ldloca, (ushort)local.LocalIndex);
            }
        }
        public static void SetLocal(this ILGenerator il, LocalBuilder local)
        {
            if (local.LocalIndex < 256)
            {
                il.Emit(OpCodes.Stloc_S, local);
            }
            else
            {
                il.Emit(OpCodes.Stloc, local);
            }
        }
    }
}
