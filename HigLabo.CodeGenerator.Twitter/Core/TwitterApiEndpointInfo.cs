using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator.Twitter
{
    public class TwitterApiEndpointInfo
    {
        public String HttpMethodName { get; set; }
        public String DocumentUrl { get; set; }
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

        public List<TwitterApiCommandParameterInfo> CommandParameters { get; private set; }
        public String ResultClassName { get; set; }
        public Boolean ResultIsArray { get; set; }

        public TwitterApiEndpointInfo()
        {
            this.CommandParameters = new List<TwitterApiCommandParameterInfo>();
            this.ResultIsArray = true;
        }
    }
}
