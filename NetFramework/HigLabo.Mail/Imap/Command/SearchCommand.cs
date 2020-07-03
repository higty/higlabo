using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Imap
{
    public abstract class SearchCommand
    {
        internal abstract Boolean IsEncodeValue { get; }
        public SearchResultType ResultType { get; set; }

        public String GetCommandText()
        {
            if (this.ResultType == SearchResultType.Index)
            {
                return String.Format("SEARCH {0}", this.CreateCommandText());
            }
            return String.Format("UID SEARCH {0}", this.CreateCommandText());
        }
        protected abstract String CreateCommandText();
        public virtual Byte[] GetEncodedValue()
        {
            throw new NotSupportedException();
        }
    }
}
