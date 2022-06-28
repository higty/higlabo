using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public class ResponseReceivedEventArgs<T>
        where T: RestApiResponse
    {
        public SlackClient SlackClient { get;init;}
        public List<T> ResponseList { get; init; } = new List<T>();

        public ResponseReceivedEventArgs(SlackClient slackClient, List<T> responseList)
        {
            this.SlackClient = slackClient;
            this.ResponseList.AddRange(responseList);
        }
    }
}
