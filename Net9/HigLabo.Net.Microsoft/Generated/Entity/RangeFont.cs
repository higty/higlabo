using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/rangefont?view=graph-rest-1.0
/// </summary>
public partial class RangeFont
{
    public enum RangeFontstring
    {
        None,
        Single,
        Double,
        SingleAccountant,
        DoubleAccountant,
    }

    public bool? Bold { get; set; }
    public string? Color { get; set; }
    public bool? Italic { get; set; }
    public string? Name { get; set; }
    public Double? Size { get; set; }
    public RangeFontstring Underline { get; set; }
}
