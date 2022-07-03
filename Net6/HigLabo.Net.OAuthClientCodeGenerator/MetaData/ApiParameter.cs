using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.CodeGenerator
{
    public class ApiParameter
    {
        public string Name { get; set; } = "";
        public string TypeName { get; set; } = "";
        public bool Required { get; set; }
        public bool IsNextPageToken { get; set; } = false;

        public string EntityUrl { get; set; } = "";
        public string EntityClassName { get; set; } = "";
        public bool IsEnum { get; set; } = false;
        public List<string> EnumValues { get; init; } = new List<string>();
    }
}
