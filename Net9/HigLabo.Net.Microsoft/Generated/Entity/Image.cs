using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/image?view=graph-rest-1.0
/// </summary>
public partial class Image
{
    public Int32? Height { get; set; }
    public Int32? Width { get; set; }
}
