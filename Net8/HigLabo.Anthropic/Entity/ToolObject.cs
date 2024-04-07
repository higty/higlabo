namespace HigLabo.Anthropic
{
    public class ToolObject
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public object? Input_Schema { get; set; }
    }
}
