using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class ProjectUserObject
    {
        public string Id { get; set; } = "";
        public string Object { get; set; } = "";
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Role { get; set; } = "";
        public int Added_At { get; set; } 
    }
    public class ProjectUserObjectResponse : RestApiResponse
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Role { get; set; } = "";
        public int Added_At { get; set; }
    }
}
