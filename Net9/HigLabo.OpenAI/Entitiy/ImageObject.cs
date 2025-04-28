using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class ImageObject
{
    public string Url { get; set; } = "";
    public string B64_Json { get; set; } = "";
    public string Revised_Prompt { get; set; } = "";

    public Byte[] GetBytes()
    {
        return Convert.FromBase64String(this.B64_Json);
    }
}
