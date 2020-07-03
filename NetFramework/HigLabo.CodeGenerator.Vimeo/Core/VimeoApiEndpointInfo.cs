using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator.Vimeo
{
    public class VimeoApiEndpointInfo
    {
        public String HttpMethodName { get; set; }
        public String ApiPath { get; set; }
        public String ApiPlaygroundUrl { get; set; }
        public String Name1 { get; set; }
        public String Name2 { get; set; }
        public Boolean HasResult
        {
            get
            {
                if (String.IsNullOrEmpty(this.ResultClassName) == true)
                {
                    return false;
                }
                return true;
            }
        }

        public List<VimeoApiCommandParameterInfo> CommandParameters { get; private set; }
        public String ResultClassName { get; set; }
        public Boolean ResultIsArray { get; set; }

        public VimeoApiEndpointInfo()
        {
            this.CommandParameters = new List<VimeoApiCommandParameterInfo>();
            this.ResultIsArray = true;
        }
    }
}
