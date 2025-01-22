namespace HigLabo.GoogleAI;

public class Citation
{
    public int StartIndex { get; set; }
    public int EndIndex { get; set; }
    public string Uri { get; set; } = "";
    public string Title { get; set; } = "";
    public string License { get; set; } = "";
    public PublicationDate? PublicationDate { get; set; }

    public override string ToString()
    {
        return $"{this.Title} {this.Uri}";
    }
}
