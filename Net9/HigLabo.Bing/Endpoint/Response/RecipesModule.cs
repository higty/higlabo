namespace HigLabo.Bing;

public class RecipesModule : BingRestApiResponse
{
    public Recipe[] Value { get; set; } = Array.Empty<Recipe>();
}
