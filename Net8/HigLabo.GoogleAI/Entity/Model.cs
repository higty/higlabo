namespace HigLabo.GoogleAI
{
    public class Model
    {
        public string Name { get; set; } = "";
        public string BaseModelId { get; set; } = "";
        public string Version { get; set; } = "";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public int? InputTokenLimit { get; set; }
        public int? OutputTokenLimit { get; set; }
        public string[]? SupportedGenerationMethods { get; set; }
        public double? Temperature { get; set; }
        public double? TopP { get; set; }
        public int? TopK { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
