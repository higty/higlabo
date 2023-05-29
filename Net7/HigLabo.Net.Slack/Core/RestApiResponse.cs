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
        public ResponseMetadata? Response_MetaData { get; set; }

        public override string GetNextPageToken()
        {
            return this.Response_MetaData?.Next_Cursor ?? "";
        }
        public override bool IsThrowException()
        {
            return this.Ok != true;
        }
    }
}
