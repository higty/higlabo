namespace HigLabo.OpenAI;
public class ChatKitWorkflow
{
    public string Id { get; set; } = "";
    public object? State_Variables { get; set; }
    public WorkflowTracing Tracing { get; set; } = new WorkflowTracing();
    public string Version { get; set; } = "";
}
public class WorkflowTracing
{
    public bool Enabled { get; set; }
}
