using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/website?view=graph-rest-1.0
/// </summary>
public partial class Website
{
    public enum WebsiteWebsiteType
    {
        Other,
        Home,
        Work,
        Blog,
        Profile,
    }

    public string? Address { get; set; }
    public string? DisplayName { get; set; }
    public WebsiteWebsiteType Type { get; set; }
}
