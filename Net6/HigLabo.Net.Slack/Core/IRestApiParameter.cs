using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public interface IRestApiParameter
    {
        string ApiPath { get; }
        string HttpMethod { get; } 
    }
    public interface IRestApiPagingParameter
    {
        string NextPageToken { get; set; }
    }
}
