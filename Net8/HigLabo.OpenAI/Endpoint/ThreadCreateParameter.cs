using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public partial class ThreadCreateParameter
{
    public class Message
    {
        public string Role { get; set; } = "user";
        public string Content { get; set; } = "";
        public List<string>? File_Ids { get; set; }
        public object? MetaData { get; set; }
    }
}
