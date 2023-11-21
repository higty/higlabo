using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth
{
    public interface IRestApiParameter
    {
        string ApiPath { get; }
        string HttpMethod { get; }
    }
    public interface IRestApiPagingParameter
    {
        string? NextPageToken { get; set; }
    }
}
