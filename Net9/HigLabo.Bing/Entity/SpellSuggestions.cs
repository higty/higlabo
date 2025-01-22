namespace HigLabo.Bing;

public class SpellSuggestions
{
    public string Id { get; set; } = "";
    public Query[] Value { get; set; } = Array.Empty<Query>();
}
