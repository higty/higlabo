namespace HigLabo.Bing;

public class ContractualRule
{
    public string _Type { get; set; } = "";
    public string TargetPropertyName { get; set; } = "";
    public int? TargetPropertyIndex { get; set; }
    public bool? MustBeCloseToContent { get; set; }
    public License? License { get; set; } 
    public string LicenseNotice { get; set; } = "";
    public string Text { get; set; } = "";
    public string Url { get; set; } = "";
}
