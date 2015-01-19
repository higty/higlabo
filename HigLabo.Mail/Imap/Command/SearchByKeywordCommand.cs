using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HigLabo.Core;

namespace HigLabo.Net.Imap
{
    public class SearchByKeywordCommand : SearchCommand
    {
        internal override bool IsEncodeValue
        {
            get { return false; }
        }
        public SearchByKeywordCommandKey Key { get; set; }

        public SearchByKeywordCommand()
        {
            this.Key = SearchByKeywordCommandKey.All;
        }
        protected override String CreateCommandText()
        {
            return this.Key.ToStringFromEnum();
        }
    }
}
