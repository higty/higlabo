namespace HigLabo.OpenAI
{
    public class RequiredAction
    {
        public SubmitToolOutputs? Submit_Tool_Outputs { get; set; } 

        public IEnumerable<ToolCall> GetToolCallList()
        {
            if (this.Submit_Tool_Outputs == null) { yield break; }
            foreach (var item in this.Submit_Tool_Outputs.Tool_Calls)
            {
                yield return item;
            }
        }
    }
}
