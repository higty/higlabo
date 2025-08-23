namespace HigLabo.OpenAI;
public class ExpirationPolicy
{
    public string Anchor { get; set; } = "";
    public int? Seconds { get; set; }
    public int? Minutes { get; set; }
    public int? Days { get; set; }
}
