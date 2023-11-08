using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class RestApiDataResponse<T> : RestApiResponse
    {
        public T Data { get; set; }
    }
}
