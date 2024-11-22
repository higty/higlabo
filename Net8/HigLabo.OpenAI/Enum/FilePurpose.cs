using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public enum FilePurpose
{
    Finetune,
    FinetuneResults,
    Assistants,
    AssistantsOutput,
}

public static class FilePurposeExtensions
{
    public static string GetValue(this FilePurpose purpose)
    {
        switch (purpose)
        {
            case FilePurpose.Finetune: return "fine-tune"; 
            case FilePurpose.FinetuneResults: return "fine-tune-results"; 
            case FilePurpose.Assistants: return "assistants"; 
            case FilePurpose.AssistantsOutput: return "assistants_output"; 
            default: throw SwitchStatementNotImplementException.Create(purpose);
        }
    }
}
