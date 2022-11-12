using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class SwitchStatementNotImplementException
    {
        public static SwitchStatementNotImplementException<T> Create<T>(T value)
        {
            return new SwitchStatementNotImplementException<T>(value);
        }
        public static SwitchStatementNotImplementException<T> Create<T>(T value, string message)
        {
            return new SwitchStatementNotImplementException<T>(value, message);
        }
        public static SwitchStatementNotImplementException<T> Throw<T>(T value)
        {
            throw new SwitchStatementNotImplementException<T>(value);
        }
        public static SwitchStatementNotImplementException<T> Throw<T>(T value, string message)
        {
            throw new SwitchStatementNotImplementException<T>(value, message);
        }
    }
    public class SwitchStatementNotImplementException<T>: Exception
    {
        public T Value { get; private set; }

        public SwitchStatementNotImplementException(T value)
        {
            this.Value = value;
        }
        public SwitchStatementNotImplementException(T value, String message)
            : base(message)
        {
            this.Value = value;
        }

    }
}
