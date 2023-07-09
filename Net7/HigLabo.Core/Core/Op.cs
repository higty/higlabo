using System;
using System.Collections.Generic;
using System.Linq;

namespace HigLabo.Core
{
    public class Op
    {
        public static Boolean HasValue<T>(T value)
        {
            return value != null;
        }
        public static T Negate<T>(T value)
        {
            return Operator<T>.Negate(value);
        }
        public static T Not<T>(T value)
        {
            return Operator<T>.Not(value);
        }
        public static T Or<T>(T value1, T value2)
        {
            return Operator<T>.Or(value1, value2);
        }
        public static T And<T>(T value1, T value2)
        {
            return Operator<T>.And(value1, value2);
        }
        public static T Xor<T>(T value1, T value2)
        {
            return Operator<T>.Xor(value1, value2);
        }
        public static TResult Convert<TFrom, TResult>(TFrom value)
        {
            return Operator<TFrom, TResult>.Convert(value);
        }
        public static T Add<T>(T value1, T value2)
        {
            return Operator<T>.Add(value1, value2);
        }
        public static TArg1 Add<TArg1, TArg2>(TArg1 value1, TArg2 value2)
        {
            return Operator<TArg2, TArg1>.Add(value1, value2);
        }
        public static T Sub<T>(T value1, T value2)
        {
            return Operator<T>.Subtract(value1, value2);
        }
        public static TArg1 Sub<TArg1, TArg2>(TArg1 value1, TArg2 value2)
        {
            return Operator<TArg2, TArg1>.Subtract(value1, value2);
        }
        public static T Mul<T>(T value1, T value2)
        {
            return Operator<T>.Multiply(value1, value2);
        }
        public static TArg1 Mul<TArg1, TArg2>(TArg1 value1, TArg2 value2)
        {
            return Operator<TArg2, TArg1>.Multiply(value1, value2);
        }
        public static T Div<T>(T value1, T value2)
        {
            return Operator<T>.Divide(value1, value2);
        }
        public static TArg1 Div<TArg1, TArg2>(TArg1 value1, TArg2 value2)
        {
            return Operator<TArg2, TArg1>.Divide(value1, value2);
        }
        public static Boolean Eq<T>(T value1, T value2)
        {
            return Operator<T>.Equal(value1, value2);
        }
        public static Boolean NotEq<T>(T value1, T value2)
        {
            return Operator<T>.NotEqual(value1, value2);
        }
        public static Boolean Gt<T>(T value1, T value2)
        {
            return Operator<T>.GreaterThan(value1, value2);
        }
        public static Boolean Lt<T>(T value1, T value2)
        {
            return Operator<T>.LessThan(value1, value2);
        }
        public static Boolean GtEq<T>(T value1, T value2)
        {
            return Operator<T>.GreaterThanOrEqual(value1, value2);
        }
        public static Boolean LtEq<T>(T value1, T value2)
        {
            return Operator<T>.LessThanOrEqual(value1, value2);
        }
        public static T Div<T>(T value, Int32 divisor)
        {
            return Operator<Int32, T>.Divide(value, divisor);
        }
    }
}
