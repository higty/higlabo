using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Anthropic
{
    public interface IRestApiParameter
    {
        string GetApiPath();
        string HttpMethod { get; }
    }
}
