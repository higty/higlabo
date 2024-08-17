using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class ProjectApiKeyOwner
    {
        public string Type { get; set; } = "";
        public UserObject? User { get; set; } 
        public ProjectServiceAccountObject? Service_Account { get; set; }
    }
}
