using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth
{
    public class ResponseReceivedEventArgs<T>
        where T: RestApiResponse
    {
        public OAuthClient OAuthClient { get;init;}
        public List<T> ResponseList { get; init; } = new List<T>();

        public ResponseReceivedEventArgs(OAuthClient oAuthClient, List<T> responseList)
        {
            this.OAuthClient = oAuthClient;
            this.ResponseList.AddRange(responseList);
        }
    }
}
