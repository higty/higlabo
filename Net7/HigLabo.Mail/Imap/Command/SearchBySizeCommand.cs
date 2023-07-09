using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HigLabo.Core;

namespace HigLabo.Net.Imap
{
    public class SearchBySizeCommand : SearchCommand
    {
        internal override bool IsEncodeValue
        {
            get { return false; }
        }
        public SearchBySizeCommandKey Key { get; set; }
        public Int32 Value { get; set; }

        public SearchBySizeCommand()
        {
            this.Key = SearchBySizeCommandKey.Smaller;
        }
        protected override String CreateCommandText()
        {
            return String.Format("{0} {1}", this.Key.ToStringFromEnum(), this.Value);
        }
    }
}
