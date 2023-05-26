using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Mime
{
    public class MimeParserFilter
    {
        public Boolean LoadMessageRawData { get; set; }
        public Boolean LoadContentRawData { get; set; }
        public Boolean LoadContentBodyData { get; set; }
        public Boolean LoadContents { get; set; }

        public MimeParserFilter()
        {
            this.LoadMessageRawData = false;
            this.LoadContentRawData = false;
            this.LoadContentBodyData = true;
            this.LoadContents = true;
        }
        public MimeParserFilter Copy()
        {
            var filter = new MimeParserFilter();

            filter.LoadMessageRawData = this.LoadMessageRawData;
            filter.LoadContentRawData = this.LoadContentRawData;
            filter.LoadContentBodyData = this.LoadContentBodyData;
            filter.LoadContents = this.LoadContents;

            return filter;
        }
    }
}
