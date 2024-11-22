using System;

namespace HigLabo.Core;

public class ValueEventArgs<T> : EventArgs
{
    public T Value { get; init; }

    public ValueEventArgs(T value)
    {
        this.Value = value;
    }
}
public class ValueEventArgs
	{
		public static ValueEventArgs<T> Create<T>(T value)
		{
			return new ValueEventArgs<T>(value);
		}
	}
