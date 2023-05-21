using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/webapplication?view=graph-rest-1.0
    /// </summary>
    public partial class WebApplication
    {
        public string? HomePageUrl { get; set; }
        public ImplicitGrantSettings? ImplicitGrantSettings { get; set; }
        public string? LogoutUrl { get; set; }
        public String[]? RedirectUris { get; set; }
    }
}
