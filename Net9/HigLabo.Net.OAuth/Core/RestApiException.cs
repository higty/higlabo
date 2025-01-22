using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth;

public class RestApiException : Exception
{
    public RestApiResponse Response { get; init; }

    public RestApiException(RestApiResponse response)
        : base(response.GetResponseBodyText())
    {
        this.Response = response;
    }
    public override string ToString()
    {
        var res = this.Response;
        var iRes = res as IRestApiResponse;
        var req = iRes.Request;
        var url = req.RequestUri?.AbsoluteUri ?? "";

        return req.Method.ToString() + " " + url + Environment.NewLine
            + iRes.RequestBodyText + Environment.NewLine 
            + res.GetHeaderText() + Environment.NewLine 
            + res.GetResponseBodyText() + Environment.NewLine 
            + base.ToString();
    }
}
