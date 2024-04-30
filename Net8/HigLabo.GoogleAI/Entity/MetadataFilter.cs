namespace HigLabo.GoogleAI
{
    public class MetadataFilter
    {
        public string Key { get; set; } = "";
        public List<Condition> Conditions { get; init; } = new();
    }
}
