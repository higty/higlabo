namespace HigLabo.Bing;

public class Organization
{
    public string Name { get; set; } = "";
    public string Url { get; set; } = "";

    public override string ToString()
    {
        return this.Name;
    }
}
