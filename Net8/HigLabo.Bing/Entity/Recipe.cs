namespace HigLabo.Bing;

public class Recipe
{
    public AggregateRating? AggregateRating { get; set; }
    public string CookTime { get; set; } = "";
    public Person? Creator { get; set; } 
    public string Name { get; set; } = "";
    public string PrepTime { get; set; } = "";
    public string ThumbnailUrl { get; set; } = "";
    public string TotalTime { get; set; } = "";
    public string Url { get; set; } = "";

    public override string ToString()
    {
        return this.Name;
    }
}
