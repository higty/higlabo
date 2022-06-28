using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public class RestApiResponse : HigLabo.Net.OAuth.RestApiResponse
    {
        public bool Ok { get; set; }
        public string Error { get; set; } = "";
        public ResponseMetadata Response_MetaData { get; set; }
    }
}
