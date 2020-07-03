using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Imap
{
    public class FetchCommandResult<T>
    {
        public Int32 MailIndex { get; set; }
        public T Value { get; set; }

        public FetchCommandResult(Int32 index, T value)
        {
            this.MailIndex = index;
            this.Value = value;
        }
        public override string ToString()
        {
            return String.Format("{0} {1}", this.MailIndex, this.Value);
        }
    }
}
