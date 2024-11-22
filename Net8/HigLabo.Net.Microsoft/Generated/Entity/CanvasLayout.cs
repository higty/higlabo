using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/canvaslayout?view=graph-rest-1.0
/// </summary>
public partial class CanvasLayout
{
    public string? Id { get; set; }
    public HorizontalSection[]? HorizontalSections { get; set; }
    public VerticalSection? VerticalSection { get; set; }
}
