using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HigLabo.Core;
using System.Globalization;

namespace HigLabo.Net.Imap
{
    public class SearchByDateTimeCommand : SearchCommand
    {
        internal override bool IsEncodeValue
        {
            get { return false; }
        }
        public SearchByDateTimeCommandKey Key { get; set; }
        public DateTime Value { get; set; }

        public SearchByDateTimeCommand()
        {
            this.Key = SearchByDateTimeCommandKey.On;
        }

        protected override String CreateCommandText()
        {
            return String.Format("{0} {1}"
                , this.Key.ToStringFromEnum()
                , this.Value.ToString("dd-MMM-yyyy", new CultureInfo("en-US")));
        }
    }
}
