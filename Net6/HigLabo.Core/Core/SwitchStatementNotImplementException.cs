using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
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
