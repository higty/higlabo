namespace HigLabo.Bing;

public class QueryContext
{
    public bool? AdultIntent { get; set; }
    public string AlterationOverrideQuery { get; set; } = "";
    public string AlteredQuery { get; set; } = "";
    public bool? AskUserForLocation { get; set; }
    public string OriginalQuery { get; set; } = "";
}
