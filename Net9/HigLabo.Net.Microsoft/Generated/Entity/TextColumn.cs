using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/textcolumn?view=graph-rest-1.0
/// </summary>
public partial class TextColumn
{
    public bool? AllowMultipleLines { get; set; }
    public bool? AppendChangesToExistingText { get; set; }
    public Int32? LinesForEditing { get; set; }
    public Int32? MaxLength { get; set; }
    public string? TextType { get; set; }
}
