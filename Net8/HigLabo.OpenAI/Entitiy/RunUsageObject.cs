using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class RunUsageObject
{
    public Int32 Prompt_Tokens { get; set; }
    public Int32 Completion_Tokens { get; set; }
    public Int32 Total_Tokens { get; set; }
}
