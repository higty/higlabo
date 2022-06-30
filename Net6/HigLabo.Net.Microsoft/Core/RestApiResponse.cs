using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Microsoft
{
    public class RestApiResponse : HigLabo.Net.OAuth.RestApiResponse
    {
        public string ODataContext { get; set; }
    }
}
