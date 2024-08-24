using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public class RestApiResponse : OAuth.RestApiResponse
    {
        public string ODataContext { get; set; } = "";
        public string ODataNextLink { get; set; } = "";
    }
    public class RestApiResponse<T> : RestApiResponse
    {
        public T[]? Value { get; set; }
    }
}
