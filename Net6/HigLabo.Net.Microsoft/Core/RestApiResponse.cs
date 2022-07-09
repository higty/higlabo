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
        public string ODataContext { get; set; }

        public override bool IsThrowException()
        {
            if (((IRestApiResponse)this).StatusCode != HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
    }
}
