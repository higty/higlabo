using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.CodeGenerator
{
    public class ApiRequestPath
    {
        public string HttpMethod { get; set; }
        public string ApiPath { get; set; }

        public ApiRequestPath(string httpMethod, string apiPath)
        {
            this.HttpMethod = httpMethod;
            this.ApiPath = apiPath;
        }
        public override string ToString()
        {
            return $"{this.HttpMethod} {this.ApiPath}";
        }
    }
}
