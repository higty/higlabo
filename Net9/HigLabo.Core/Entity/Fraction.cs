using System;

namespace HigLabo.Core;

public struct Fraction : IComparable
{
    private int _Numerator;
    private int _Denominator;

    public int Numerator => _Numerator;
    public int Denominator => _Denominator;
    public decimal DecimalValue => (decimal)_Numerator / (decimal)_Denominator;

    public Fraction()
        : this(1, 0)
    {
    }
    public Fraction(int numerator)
        : this(numerator, 1)
    {
    }
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0) { throw new ArgumentException("Denominator must not be zero."); }
        if ((denominator < 0 && numerator < 0) || (denominator < 0))
        {
            numerator *= -1;
            denominator *= -1;
        }
        this._Numerator = numerator;
        this._Denominator = denominator;

        this.DevideCommonDevisor();
    }

    private void DevideCommonDevisor()
    {
        int d = GetGreatestCommonDevisor(_Numerator, _Denominator);
        _Numerator = _Numerator / d;
        _Denominator = _Denominator / d;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }
        Fraction c = (Fraction)obj;
        return (this._Numerator == c._Numerator) && (this._Denominator == c._Denominator);
    }
    public override int GetHashCode()
    {
        return this._Numerator ^ this._Denominator.GetHashCode();
    }
    public int CompareTo(object? obj)
    {
        if (obj == null)
        {
            return 1;
        }
        if (this.GetType() != obj.GetType())
        {
            throw new ArgumentException("obj must be Fraction object.", "obj");
        }
        return this.DecimalValue.CompareTo(((Fraction)obj).DecimalValue);
    }

    public static Fraction operator +(Fraction x, Fraction y)
    {
        int lc = GetLeastCommonMultiple(x._Denominator, y._Denominator);
        if (x._Denominator != y._Denominator)
        {
            x._Numerator *= (lc / x._Denominator);
            y._Numerator *= (lc / y._Denominator);
        }
        return new Fraction(x._Numerator + y._Numerator, lc);
    }
    public static Fraction operator +(Fraction x, int y)
    {
        return x + new Fraction(y);
    }
    public static Fraction operator -(Fraction x, Fraction y)
    {
        int lc = GetLeastCommonMultiple(x._Denominator, y._Denominator);
        if (x._Denominator != y._Denominator)
        {
            x._Numerator *= (lc / x._Denominator);
            y._Numerator *= (lc / y._Denominator);
        }
        return new Fraction(x._Numerator - y._Numerator, lc);
    }
    public static Fraction operator -(Fraction x, int y)
    {
        return x - new Fraction(y);
    }
    public static Fraction operator *(Fraction x, Fraction y)
    {
        return new Fraction(x._Numerator * y._Numerator, x._Denominator * y._Denominator);
    }
    public static Fraction operator *(Fraction x, int y)
    {
        return new Fraction(x._Numerator * y, x._Denominator);
    }
    public static Fraction operator /(Fraction x, Fraction y)
    {
        if (y._Numerator == 0)
        {
            throw new DivideByZeroException();
        }
        return new Fraction(x._Numerator * y._Denominator, x._Denominator * y._Numerator);
    }
    public static Fraction operator /(Fraction x, int y)
    {
        if (y == 0)
        {
            throw new DivideByZeroException();
        }
        return new Fraction(x._Numerator, x._Denominator * y);
    }
    public static bool operator ==(Fraction x, Fraction y)
    {
        return x.Equals(y);
    }
    public static bool operator !=(Fraction x, Fraction y)
    {
        return !(x == y);
    }
    public static bool operator <(Fraction x, Fraction y)
    {
        return ((x - y)._Numerator < 0);
    }
    public static bool operator >(Fraction x, Fraction y)
    {
        return (y < x);
    }
    public static bool operator <=(Fraction x, Fraction y)
    {
        return ((x - y)._Numerator <= 0);
    }
    public static bool operator >=(Fraction x, Fraction y)
    {
        return (y <= x);
    }

    public static Fraction Abs(Fraction x)
    {
        return new Fraction(Math.Abs(x.Numerator), Math.Abs(x.Denominator));
    }
    public static int GetGreatestCommonDevisor(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        if (a < b)
        {
            return GetGreatestCommonDevisor(b, a);
        }
        while (b != 0)
        {
            int r = a % b;
            a = b;
            b = r;
        }
        return a;
    }
    public static int GetLeastCommonMultiple(int a, int b)
    {
        return a * b / GetGreatestCommonDevisor(a, b);
    }

    public override string ToString()
    {
        return $"{_Numerator}/{_Denominator}";
    }
}
