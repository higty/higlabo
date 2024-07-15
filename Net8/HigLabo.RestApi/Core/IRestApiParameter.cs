using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.RestApi
{
    public interface IRestApiParameter
    {
        string HttpMethod { get; }
        string GetApiPath();
        object? GetRequestBody();
    }
}
