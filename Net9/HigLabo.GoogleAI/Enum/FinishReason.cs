using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.GoogleAI;

public enum FinishReason
{
    Unspecified,
    Stop,
    Max_Tokens,
    Safety,
    Recitation,
    Other,
}
