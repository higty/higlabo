namespace HigLabo.Bing;

public class LocalEntityAnswer : BingRestApiResponse
{
    public Place[] Value { get; set; } = Array.Empty<Place>();
}
