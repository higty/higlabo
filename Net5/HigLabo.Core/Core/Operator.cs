using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HigLabo.Core
{
    public class Operator
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
        public static T Subtract<T>(T value1, T value2)
        {
            return Operator<T>.Subtract(value1, value2);
        }
        public static TArg1 Subtract<TArg1, TArg2>(TArg1 value1, TArg2 value2)
        {
            return Operator<TArg2, TArg1>.Subtract(value1, value2);
        }
        public static T Multiply<T>(T value1, T value2)
        {
            return Operator<T>.Multiply(value1, value2);
        }
        public static TArg1 Multiply<TArg1, TArg2>(TArg1 value1, TArg2 value2)
        {
            return Operator<TArg2, TArg1>.Multiply(value1, value2);
        }
        public static T Divide<T>(T value1, T value2)
        {
            return Operator<T>.Divide(value1, value2);
        }
        public static TArg1 Divide<TArg1, TArg2>(TArg1 value1, TArg2 value2)
        {
            return Operator<TArg2, TArg1>.Divide(value1, value2);
        }
        public static Boolean Equal<T>(T value1, T value2)
        {
            return Operator<T>.Equal(value1, value2);
        }
        public static Boolean NotEqual<T>(T value1, T value2)
        {
            return Operator<T>.NotEqual(value1, value2);
        }
        public static Boolean GreaterThan<T>(T value1, T value2)
        {
            return Operator<T>.GreaterThan(value1, value2);
        }
        public static Boolean LessThan<T>(T value1, T value2)
        {
            return Operator<T>.LessThan(value1, value2);
        }
        public static Boolean GreaterThanOrEqual<T>(T value1, T value2)
        {
            return Operator<T>.GreaterThanOrEqual(value1, value2);
        }
        public static Boolean LessThanOrEqual<T>(T value1, T value2)
        {
            return Operator<T>.LessThanOrEqual(value1, value2);
        }
        public static T Divide<T>(T value, Int32 divisor)
        {
            return Operator<Int32, T>.Divide(value, divisor);
        }

        public static Func<TArg1, TResult> CreateExpression<TArg1, TResult>(Func<Expression, UnaryExpression> body)
        {
            ParameterExpression p = Expression.Parameter(typeof(TArg1), "value");
            try
            {
                return Expression.Lambda<Func<TArg1, TResult>>(body(p), p).Compile();
            }
            catch (Exception ex)
            {
                return delegate { throw new InvalidOperationException(ex.Message); };
            }
        }
        public static Func<TArg1, TArg2, TResult> CreateExpression<TArg1, TArg2, TResult>(Func<Expression, Expression, BinaryExpression> body)
        {
            return CreateExpression<TArg1, TArg2, TResult>(body, false);
        }
        public static Func<TArg1, TArg2, TResult> CreateExpression<TArg1, TArg2, TResult>(Func<Expression, Expression, BinaryExpression> body, Boolean canCast)
        {
            ParameterExpression leftParameter = Expression.Parameter(typeof(TArg1), "leftParameter");
            ParameterExpression rightParameter = Expression.Parameter(typeof(TArg2), "rightParameter");

            try
            {
                return Expression.Lambda<Func<TArg1, TArg2, TResult>>(body(leftParameter, rightParameter), leftParameter, rightParameter).Compile();
            }
            catch (InvalidOperationException ex)
            {
                if (canCast == false)
                {
                    return delegate { throw new InvalidOperationException(ex.Message); };
                }
            }
            try
            {
                if (typeof(TArg1) != typeof(TResult) || typeof(TArg2) != typeof(TResult))
                {
                    Expression castLeftParameter = null;
                    Expression castRightParameter = null;

                    if (typeof(TArg1) == typeof(TResult))
                    {
                        castLeftParameter = (Expression)leftParameter;
                    }
                    else
                    {
                        castLeftParameter = (Expression)Expression.Convert(leftParameter, typeof(TResult));
                    }
                    if (typeof(TArg2) == typeof(TResult))
                    {
                        castRightParameter = (Expression)rightParameter;
                    }
                    else
                    {
                        castRightParameter = (Expression)Expression.Convert(rightParameter, typeof(TResult));
                    }
                    return Expression.Lambda<Func<TArg1, TArg2, TResult>>(body(castLeftParameter, castRightParameter)
                        , leftParameter, rightParameter).Compile();
                }
            }
            catch (Exception ex)
            {
                return delegate { throw new InvalidOperationException(ex.Message); };
            }
            return delegate { throw new InvalidOperationException(); };
        }
    }
    internal static class Operator<T>
    {
        private static readonly Func<T, T> _Negate = null;
        private static readonly Func<T, T> _Not = null;
        private static readonly Func<T, T, T> _Or = null;
        private static readonly Func<T, T, T> _And = null;
        private static readonly Func<T, T, T> _Xor = null;
        private static readonly Func<T, T, T> _Add = null;
        private static readonly Func<T, T, T> _Subtract = null;
        private static readonly Func<T, T, T> _Multiply = null;
        private static readonly Func<T, T, T> _Divide = null;
        private static readonly Func<T, T, Boolean> _Equal = null;
        private static readonly Func<T, T, Boolean> _NotEqual = null;
        private static readonly Func<T, T, Boolean> _GreaterThan = null;
        private static readonly Func<T, T, Boolean> _GreaterThanOrEqual = null;
        private static readonly Func<T, T, Boolean> _LessThan = null;
        private static readonly Func<T, T, Boolean> _LessThanOrEqual = null;

        public static Func<T, T> Negate
        {
            get { return _Negate; }
        }
        public static Func<T, T> Not
        {
            get { return _Not; }
        }
        public static Func<T, T, T> Or
        {
            get { return _Or; }
        }
        public static Func<T, T, T> And
        {
            get { return _And; }
        }
        public static Func<T, T, T> Xor
        {
            get { return _Xor; }
        }

        public static Func<T, T, T> Add
        {
            get { return _Add; }
        }
        public static Func<T, T, T> Subtract
        {
            get { return _Subtract; }
        }
        public static Func<T, T, T> Multiply
        {
            get { return _Multiply; }
        }
        public static Func<T, T, T> Divide
        {
            get { return _Divide; }
        }

        public static Func<T, T, Boolean> Equal
        {
            get { return _Equal; }
        }
        public static Func<T, T, Boolean> NotEqual
        {
            get { return _NotEqual; }
        }
        public static Func<T, T, Boolean> GreaterThan
        {
            get { return _GreaterThan; }
        }
        public static Func<T, T, Boolean> LessThan
        {
            get { return _LessThan; }
        }
        public static Func<T, T, Boolean> GreaterThanOrEqual
        {
            get { return _GreaterThanOrEqual; }
        }
        public static Func<T, T, Boolean> LessThanOrEqual
        {
            get { return _LessThanOrEqual; }
        }

        static Operator()
        {
            _Add = Operator.CreateExpression<T, T, T>(Expression.Add);
            _Subtract = Operator.CreateExpression<T, T, T>(Expression.Subtract);
            _Divide = Operator.CreateExpression<T, T, T>(Expression.Divide);
            _Multiply = Operator.CreateExpression<T, T, T>(Expression.Multiply);

            _GreaterThan = Operator.CreateExpression<T, T, bool>(Expression.GreaterThan);
            _GreaterThanOrEqual = Operator.CreateExpression<T, T, bool>(Expression.GreaterThanOrEqual);
            _LessThan = Operator.CreateExpression<T, T, bool>(Expression.LessThan);
            _LessThanOrEqual = Operator.CreateExpression<T, T, bool>(Expression.LessThanOrEqual);
            _Equal = Operator.CreateExpression<T, T, bool>(Expression.Equal);
            _NotEqual = Operator.CreateExpression<T, T, bool>(Expression.NotEqual);

            _Negate = Operator.CreateExpression<T, T>(Expression.Negate);
            _And = Operator.CreateExpression<T, T, T>(Expression.And);
            _Or = Operator.CreateExpression<T, T, T>(Expression.Or);
            _Not = Operator.CreateExpression<T, T>(Expression.Not);
            _Xor = Operator.CreateExpression<T, T, T>(Expression.ExclusiveOr);
        }
    }
    internal static class Operator<TValue, TResult>
    {
        private static readonly Func<TValue, TResult> _Convert = null;
        private static readonly Func<TResult, TValue, TResult> _Add = null;
        private static readonly Func<TResult, TValue, TResult> _Subtract = null;
        private static readonly Func<TResult, TValue, TResult> _Multiply = null;
        private static readonly Func<TResult, TValue, TResult> _Divide = null;

        static Operator()
        {
            _Convert = Operator.CreateExpression<TValue, TResult>(body => Expression.Convert(body, typeof(TResult)));
            _Add = Operator.CreateExpression<TResult, TValue, TResult>(Expression.Add, true);
            _Subtract = Operator.CreateExpression<TResult, TValue, TResult>(Expression.Subtract, true);
            _Multiply = Operator.CreateExpression<TResult, TValue, TResult>(Expression.Multiply, true);
            _Divide = Operator.CreateExpression<TResult, TValue, TResult>(Expression.Divide, true);
        }

        public static Func<TValue, TResult> Convert
        {
            get { return _Convert; }
        }
        public static Func<TResult, TValue, TResult> Add
        {
            get { return _Add; }
        }
        public static Func<TResult, TValue, TResult> Subtract
        {
            get { return _Subtract; }
        }
        public static Func<TResult, TValue, TResult> Multiply
        {
            get { return _Multiply; }
        }
        public static Func<TResult, TValue, TResult> Divide
        {
            get { return _Divide; }
        }
    }
}
