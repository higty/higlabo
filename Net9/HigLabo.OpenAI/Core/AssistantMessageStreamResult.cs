using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class AssistantMessageStreamResult
{
    public ThreadObject? Thread { get; set; }
    public RunObject? Run { get; set; }
    public RunStepObject? RunStep { get; set; }
    public MessageObject? Message { get; set; }
    public List<AssistantDeltaObject> DeltaList { get; init; } = new();
}
