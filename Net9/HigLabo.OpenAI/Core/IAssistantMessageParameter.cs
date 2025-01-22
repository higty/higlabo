namespace HigLabo.OpenAI;

public interface IAssistantMessageParameter
{
}
public partial class RunCreateParameter : IAssistantMessageParameter { }
public partial class ThreadRunParameter : IAssistantMessageParameter { }
public partial class SubmitToolOutputsParameter : IAssistantMessageParameter { }
