namespace HigLabo.Bing;

public class EntityAnswer : BingRestApiResponse
{
    public string QueryScenario { get; set; } = "";
    public Entity[] Value { get; set; } = Array.Empty<Entity>();
}
