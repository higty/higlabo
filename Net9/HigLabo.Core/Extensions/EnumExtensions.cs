using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace HigLabo.Core;

public static class EnumExtensions
{
    public static String? ToStringOrNullFromEnum<T>(this Nullable<T> value)
        where T : struct, Enum
    {
        if (value.HasValue == true) return ToStringFromEnum(value.Value);
        return null;
    }
    public static String ToStringFromEnum<T>(this Nullable<T> value)
        where T : struct, Enum
    {
        if (value.HasValue == true) return ToStringFromEnum(value.Value);
        return "";
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static String ToStringFromEnum<T>(this T value)
        where T : struct, Enum
    {
        var directNames = EnumToStringCache<T>.DirectInt32Names;
        if (directNames != null)
        {
            var numericValue = Unsafe.BitCast<T, Int32>(value);
            var index = unchecked(numericValue - EnumToStringCache<T>.DirectInt32Offset);
            if ((UInt32)index < (UInt32)directNames.Length)
            {
                return directNames[index];
            }
        }
        return EnumToStringCache<T>.ToString(value);
    }
    public static String ToStringFromEnum(this Enum value)
    {
        return value.ToString();
    }

    private static class EnumToStringCache<T>
        where T : struct, Enum
    {
        private const Int32 MaxDirectNameCount = 1024;

        private static readonly Boolean _IsFlags;
        private static readonly EnumNameDictionary _NameByValue;

        public static readonly String[]? DirectInt32Names;
        public static readonly Int32 DirectInt32Offset;

        static EnumToStringCache()
        {
            var type = typeof(T);
            _IsFlags = type.IsDefined(typeof(FlagsAttribute), false);

            var enumValues = (T[])Enum.GetValues(type);
            var enumNames = Enum.GetNames(type);
            var valueSet = new HashSet<T>();
            var valueList = new List<T>(enumValues.Length);
            var nameList = new List<String>(enumNames.Length);
            var allBits = 0UL;

            for (var i = 0; i < enumValues.Length; i++)
            {
                var value = enumValues[i];
                if (valueSet.Add(value) == true)
                {
                    valueList.Add(value);
                    nameList.Add(enumNames[i]);
                }
                if (_IsFlags == true)
                {
                    allBits |= ToUInt64(value);
                }
            }

            if (_IsFlags == true && allBits < 256)
            {
                for (var i = 0UL; i <= allBits; i++)
                {
                    if ((i & ~allBits) != 0) { continue; }

                    var value = ToEnum(i);
                    if (valueSet.Add(value) == true)
                    {
                        valueList.Add(value);
                        nameList.Add(ToStringFromFlags(value));
                    }
                }
            }

            var values = valueList.ToArray();
            var names = nameList.ToArray();
            DirectInt32Names = CreateDirectInt32Names(values, names, out DirectInt32Offset);
            _NameByValue = new EnumNameDictionary(values, names);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static String ToString(T value)
        {
            if (_NameByValue.TryGetValue(value, out var name) == true)
            {
                return name;
            }
            if (_IsFlags == true)
            {
                return ToStringFromFlags(value);
            }
            throw new InvalidOperationException();
        }

        private static String[]? CreateDirectInt32Names(T[] values, String[] names, out Int32 valueOffset)
        {
            if (Unsafe.SizeOf<T>() != sizeof(Int32) || values.Length == 0)
            {
                valueOffset = 0;
                return null;
            }

            var minimum = Int32.MaxValue;
            var maximum = Int32.MinValue;
            for (var i = 0; i < values.Length; i++)
            {
                var enumValue = values[i];
                var value = Unsafe.BitCast<T, Int32>(enumValue);
                minimum = Math.Min(minimum, value);
                maximum = Math.Max(maximum, value);
            }

            var range = (Int64)maximum - minimum;
            if (range >= MaxDirectNameCount || range + 1 != values.Length)
            {
                valueOffset = 0;
                return null;
            }

            valueOffset = minimum;
            var directNames = new String[(Int32)range + 1];
            for (var i = 0; i < values.Length; i++)
            {
                var enumValue = values[i];
                var value = Unsafe.BitCast<T, Int32>(enumValue);
                directNames[value - minimum] = names[i];
            }
            return directNames;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt64 ToUInt64(T value)
        {
            return Unsafe.SizeOf<T>() switch
            {
                1 => Unsafe.As<T, Byte>(ref value),
                2 => Unsafe.As<T, UInt16>(ref value),
                4 => Unsafe.As<T, UInt32>(ref value),
                8 => Unsafe.As<T, UInt64>(ref value),
                _ => throw new InvalidOperationException(),
            };
        }
        private static T ToEnum(UInt64 value)
        {
            switch (Unsafe.SizeOf<T>())
            {
                case 1:
                    var byteValue = (Byte)value;
                    return Unsafe.As<Byte, T>(ref byteValue);
                case 2:
                    var ushortValue = (UInt16)value;
                    return Unsafe.As<UInt16, T>(ref ushortValue);
                case 4:
                    var uintValue = (UInt32)value;
                    return Unsafe.As<UInt32, T>(ref uintValue);
                case 8:
                    return Unsafe.As<UInt64, T>(ref value);
                default:
                    throw new InvalidOperationException();
            }
        }
        private static String ToStringFromFlags(T value)
        {
            return value.ToString().Replace(" ", "");
        }

        private sealed class EnumNameDictionary
        {
            private static readonly EqualityComparer<T> _Comparer = EqualityComparer<T>.Default;
            private readonly Entry?[] _Buckets;
            private readonly Int32 _IndexMask;

            public EnumNameDictionary(T[] values, String[] names)
            {
                var capacity = GetCapacity(values.Length);
                _Buckets = new Entry[capacity];
                _IndexMask = capacity - 1;

                for (var i = 0; i < values.Length; i++)
                {
                    var index = _Comparer.GetHashCode(values[i]) & _IndexMask;
                    _Buckets[index] = new Entry(values[i], names[i], _Buckets[index]);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Boolean TryGetValue(T key, out String value)
            {
                var index = _Comparer.GetHashCode(key) & _IndexMask;
                var entry = _Buckets[index];
                while (entry != null)
                {
                    if (_Comparer.Equals(entry.Key, key) == true)
                    {
                        value = entry.Value;
                        return true;
                    }
                    entry = entry.Next;
                }
                value = null!;
                return false;
            }

            private static Int32 GetCapacity(Int32 count)
            {
                var size = Math.Max(4, (count * 4 + 2) / 3);
                size--;
                size |= size >> 1;
                size |= size >> 2;
                size |= size >> 4;
                size |= size >> 8;
                size |= size >> 16;
                return size + 1;
            }

            private sealed class Entry
            {
                public readonly T Key;
                public readonly String Value;
                public readonly Entry? Next;

                public Entry(T key, String value, Entry? next)
                {
                    Key = key;
                    Value = value;
                    Next = next;
                }
            }
        }
    }
}
