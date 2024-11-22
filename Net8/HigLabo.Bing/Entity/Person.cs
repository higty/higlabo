namespace HigLabo.Bing;

public class Person
{
    public string _Type { get; set; } = "";
    public string Description { get; set; } = "";
    public Image? Image { get; set; }
    public string JobTitle { get; set; } = "";
    public string Name { get; set; } = "";
    public string TwitterProfile { get; set; } = "";
    public string Url { get; set; } = "";
    public string WebSearchUrl { get; set; } = "";

    public override string ToString()
    {
        return this.Name;
    }
}
